namespace VehicleManager.Communication.Requests;

public class RequestRegisterUserJson
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Cpf  { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string CnhNum { get; set; } = string.Empty;
    public string[] CnhCategories { get; set; } = Array.Empty<string>();
    public string CnhDueDate { get; set; } = string.Empty;
}