namespace AcmeDirectorySearch.Controllers.v1.Contracts
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contract defining the input of the Address object during create actions for version 1 of the API
    /// </summary>
    public sealed class CreateAddress
    {
        [Required]
        public string Street1 { get; set; }

        public string Street2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }
    }
}
