namespace AcmeTests.Unit.Core
{
    using AcmeDirectorySearch.Core.Models;
    using System;
    using Xunit;

    public class UserTests
    {

        [Fact]
        public void areUserClass_Property_Types_Standard()
        {
            var user = HelperData.User();

            Assert.IsType<int>(user.Id);
            Assert.IsType<string>(user.FirstName);
            Assert.IsType<string>(user.LastName);
            Assert.IsType<DateTime>(user.Birthday);
            Assert.IsType<string>(user.Interests);
            Assert.IsType<Address>(user.Address);
        }

        [Fact]
        public void isFirst_Restricted_In_Length_And_Required()
        {
            var validUser = HelperData.User();
            var invalidUserShort = HelperData.User();
            var invalidUserLong = HelperData.User();
            var invalidUserMissing = HelperData.User();

            invalidUserShort.FirstName = "";
            invalidUserLong.FirstName = new string('*', 51);
            invalidUserMissing.FirstName = null;

            Assert.True(HelperFunctions.Validate(validUser));
            Assert.False(HelperFunctions.Validate(invalidUserShort));
            Assert.False(HelperFunctions.Validate(invalidUserLong));
            Assert.False(HelperFunctions.Validate(invalidUserMissing));

        }

        [Fact]
        public void isLast_Restricted_In_Length_And_Required()
        {
            var validUser = HelperData.User();
            var invalidUserShort = HelperData.User();
            var invalidUserLong = HelperData.User();
            var invalidUserMissing = HelperData.User();

            invalidUserShort.LastName = "";
            invalidUserLong.LastName = new string('*', 51);
            invalidUserMissing.LastName = null;

            Assert.True(HelperFunctions.Validate(validUser));
            Assert.False(HelperFunctions.Validate(invalidUserShort));
            Assert.False(HelperFunctions.Validate(invalidUserLong));
            Assert.False(HelperFunctions.Validate(invalidUserMissing));

        }

        [Fact]
        public void isInterests_Optional()
        {
            var validUser = HelperData.User();
            var validUserMissing = HelperData.User();

            validUserMissing.Interests = null;

            Assert.True(HelperFunctions.Validate(validUser));
            Assert.True(HelperFunctions.Validate(validUserMissing));
        }

        [Fact]
        public void isInterests_Restricted_In_Length()
        {
            var validUser = HelperData.User();
            var invalidUserShort = HelperData.User();
            var invalidUserLong = HelperData.User();

            invalidUserShort.Interests = new string('*', 2);
            invalidUserLong.Interests = new string('*', 251);

            Assert.True(HelperFunctions.Validate(validUser));
            Assert.False(HelperFunctions.Validate(invalidUserShort));
            Assert.False(HelperFunctions.Validate(invalidUserLong));

        }

    }
}
