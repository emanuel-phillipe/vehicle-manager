namespace VehicleManager.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    public Task<bool> ExistByEmail(string email);
    public Task<bool> GetByRegisterNum(int registerNum);
}