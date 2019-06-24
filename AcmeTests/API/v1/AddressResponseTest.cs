namespace AcmeTests.API.v1
{
    using AcmeDirectorySearch.Controllers.v1.Contracts;
    using System.Collections.Generic;
    using Xunit;
    using System.Linq;

    public class AddressResponseTest
    {

        [Fact]
        public void Validate_AddressResponse_Structure()
        {
            var propinfo = typeof(AddressResponse).GetProperties();
            var props = propinfo.Select(prop => prop.Name).ToList();

            props.Sort();
            var expected = new List<string>
            {  "City", "State", "Street1", "Street2", "Zip" };

            //check that format is specific to defined list of columns
            Assert.Equal(expected, props);

            //check that each property is of type string
            foreach (var pi in propinfo)
            {
                Assert.Equal("System.String", pi.PropertyType.ToString());
            }
        }

    }
}
