using MongoRepo.Context;

namespace CateLogApi.Context
{
    public class CatelogDbContext : ApplicationDbContext
    {
        static IConfiguration configureation = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();
        static string connectionString = configureation.GetConnectionString("CateLog.Api");
        static string databaseName = configureation.GetValue<string>("DatabaseName");
        public CatelogDbContext() : base(connectionString, databaseName)
        {
        }
    }
}
