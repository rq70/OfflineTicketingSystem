using Microsoft.AspNetCore.Identity;
using OfflineTicketingSystem.Domain.Entities;
using OfflineTicketingSystem.Domain.Enums;
using OfflineTicketingSystem.Infrastructure.DBContext;

namespace OfflineTicketingSystem.Infrastructure.Persistence
{
    public static class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (context.Users.Any()) return;

            var hasher = new PasswordHasher<User>();

            var admin = new User
            {
                Id = Guid.NewGuid(),
                FullName = "System Admin",
                Email = "admin@test.com",
                Role = Role.Admin
            };
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

            var employee = new User
            {
                Id = Guid.NewGuid(),
                FullName = "Test Employee",
                Email = "employee@test.com",
                Role = Role.Employee
            };

            employee.PasswordHash = hasher.HashPassword(employee, "Employee123!");

            context.Users.AddRange(admin, employee);
            await context.SaveChangesAsync();
        }
    }
}
