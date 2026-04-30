namespace VehicleManager.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    public Task<bool> GetByEmail(string email);
}