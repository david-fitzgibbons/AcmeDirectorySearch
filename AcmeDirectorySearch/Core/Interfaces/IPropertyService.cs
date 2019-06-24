namespace AcmeDirectorySearch.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for the PropertyService layer for transferring
    /// data from the user input to the persistence layer
    /// </summary>
    public interface IPropertyService
    {
        Task<IEnumerable<string>> GetStates();

    }
}