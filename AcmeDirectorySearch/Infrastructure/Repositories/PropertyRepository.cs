namespace AcmeDirectorySearch.Infrastructure.Repositories
{
    using AcmeDirectorySearch.Infrastructure.Interfaces;
    using Dapper;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    /// <summary>
    /// Persistence layer for handling retrieval of Property values form the DB
    /// </summary>
    public sealed class PropertyRepository : RepositoryBase, IPropertyRepository
    {
        public PropertyRepository(IOptions<DatabaseOptions> databaseOptions)
            : base(databaseOptions)
        {
        }

        /// <summary>
        /// Return a list of available States
        /// </summary>
        /// <returns>List of State Abbreviations</returns>
        public async Task<IEnumerable<string>> GetStates()
        {
            string sql = @"Select [state] from [dbo].[State]";

            using (IDbConnection db = this.DatabaseConnection)
            {
                return await db.QueryAsync<string>(sql);
            }
        }
    }
}