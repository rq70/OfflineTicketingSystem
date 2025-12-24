using Microsoft.EntityFrameworkCore;
using OfflineTicketingSystem.Application.Interfaces;
using OfflineTicketingSystem.Domain.Entities;
using OfflineTicketingSystem.Infrastructure.DBContext;

namespace OfflineTicketingSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u =>  u.Email == email);
        }
    }
}
