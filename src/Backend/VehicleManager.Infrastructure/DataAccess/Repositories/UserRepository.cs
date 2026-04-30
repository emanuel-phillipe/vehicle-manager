using Microsoft.EntityFrameworkCore;
using VehicleManager.Domain.Entities;
using VehicleManager.Domain.Repositories.User;

namespace VehicleManager.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly VehicleManagerDbContext _dbContext;
    public UserRepository(VehicleManagerDbContext dbContext) { _dbContext = dbContext; }

    public async Task Add(User user) => await _dbContext.Users.AddAsync(user);
    public async Task<bool> GetByEmail(string email) => await _dbContext.Users.AnyAsync(user => user.Email == email);   
}