namespace AcmeTests.Integration.Infrastructure
{
    using AcmeTests.Integration.Fixtures;
    using Dapper;
    using System.Collections.Generic;
    using System.Data;
    using Xunit;

    [Collection("Database")]
    public class DatabaseData
    {

        DatabaseFixture fixture;

        public DatabaseData(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async void Required_Database_Properties_Exists()
        {

            var q = @"  select Property from Property
                    where Property in @requiredProperties
                    Order By Property
                ";

            List<string> requiredProperties = new List<string> { "default_image" };

            using (IDbConnection db = fixture.Db)
            {
                IEnumerable<string> result = await db.QueryAsync<string>(q, new { requiredProperties = requiredProperties });
                Assert.Equal(requiredProperties, result);
            }

        }

        [Fact]
        public async void Validate_States_Exist()
        {

            var q = @"  select count(*) from State   ";

            using (IDbConnection db = fixture.Db)
            {
                int result = await db.QueryFirstAsync<int>(q);
                Assert.Equal(50, result);
            }
        }

    }

}
