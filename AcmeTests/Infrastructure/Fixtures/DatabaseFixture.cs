namespace AcmeTests.Integration.Fixtures
{

    using System.IO;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;


    public class DatabaseFixture
    {
        public string DatabaseConnectionString { get; }


        public SqlConnection Db
        {
            get
            {
                return new SqlConnection(DatabaseConnectionString);
            }
        }

        public DatabaseFixture()
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.test.json")
                    .Build();

            this.DatabaseConnectionString = config.GetSection("Database")["ConnectionString"];
        }

    }
}
