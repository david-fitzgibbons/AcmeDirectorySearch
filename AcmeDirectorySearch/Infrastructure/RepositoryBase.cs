namespace AcmeDirectorySearch.Infrastructure
{
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Base Repository class which retreives the Database 
    /// Properties / Connection information through DI
    /// </summary>
    public abstract class RepositoryBase
    {
        private readonly DatabaseOptions databaseOptions;

        public RepositoryBase(IOptions<DatabaseOptions> databaseOptions)
        {
            this.databaseOptions = databaseOptions.Value;
        }

        protected IDbConnection DatabaseConnection
        {
            get
            {
                return new SqlConnection(this.databaseOptions.ConnectionString);
            }
        }
    }
}
