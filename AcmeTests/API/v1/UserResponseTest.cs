namespace AcmeTests.API.v1
{
    using AcmeDirectorySearch.Controllers.v1.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xunit;


    public class UserResponseTest
    {
        [Fact]
        public void Validate_UserResponse_Structure()
        {
            var propinfo = typeof(UserResponse).GetProperties();
            var props = propinfo.ToDictionary(o => o.Name, o => o.PropertyType.ToString());

            var expected = new Dictionary<string, string>
            {
                { "Address", "AcmeDirectorySearch.Controllers.v1.Contracts.AddressResponse" },
                { "Birthday", "System.DateTime" },
                { "FirstName", "System.String" },
                { "Id", "System.Int32" },
                { "Interests", "System.String" },
                { "LastName", "System.String" },
            };

            //check that all properties exist and each is of declared type
            Assert.Equal(expected.Keys.Count, props.Keys.Count);

            foreach (var key in expected.Keys)
            {
                Assert.Equal(expected[key], props[key]);
            }
        }
    }
}
