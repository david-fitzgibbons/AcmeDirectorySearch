namespace AcmeDirectorySearch.Core.Mappings
{
    using AcmeDirectorySearch.Core.DTO;
    using AcmeDirectorySearch.Core.Models;
    using AutoMapper;

    /// <summary>
    /// Mapping for Nested Input objects that are trasnferred between
    /// the service layer and the persistence layer
    /// </summary>
    public class UserDTOMapping : Profile
    {
        public UserDTOMapping()
        {
            this.CreateMap<UserDTO, User>();
            this.CreateMap<User, UserDTO>();
            this.CreateMap<AddressDTO, Address>();
            this.CreateMap<Address, AddressDTO>();
        }
    }
}
