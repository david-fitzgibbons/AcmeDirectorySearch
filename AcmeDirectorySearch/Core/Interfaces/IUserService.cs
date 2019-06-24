namespace AcmeDirectorySearch.Core.Interfaces
{
    using AcmeDirectorySearch.Core.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for the UserService layer for transferring
    /// data from the user input to the persistence layer for 
    /// activities dealing with User object
    /// </summary>
    public interface IUserService
    {
        Task<UserDTO> CreateUser(UserDTO user);

        Task<UserDTO> GetSingleUser(int id);

        Task<UserImageDTO> GetUserImage(int id);

        Task<List<UserDTO>> QueryUsersByName(IEnumerable<string> filter);
    }
}
