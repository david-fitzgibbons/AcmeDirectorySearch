namespace AcmeTests.Integration
{

    using AcmeTests.Integration.Fixtures;
    using System.Collections.Generic;
    using Xunit;
    using Dapper;
    using System.Data;


    [Collection("Database")]
    public class DatabaseSchema
    {
        DatabaseFixture fixture;

        public DatabaseSchema(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async void Validate_Database_Tables()
        {
            // ignore non-user generated tables by filtering on startswith '_'
            var q = @"  select TABLE_NAME
                        from Acme.INFORMATION_SCHEMA.TABLES
                        where TABLE_TYPE='BASE TABLE' AND TABLE_NAME NOT LIKE '\_%' ESCAPE '\'
                        Order By TABLE_NAME
                ";

            List<string> tables = new List<string> { "Address", "Property", "State", "User", "UserImage" };

            using (IDbConnection db = fixture.Db)
            {
                IEnumerable<string> result = await db.QueryAsync<string>(q);
                Assert.Equal(tables, result);
            }
        }


        [Fact]
        public async void Validate_Database_StoredProcedures()
        {

            var q = @"  select ROUTINE_NAME
                         from Acme.information_schema.routines 
                         where routine_type = 'PROCEDURE'
                         Order By ROUTINE_NAME
                ";

            List<string> tables = new List<string> { "CreateUser", "DeleteUser", "GetUserImage" };

            using (IDbConnection db = fixture.Db)
            {
                IEnumerable<string> result = await db.QueryAsync<string>(q);
                Assert.Equal(tables, result);
            }
        }


        [Fact]
        public async void Validate_DatabaseViews()
        {

            var q = @"  
                         select TABLE_NAME 
                         from Acme.INFORMATION_SCHEMA.VIEWS
                         Order by TABLE_NAME
                ";

            List<string> tables = new List<string> { "UserView" };

            using (IDbConnection db = fixture.Db)
            {
                IEnumerable<string> result = await db.QueryAsync<string>(q);
                Assert.Equal(tables, result);
            }
        }

    }
}
