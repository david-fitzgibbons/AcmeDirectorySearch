namespace AcmeDirectorySearch.Core.Models
{
    using AcmeDirectorySearch.Core.Validations;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Address object that reprsents a User object.  This model contains all of the
    /// business logic pertaining to Address
    /// </summary>
    public class Address : ValidationBase
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Street1 { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Street2 { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]{2}$", ErrorMessage = "Invalid 'State' format, provide 2 letter abbreviation for State")]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Invalid 'Zip' format, ##### required")]
        public string Zip { get; set; }
    }
}
