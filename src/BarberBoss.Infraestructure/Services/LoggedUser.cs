using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Users;
using BarberBoss.Infraestructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BarberBoss.Infraestructure.Services
{
    public class LoggedUser : ILoggedUser
    {
        private readonly BarberBossDbContext _dbContext;

        public LoggedUser(BarberBossDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<User> Get()
        {
            var token = "teste";

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadJwtToken(token);

            var userIdentifier =  securityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

            return _dbContext.User.AsNoTracking().FirstAsync(user => user.UserIdentifier == Guid.Parse(userIdentifier));
        }
    }
}
