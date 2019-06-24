namespace AcmeTests.API.v1
{
    using AcmeDirectorySearch.Controllers.v1.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class CreateAddressTest
    {
        [Fact]
        public void Validate_CreateAddress_Structure()
        {
            var propinfo = typeof(CreateAddress).GetProperties();
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
