namespace AcmeTests.Integration
{
    using AcmeTests.Integration.Fixtures;
    using System.Collections.Generic;
    using Xunit;
    using Dapper;
    using System.Data;
    using AcmeDirectorySearch.Infrastructure.Repositories;
    using Microsoft.Extensions.Options;
    using AcmeDirectorySearch.Core.Models;
    using AcmeDirectorySearch.Core.DTO;
    using System.Linq;

    [Collection("Database")]
    public class UserRepositoryTest
    {
        DatabaseFixture fixture;

        public UserRepositoryTest(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        private UserRepository getRepo()
        {
            var opts = new AcmeDirectorySearch.Infrastructure.DatabaseOptions();
            opts.ConnectionString = fixture.DatabaseConnectionString;

            var iopts = Options.Create<AcmeDirectorySearch.Infrastructure.DatabaseOptions>(opts);
            return new UserRepository(iopts);
        }

        [Fact]
        public async void Validate_User_Create_AND_Retrieve_Single_User()
        {
            var repo = getRepo();
            
            // Test creating the User
            User resp = await repo.CreateUser(HelperData.User(), HelperData.userImageDTOWithoutData());
            Assert.True(resp.Id > 0);

            // Test retrieving the created User
            User retrieve = await repo.GetSingle(resp.Id);
            Assert.True(retrieve.Id > 0);


            // Clean up by calling Delete
            const string sp = "DeleteUser";
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", retrieve.Id);

            using (IDbConnection db = fixture.Db)
            {
                await db.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
            }
        }



        [Fact]
        public async void Validate_Get_User_Default_Image()
        {
            var repo = getRepo();
            UserImageDTO resp = await repo.GetUserImage(-1);

            Assert.Equal("image/png", resp.Type);
            Assert.True(resp.Base64Image.Length > 2);
        }


        [Fact]
        public async void Validate_Query_For_FirstOrLastName()
        {
            var repo = getRepo();
            string[] filter = new string[] { "mora", "abel" };

            IEnumerable<User> resp = await repo.QueryByName(filter);

            Assert.Equal(2, resp.ToList().Count);

        }
    }
}
