namespace AcmeDirectorySearch.Infrastructure
{
    /// <summary>
    /// Dependency Injected Connection String bound within
    /// Startup.js for sharing the DB Connection string with
    /// the Repository objects.  Values come from appsettings.json
    /// </summary>
    public class DatabaseOptions
    {
        public string ConnectionString { get; set; }
    }
}
