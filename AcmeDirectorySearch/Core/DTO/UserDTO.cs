namespace AcmeDirectorySearch.Core.DTO
{
    using System;

    /// <summary>
    /// Data Transfer object between Controllers/Service layer
    /// that represents data associated with the Core.Model.User
    /// </summary>
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Interests { get; set; }

        public AddressDTO Address { get; set; }

        public UserImageDTO Image { get; set; }

    }
}