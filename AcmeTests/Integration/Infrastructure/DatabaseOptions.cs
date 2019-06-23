namespace AcmeTests.Integration
{
    using Xunit;
    using System.IO;
    using AcmeTests.Integration.Fixtures;
    using Microsoft.Extensions.Configuration;


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
