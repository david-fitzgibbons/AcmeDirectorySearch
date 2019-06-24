namespace AcmeDirectorySearch.Controllers.v1.Contracts
{
    using System;
    using AcmeDirectorySearch.Core.Converters;
    using Newtonsoft.Json;

    /// <summary>
    /// Contract defining the JSON output of the User object for version 1 of the API
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public sealed class UserResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime Birthday { get; set; }

        public string Interests { get; set; }

        public AddressResponse Address { get; set; }
    }
}
