// using EngineMasters_BackEnd.DAL;
// using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EngineMasters_BackEnd.DAL.Interfaces;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EngineMastersContext>
{
    public EngineMastersContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EngineMastersContext>();
        optionsBuilder.UseSqlite("Data Source=RecordsDatabase.db");

        return new EngineMastersContext(optionsBuilder.Options);
    }
}

// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
//
// namespace EngineMasters_BackEnd.DAL.Interfaces
// {
//     public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EngineMastersContext>
//     {
//         EngineMastersContext CreateDbContext(string[] args);
//     }
// }
