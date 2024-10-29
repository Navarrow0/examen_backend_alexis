using examen_backend_alexis.Application.Interfaces;
using examen_backend_alexis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace examen_backend_alexis.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User usuario)
        {
            await _context.Users.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User usuario)
        {
            _context.Users.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario != null)
            {
                _context.Users.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }



    }
}
