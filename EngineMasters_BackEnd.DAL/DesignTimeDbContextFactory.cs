using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EngineMasters_BackEnd.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EngineMastersContext>
    {
        public EngineMastersContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(basePath, "appsettings.json");

            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException($"The configuration file '{configPath}' was not found.");
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EngineMastersContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlite(connectionString);

            return new EngineMastersContext(builder.Options);
        }
    }
}