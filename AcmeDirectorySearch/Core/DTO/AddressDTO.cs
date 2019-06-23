namespace AcmeDirectorySearch.Core.DTO
{
    /// <summary>
    /// Data Transfer object between Controllers/Service layer
    /// that represents data associated with the Core.Models.Address
    /// </summary>
    public class AddressDTO
    {
        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}
