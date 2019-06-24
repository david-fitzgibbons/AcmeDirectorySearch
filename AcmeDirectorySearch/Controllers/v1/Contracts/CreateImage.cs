namespace AcmeDirectorySearch.Controllers.v1.Contracts
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contract defining the input of the User's Profile Image during create actions for version 1 of the API
    /// </summary>
    public class CreateImage
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string Base64Image { get; set; }

    }
}
