namespace AcmeDirectorySearch.Controllers.v1.Contracts
{
    using Newtonsoft.Json;

    /// <summary>
    /// Contract defining the json output of the Address object for version 1 of the API
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class AddressResponse
    {

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}
