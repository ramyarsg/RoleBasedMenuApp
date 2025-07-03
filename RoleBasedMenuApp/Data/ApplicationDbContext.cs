using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoleBasedMenuApp.Models;

namespace RoleBasedMenuApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add your DbSets here if needed
        // public DbSet<TaskItem> Tasks { get; set; }

        public DbSet<ErrorViewModel> ErrorViewModel { get; set; }
    }
}



