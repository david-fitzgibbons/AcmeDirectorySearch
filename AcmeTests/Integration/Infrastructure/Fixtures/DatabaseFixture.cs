namespace AcmeTests.Integration.Fixtures
{

    using System.IO;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;


    public class DatabaseFixture
    {

        private readonly string connectionString;

        public SqlConnection Db
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public DatabaseFixture()
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.test.json")
                    .Build();

            this.connectionString = config.GetSection("Database")["ConnectionString"];
        }

    }
}
