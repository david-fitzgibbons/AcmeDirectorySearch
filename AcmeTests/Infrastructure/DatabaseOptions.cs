namespace AcmeTests.Integration
{
    using AcmeTests.Integration.Fixtures;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    using Xunit;


    [Collection("Database")]
    public class DatabaseOptions
    {
        DatabaseFixture fixture;

        public DatabaseOptions(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Get_Database_Connection_String_From_AppSettings()
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.test.json")
                    .Build();

            string connectionString = config.GetSection("Database")["ConnectionString"];

            Assert.NotNull(connectionString);

        }

    }
}
