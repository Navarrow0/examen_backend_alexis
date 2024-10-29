using examen_backend_alexis.Application.Interfaces;
using examen_backend_alexis.Domain.Entities;

namespace examen_backend_alexis.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usuarioRepository;

        public UserService(IUserRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(User usuario)
        {
            // Validaciones adicionales si es necesario
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateAsync(User usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }

    }
}
