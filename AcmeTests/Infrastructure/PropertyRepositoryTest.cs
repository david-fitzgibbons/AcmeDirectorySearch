using AcmeDirectorySearch.Infrastructure.Repositories;
using AcmeTests.Integration.Fixtures;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace AcmeTests.Integration.Infrastructure
{
    [Collection("Database")]
    public class PropertyRepositoryTest
    {
        DatabaseFixture fixture;

        public PropertyRepositoryTest(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async void Validate_Get_States()
        {
            var opts = new AcmeDirectorySearch.Infrastructure.DatabaseOptions();
            opts.ConnectionString = fixture.DatabaseConnectionString;

            var iopts = Options.Create<AcmeDirectorySearch.Infrastructure.DatabaseOptions>(opts);
            var repo = new PropertyRepository(iopts);

            var results = await repo.GetStates();

            Assert.Equal(50, results.ToList<string>().Count);

        }


         
    }
}
