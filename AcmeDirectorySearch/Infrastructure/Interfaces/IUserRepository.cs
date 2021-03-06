﻿namespace AcmeDirectorySearch.Infrastructure.Interfaces
{
    using AcmeDirectorySearch.Core.DTO;
    using AcmeDirectorySearch.Core.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for the UserRepository following the 
    /// RepositoryPattern
    /// </summary>
    public interface IUserRepository
    {
        // Create / Modify
        Task<User> CreateUser(User user, UserImageDTO image);

        Task<User> UpdateUser(int id, User user);

        // Search
        Task<User> GetSingle(int id);

        Task<UserImageDTO> GetUserImage(int id);

        Task<IEnumerable<User>> QueryByName(IEnumerable<string> filters);
    }
}
