using VehicleManager.Domain.Repositories;

namespace VehicleManager.Infrastructure.DataAccess;

public class UnityOfWork : IUnityOfWork
{
    private readonly VehicleManagerDbContext _dbContext;
    public UnityOfWork(VehicleManagerDbContext dbContext) { _dbContext = dbContext; }
    
    public async Task CommitAsync() =>  await _dbContext.SaveChangesAsync();
}