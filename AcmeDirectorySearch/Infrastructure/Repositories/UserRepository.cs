namespace AcmeDirectorySearch.Infrastructure.Repositories
{
    using AcmeDirectorySearch.Core.DTO;
    using AcmeDirectorySearch.Core.Models;
    using AcmeDirectorySearch.Infrastructure.Interfaces;
    using Dapper;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>
    /// Handles retrieving and persisting User data to the Database
    /// </summary>
    public sealed class UserRepository : RepositoryBase, IUserRepository
    {
        // Base select statement for querying the user and address table
        private readonly string UserViewSql = "Select * from UserView ";

        // Custom Column Mapper for SQL Responses
        private readonly Dictionary<string, string> columnMaps = new Dictionary<string, string>
        {
            { "UserId", "Id" },
            { "AddressId", "Id" },
        };

        public UserRepository(IOptions<DatabaseOptions> databaseOptions)
            : base(databaseOptions)
        {
            // set up the mappers for handling the sql query id's being prefixed ( ie - UserId / AddressId)
            var userMap = new CustomPropertyTypeMap(typeof(User), (type, column) => this.ColumnMapper(type, column));
            var addressMap = new CustomPropertyTypeMap(typeof(Address), (type, column) => this.ColumnMapper(type, column));

            SqlMapper.SetTypeMap(typeof(User), userMap);
            SqlMapper.SetTypeMap(typeof(Address), addressMap);
        }

        /// <summary>
        /// Creates a User object within the database.  If an image is provided
        /// then one will be created and associated with the User account
        /// </summary>
        /// <param name="user"><see cref="User"/></param>
        /// <param name="image"><see cref="UserImageDTO"/></param>
        /// <returns></returns>
        public async Task<User> CreateUser(User user, UserImageDTO image)
        {
            const string sp = "CreateUser";

            DynamicParameters param = new DynamicParameters();
            param.Add("@FirstName", user.FirstName);
            param.Add("@LastName", user.LastName);
            param.Add("@Birthday", user.Birthday);
            param.Add("@Interests", user.Interests);
            param.Add("@Street1", user.Address.Street1);
            param.Add("@Street2", user.Address.Street2);
            param.Add("@City", user.Address.City);
            param.Add("@State", user.Address.State);
            param.Add("@Zip", user.Address.Zip);

            if (image != null)
            {
                param.Add("@ImageType", image.Type);
                param.Add("@ImageData", image.Base64Image);
            }

            using (IDbConnection db = this.DatabaseConnection)
            {
                int userId = await db.QueryFirstAsync<int>(sp, param, commandType: CommandType.StoredProcedure);
                return await this.GetSingle(userId);
            }
        }

        /// <summary>
        /// Retrieves a single user from the database
        /// </summary>
        /// <param name="id">Id of the User to retrieve</param>
        /// <returns></returns>
        public async Task<User> GetSingle(int id)
        {
            using (IDbConnection db = this.DatabaseConnection)
            {
                IEnumerable<User> result = await db.QueryAsync<User, Address, User>(
                        this.UserViewSql + " Where UserId = @userId",
                        map: (usr, addr) => this.QueryResultMapper(usr, addr),
                        splitOn: "AddressId",
                        param: new { @userId = id });

                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// Retreive a User's profile Image.  If the User record does not contain 
        /// a profile image then a default one will be returned instead
        /// </summary>
        /// <param name="id">Id of the User for whom to retrieve the image</param>
        /// <returns>Image</returns>
        public async Task<UserImageDTO> GetUserImage(int id)
        {
            const string sp = "GetUserImage";

            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", id);

            using (IDbConnection db = this.DatabaseConnection)
            {
                var result = await db.QueryFirstAsync<UserImageDTO>(sp, param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Query the User's by first and last name against the list of filters
        /// that are passed.  A User will match if any part of their First or their
        /// Last name matches any of the filters provided
        /// </summary>
        /// <param name="filters">List of text to compare against User's First or Last name</param>
        /// <returns>List <see cref="User"/></returns>
        public async Task<IEnumerable<User>> QueryByName(IEnumerable<string> filters)
        {
            string whereClause = @" Where
                    FirstName LIKE @filter
                    OR LastName LIKE @filter
                ";

            using (IDbConnection db = this.DatabaseConnection)
            {
                // unable to use SelectMany Linq expression with async
                List<User> resultList = new List<User>();
                foreach (string filter in filters)
                {
                    IEnumerable<User> tmp = await db.QueryAsync<User, Address, User>(
                           this.UserViewSql + whereClause,
                           map: (usr, addr) => this.QueryResultMapper(usr, addr),
                           splitOn: "AddressId",
                           param: new { @filter = "%" + filter + "%" });

                    resultList.AddRange(tmp);
                }

                // Sort list while List<User>
                resultList.Sort((u1, u2) => u1.LastName.CompareTo(u2.LastName));

                // Remove duplicates from the list by userId
                return resultList.GroupBy(user => user.Id)
                    .Select(dupe => dupe.First());
            }
        }

        /// <summary>
        /// Updates a user object based on the new data provided
        /// </summary>
        /// <param name="id">Id of the User to Update</param>
        /// <param name="user">User object containing the updated information</param>
        /// <returns><see cref="User"/></returns>
        public Task<User> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used with Dapper to determine how to map complex queries to 
        /// nested objects
        /// </summary>
        private User QueryResultMapper(User usr, Address addr)
        {
            usr.Address = addr;
            return usr;
        }

        /// <summary>
        /// Used with Dapper to determine which 'id' values relate to 
        /// which of the nested objects (User/Address) while composing
        /// the objects
        /// </summary>
        /// <param name="type"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private PropertyInfo ColumnMapper(Type type, string column)
        {
            string finalColumn = column;
            if (this.columnMaps.ContainsKey(column))
            {
                finalColumn = this.columnMaps[column];
            }

            return type.GetProperty(finalColumn);
        }
    }
}
