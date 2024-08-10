using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infraestructure.DataAcess.Repository
{
    public class UserRepository : IRegisterUserRepository , IUserReadOnlyRepository
    {
        private readonly BarberBossDbContext _dbContext;

        public UserRepository(BarberBossDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EmailExist(string email)
        {
           return await _dbContext.User.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task Execute(User user)
        {
            await _dbContext.AddAsync(user);
        }
    }
}
