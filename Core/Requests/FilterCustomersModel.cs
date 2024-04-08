namespace Core.Requests;

public class FilterCustomersModel
{
    public int? BirthYearFrom { get; set; }
    public int? BirthYearTo { get; set; }
    public int? BankId { get; set; }
    public string? DocumentNumber { get; set; }
    public string? Mail {  get; set; }
    public string? FullName { get; set; }
}