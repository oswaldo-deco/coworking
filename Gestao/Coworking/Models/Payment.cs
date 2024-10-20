namespace API.Models;

public class Payment
{
    public Payment()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
        status = 'em processamento'
    }
    public string? Id { get; set; }
    public string? bookingId { get; set; }
    public string? method { get; set; }
    public double? price { get; set; }
    public string? status { get; set; }
    public DateTime CriadoEm { get; set; }
}