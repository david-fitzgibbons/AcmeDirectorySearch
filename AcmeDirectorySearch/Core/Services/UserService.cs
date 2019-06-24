namespace AcmeDirectorySearch.Core.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AcmeDirectorySearch.Core.DTO;
    using AcmeDirectorySearch.Core.Interfaces;
    using AcmeDirectorySearch.Core.Models;
    using AcmeDirectorySearch.Infrastructure.Interfaces;
    using AutoMapper;

    /// <summary>
    /// Implementation of the IUserService interface providing
    /// actions to be performed with User
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns a single User from the persistence layer
        /// </summary>
        /// <param name="id">Id of the User to return</param>
        /// <returns><see cref="User"/></returns>
        public async Task<UserDTO> GetSingleUser(int id)
        {
            User result = await this.userRepository.GetSingle(id);
            return this.mapper.Map<User, UserDTO>(result);
        }

        /// <summary>
        /// Returns a list of User's based on the filters provided
        /// </summary>
        /// <param name="filter">List of filters to compare against first and last name</param>
        /// <returns><see cref="User"/></returns>
        public async Task<List<UserDTO>> QueryUsersByName(IEnumerable<string> filter)
        {
            IEnumerable<User> results = await this.userRepository.QueryByName(filter);
            return this.mapper.Map<IEnumerable<User>, List<UserDTO>>(results);
        }

        /// <summary>
        /// Creates a single User
        /// </summary>
        /// <param name="newUserDTO">UserDTO object containing values for the user to be created</param>
        /// <returns><see cref="User"/></returns>
        public async Task<UserDTO> CreateUser(UserDTO newUserDTO)
        {
            User newUser = this.mapper.Map<UserDTO, User>(newUserDTO);
            newUser.Validate();
            newUser.Address.Validate();

            User result = await this.userRepository.CreateUser(newUser, newUserDTO.Image);
            return this.mapper.Map<User, UserDTO>(result);
        }

        /// <summary>
        /// Returns a User Image based on the User Id provided
        /// </summary>
        /// <param name="id">Id of the User</param>
        /// <returns><see cref="UserImageDTO"/></returns>
        public async Task<UserImageDTO> GetUserImage(int id)
        {
            UserImageDTO result = await this.userRepository.GetUserImage(id);
            return result;
        }
    }
}
