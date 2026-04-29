namespace VehicleManager.Domain.Entities;

public class Agency
{
    public string Id { get; set; }
    public string Acronym {  get; set; } =  string.Empty;
    public string City {  get; set; } =  string.Empty;
    public string State {  get; set; } = string.Empty;
    public string Cep  {  get; set; } =  string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public bool Active {  get; set; }
    public DateTime CreatedAt {  get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}