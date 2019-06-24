namespace AcmeTests.Unit.Core
{
    using Xunit;

    public class AddressTests
    {

        [Fact]
        public void areUserClass_Property_Types_Standard()
        {
            var addr = HelperData.Address();

            Assert.IsType<string>(addr.Street1);
            Assert.IsType<string>(addr.Street2);
            Assert.IsType<string>(addr.City);
            Assert.IsType<string>(addr.State);
            Assert.IsType<string>(addr.Zip);
        }

        [Fact]
        public void isStreet1_Restricted_In_Length_And_Required()
        {
            var validAddr = HelperData.Address();
            var invalidAddrShort = HelperData.Address();
            var invalidAddrLong = HelperData.Address();
            var invalidAddrMissing = HelperData.Address();

            invalidAddrShort.Street1 = new string('*', 4);
            invalidAddrLong.Street1 = new string('*', 101);
            invalidAddrMissing.Street1 = null;

            Assert.True(HelperFunctions.Validate(validAddr));
            Assert.False(HelperFunctions.Validate(invalidAddrShort));
            Assert.False(HelperFunctions.Validate(invalidAddrLong));
            Assert.False(HelperFunctions.Validate(invalidAddrMissing));
        }

        [Fact]
        public void isStreet2_Optional()
        {
            var validAddr = HelperData.Address();
            var validAddrMissing = HelperData.Address();

            validAddrMissing.Street2 = null;

            Assert.True(HelperFunctions.Validate(validAddr));
            Assert.True(HelperFunctions.Validate(validAddrMissing));
        }

        [Fact]
        public void isStreet2_Restricted_In_Length()
        {
            var validAddr = HelperData.Address();
            var invalidAddrShort = HelperData.Address();
            var invalidAddrLong = HelperData.Address();

            invalidAddrShort.Street2 = new string('*', 4);
            invalidAddrLong.Street2 = new string('*', 101);

            Assert.True(HelperFunctions.Validate(validAddr));
            Assert.False(HelperFunctions.Validate(invalidAddrShort));
            Assert.False(HelperFunctions.Validate(invalidAddrLong));
        }


        [Fact]
        public void isCity_Restricted_In_Length_And_Required()
        {
            var validAddr = HelperData.Address();
            var invalidAddrShort = HelperData.Address();
            var invalidAddrLong = HelperData.Address();
            var invalidAddrMissing = HelperData.Address();

            invalidAddrShort.City = new string('*', 4);
            invalidAddrLong.City = new string('*', 51);
            invalidAddrMissing.City = null;

            Assert.True(HelperFunctions.Validate(validAddr));
            Assert.False(HelperFunctions.Validate(invalidAddrShort));
            Assert.False(HelperFunctions.Validate(invalidAddrLong));
            Assert.False(HelperFunctions.Validate(invalidAddrMissing));
        }

        [Fact]
        public void isZip_Restricted_To_5Numbers_And_Required()
        {
            var validAddr = HelperData.Address();
            var invalidAddrShort = HelperData.Address();
            var invalidAddrLong = HelperData.Address();
            var invalidAddrMissing = HelperData.Address();
            var invalidAddrFormat = HelperData.Address();

            invalidAddrShort.Zip = new string('1', 4);
            invalidAddrLong.Zip = new string('1', 6);
            invalidAddrMissing.Zip = null;
            invalidAddrFormat.Zip = new string('*', 5);

            Assert.True(HelperFunctions.Validate(validAddr));
            Assert.False(HelperFunctions.Validate(invalidAddrShort));
            Assert.False(HelperFunctions.Validate(invalidAddrLong));
            Assert.False(HelperFunctions.Validate(invalidAddrMissing));
            Assert.False(HelperFunctions.Validate(invalidAddrFormat));
        }

        [Fact]
        public void isState_Restricted_To_2Characters_And_Required()
        {
            var validAddr = HelperData.Address();
            var invalidAddrShort = HelperData.Address();
            var invalidAddrLong = HelperData.Address();
            var invalidAddrMissing = HelperData.Address();
            var invalidAddrFormat = HelperData.Address();

            invalidAddrShort.State = new string("A");
            invalidAddrLong.State = new string('A', 3);
            invalidAddrMissing.State = null;
            invalidAddrFormat.State = new string("2A");

            Assert.True(HelperFunctions.Validate(validAddr));
            Assert.False(HelperFunctions.Validate(invalidAddrShort));
            Assert.False(HelperFunctions.Validate(invalidAddrLong));
            Assert.False(HelperFunctions.Validate(invalidAddrMissing));
            Assert.False(HelperFunctions.Validate(invalidAddrFormat));
        }


    }
}
