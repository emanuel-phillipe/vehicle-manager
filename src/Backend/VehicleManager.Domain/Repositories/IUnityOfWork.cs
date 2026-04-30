namespace VehicleManager.Domain.Repositories;

public interface IUnityOfWork
{
    public Task CommitAsync();
}