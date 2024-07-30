// using Microsoft.AspNetCore.Identity;
// using Microsoft.Extensions.DependencyInjection;
// using System;
// using System.Threading.Tasks;
//
// public class DataSeeder
// {
//     public static async Task SeedRoles(IServiceProvider serviceProvider)
//     {
//         var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//
//         string[] roleNames = { "Admin", "Customer" };
//         IdentityResult roleResult;
//
//         foreach (var roleName in roleNames)
//         {
//             var roleExist = await roleManager.RoleExistsAsync(roleName);
//             if (!roleExist)
//             {
//                 roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
//             }
//         }
//     }
//
//     public static async Task SeedAdminUser(IServiceProvider serviceProvider)
//     {
//         var userManager = serviceProvider.GetRequiredService<UserManager<Customer>>();
//
//         var adminUser = new Customer
//         {
//             UserName = "admin@admin.com",
//             Email = "admin@admin.com",
//             FirstName = "Admin",
//             LastName = "User",
//             PhoneNumber = "1234567890"
//         };
//
//         var user = await userManager.FindByEmailAsync(adminUser.Email);
//         if (user == null)
//         {
//             var createPowerUser = await userManager.CreateAsync(adminUser, "Admin@123");
//             if (createPowerUser.Succeeded)
//             {
//                 await userManager.AddToRoleAsync(adminUser, "Admin");
//             }
//         }
//     }
// }