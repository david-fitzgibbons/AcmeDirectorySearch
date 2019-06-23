namespace AcmeTests.Integration
{
    using AcmeTests.Integration.Fixtures;
    using System.Collections.Generic;
    using Xunit;
    using Dapper;
    using System.Data;


    [Collection("Database")]
    public class UserRepositoryTest
    {
        DatabaseFixture fixture;

        public UserRepositoryTest(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async void Validate_User_Create()
        {
            Assert.True(false);
        }


        [Fact]
        public async void Validate_Get_Single_User()
        {

            Assert.True(false);
        }


        [Fact]
        public async void Validate_Get_User_Image()
        {

            Assert.True(false);
        }


        [Fact]
        public async void Validate_Query_For_FirstOrLastName()
        {

            Assert.True(false);
        }
    }
}
