namespace API.Models;

public class Payment
{
    public Payment()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }
    public string? Id { get; set; }
    public double Valor { get; set; }
    public string? status { get; set; }
    public DateTime CriadoEm { get; set; }
    public User? user { get; set; }
}