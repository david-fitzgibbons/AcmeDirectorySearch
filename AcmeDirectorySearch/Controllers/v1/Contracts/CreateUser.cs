namespace AcmeDirectorySearch.Controllers.v1.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contract defining the input of the User object during create actions for version 1 of the API
    /// </summary>
    public sealed class CreateUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public string Interests { get; set; }

        [Required]
        public CreateAddress Address { get; set; }

        public CreateImage Image { get; set; }
    }
}
