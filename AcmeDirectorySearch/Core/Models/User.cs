namespace AcmeDirectorySearch.Core.Models
{
    using AcmeDirectorySearch.Core.Validations;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Object for handling the modeling of a User entity 
    /// </summary>
    public class User : ValidationBase
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [MinLength(3)]
        [MaxLength(250)]
        public string Interests { get; set; }

        public Address Address { get; set; }
    }
}
