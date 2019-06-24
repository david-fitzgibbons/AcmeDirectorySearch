namespace AcmeTests.API.v1
{
    using AcmeDirectorySearch.Controllers.v1.Contracts;
    using System;


    public static class v1_Data
    {

        public static UserResponse UserResponse(int id = 1, string FirstName = "First")
        {
            var user = new UserResponse()
            {
                Id = id,
                FirstName = FirstName,
                LastName = "Last",
                Birthday = DateTime.Now,
                Interests = "Interests",
                Address = AddressResponse()
            };

            return user;
        }

        public static AddressResponse AddressResponse()
        {
            return new AddressResponse()
            {
                Street1 = "Street1",
                Street2 = "Street2",
                City = "CityABC",
                State = "NY",
                Zip = "12345"
            };
        }

    }
}
