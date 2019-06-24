namespace AcmeDirectorySearch.Infrastructure.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for the PropertyRepository following the 
    /// RepositoryPattern
    /// </summary>
    public interface IPropertyRepository
    {
        Task<IEnumerable<string>> GetStates();
    }
}
