using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infraestructure.DataAcess.Repository
{
    public class UserRepository : IRegisterUserRepository
    {
        private readonly BarberBossDbContext _dbContext;

        public UserRepository(BarberBossDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(User user)
        {
            await _dbContext.AddAsync(user);
        }
    }
}
