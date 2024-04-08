namespace Core.Requests;

public class CreateBankModel
{
    public string? Name { get; set; } //Obligatorio, no menos de 5 letras
    public string? Phone { get; set; } //Obligatorio
    public string? Mail { get; set; } //Debe ser un mail valido
    public string? Address { get; set; }
}
