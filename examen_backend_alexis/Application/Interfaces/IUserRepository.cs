using examen_backend_alexis.Domain.Entities;

namespace examen_backend_alexis.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User usuario);
        Task UpdateAsync(User usuario);
        Task DeleteAsync(int id);
    }
}
