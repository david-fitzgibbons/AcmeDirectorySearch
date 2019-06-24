namespace AcmeTests.API.v1
{
    using AcmeDirectorySearch.Controllers.v1.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class CreateImageTest
    {

        [Fact]
        public void Validate_CreateImage_Structure()
        {
            var propinfo = typeof(CreateImage).GetProperties();
            var props = propinfo.Select(prop => prop.Name).ToList();

            props.Sort();
            var expected = new List<string>
            {  "Base64Image", "Type" };

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
