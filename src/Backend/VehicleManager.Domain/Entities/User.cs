namespace VehicleManager.Domain.Entities;

public class User
{
    public string Id { get; set; }
    public string FilialId  { get; set; } = string.Empty;
    public bool Active { get; set; } = true;
    public string FullName { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int RegisterNum { get; set; } 
    public string Role { get; set; } = string.Empty;
    public string CnhNum { get; set; } = string.Empty;
    public string[] CnhCategories { get; set; } =  Array.Empty<string>();
    public string CnhDueDate { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}