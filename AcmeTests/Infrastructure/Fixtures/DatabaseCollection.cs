namespace AcmeTests.Integration.Fixtures
{
    using Xunit;

    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
    }
}
