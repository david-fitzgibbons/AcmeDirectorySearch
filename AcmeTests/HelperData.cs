using AcmeDirectorySearch.Core.DTO;
using AcmeDirectorySearch.Core.Models;
using System;
using System.Collections.Generic;

namespace AcmeTests
{

    public static class HelperData
    {

        public static List<UserDTO> UserDTOList()
        {
            List<UserDTO> lst = new List<UserDTO>();
            lst.Add(UserDTO());
            lst.Add(UserDTO(id: 2, FirstName: "__TESTFirst-2"));
            lst.Add(UserDTO(id: 3, FirstName: "__TESTFirst-3"));
            lst.Add(UserDTO(id: 4, FirstName: "__TESTFirst-4"));
            lst.Add(UserDTO(id: 5, FirstName: "__TESTFirst-5"));

            return lst;
        }

        public static UserDTO UserDTO(bool HasImage = false, int id = 1, string FirstName = "__TESTFirst")
        {
            var user = new UserDTO()
            {
                Id = id,
                FirstName = FirstName,
                LastName = "__TESTLast",
                Birthday = DateTime.Now,
                Interests = "__TESTInterests",
                Address = AddressDTO()
            };

            if (HasImage)
            {
                user.Image = userImageDTO();
            }

            return user;
        }

        public static AddressDTO AddressDTO()
        {
            return new AddressDTO()
            {
                Street1 = "__TESTStreet1",
                Street2 = "__TESTStreet2",
                City = "__TESTCity",
                State = "AK",
                Zip = "90210"
            };
        }

        public static UserImageDTO userImageDTO()
        {
            return new UserImageDTO()
            {
                Type = "image/png",
                Base64Image = "image_data"
            };
        }

        public static UserImageDTO userImageDTOWithoutData()
        {
            return new UserImageDTO();
        }


        public static User User(int id = 1, string FirstName = "__TESTFirst", string City = "__TESTCity")
        {
            var user = new User()
            {
                Id = id,
                FirstName = FirstName,
                LastName = "__TESTLast",
                Birthday = DateTime.Now,
                Interests = "__TESTInterests",
                Address = Address(City)
            };

            return user;
        }


        public static Address Address(string City = "__TESTCity")
        {
            return new Address()
            {
                Street1 = "__TESTStreet1",
                Street2 = "__TESTStreet2",
                City = City,
                State = "AK",
                Zip = "90210"
            };
        }

    }


}
