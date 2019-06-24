namespace AcmeDirectorySearch.Core.Services
{
    using AcmeDirectorySearch.Core.Interfaces;
    using AcmeDirectorySearch.Infrastructure.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of the IPropertyService interface providing
    /// actions to be performed with properties
    /// </summary>
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            this.propertyRepository = propertyRepository;
        }

        /// <summary>
        /// Returns a list of States that can be used when creating an Address
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetStates()
        {
            return await this.propertyRepository.GetStates();
        }
    }
}
