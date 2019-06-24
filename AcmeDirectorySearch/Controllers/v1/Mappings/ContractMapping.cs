namespace AcmeDirectorySearch.Controllers.v1.Mappings
{
    using AcmeDirectorySearch.Controllers.v1.Contracts;
    using AcmeDirectorySearch.Core.DTO;
    using AutoMapper;

    /// <summary>
    /// Mapping for Nested Input objects used with v1 of the API
    /// Used with AutoMapper for determing transfer between DTO objects and v1.Contracts
    /// 
    /// Each version of the API should have its own Contract Mappers
    /// </summary>
    public class ContractMapping : Profile
    {
        public ContractMapping()
        {
            this.CreateMap<CreateUser, UserDTO>();
            this.CreateMap<UserDTO, UserResponse>();
            this.CreateMap<CreateAddress, AddressDTO>();
            this.CreateMap<AddressDTO, AddressResponse>();

            // Only maps when creating a User
            this.CreateMap<CreateImage, UserImageDTO>();
        }
    }
}
