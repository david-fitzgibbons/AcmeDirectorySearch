namespace AcmeTests.API.v1
{
    using AcmeDirectorySearch.Controllers.v1.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Xunit;

    public class CreateUserTest
    {

        [Fact]
        public void Validate_CreateUser_Structure()
        {
            var propinfo = typeof(CreateUser).GetProperties();
            var props = propinfo.ToDictionary(o => o.Name, o => o.PropertyType.ToString());

            var expected = new Dictionary<string, string>
            {
                { "Address", "AcmeDirectorySearch.Controllers.v1.Contracts.CreateAddress" },
                { "Birthday", "System.DateTime" },
                { "FirstName", "System.String" },
                { "Image", "AcmeDirectorySearch.Controllers.v1.Contracts.CreateImage" },
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

        [Fact]
        public void Validate_CreateUser_RequiredFields()
        {
            var addr = new CreateAddress()
            {
                Street1 = "Street1",
                Street2 = "Street2",
                City = "City",
                State = "State",
                Zip = "Zip"
            };

            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext vc = new ValidationContext(addr);

            //All Fields
            Assert.True(Validator.TryValidateObject(addr, vc, results, true));

            //Missing Street2 
            addr.Street2 = null;
            Assert.True(Validator.TryValidateObject(addr, vc, results, true));

            //Missing Street1 
            addr.Street1 = null;
            Assert.False(Validator.TryValidateObject(addr, vc, results, true));
            addr.Street1 = "Street1";

            //Missing City 
            addr.City = null;
            Assert.False(Validator.TryValidateObject(addr, vc, results, true));
            addr.City = "City";

            //Missing State 
            addr.State = null;
            Assert.False(Validator.TryValidateObject(addr, vc, results, true));
            addr.State = "State";

            //Missing Zip 
            addr.Zip = null;
            Assert.False(Validator.TryValidateObject(addr, vc, results, true));
            addr.Zip = "Zip";

        }

    }
}
