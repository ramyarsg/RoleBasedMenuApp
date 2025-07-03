using Microsoft.AspNetCore.Identity;

namespace RoleBasedMenuApp.Data
{
    public class DataSeeder
    {
        public static async Task SeedRolesAndAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create Admin user
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminUser, "Admin@123");

                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Create standard User
            var normalUser = await userManager.FindByEmailAsync("user@example.com");
            if (normalUser == null)
            {
                normalUser = new IdentityUser
                {
                    UserName = "user@example.com",
                    Email = "user@example.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(normalUser, "User@123");

                await userManager.AddToRoleAsync(normalUser, "User");
            }
        }
    }
}

