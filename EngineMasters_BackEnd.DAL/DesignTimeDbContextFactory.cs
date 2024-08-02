// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;
// using System.IO;
//
// namespace EngineMasters_BackEnd.DAL
// {
//     public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EngineMastersContext>
//     {
//         public EngineMastersContext CreateDbContext(string[] args)
//         {
//             IConfigurationRoot configuration = new ConfigurationBuilder()
//                 .SetBasePath(Directory.GetCurrentDirectory())
//                 .AddJsonFile("appsettings.json")
//                 .Build();
//
//             var builder = new DbContextOptionsBuilder<EngineMastersContext>();
//             var connectionString = configuration.GetConnectionString("DefaultConnection");
//
//             builder.UseSqlite(connectionString);
//
//             return new EngineMastersContext(builder.Options);
//         }
//     }
// }