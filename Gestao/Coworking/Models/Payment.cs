using Coworking.Models;

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
    public string? Status { get; set; }
    public DateTime CriadoEm { get; set; }
    public User? User { get; set; }
    public string? UserId { get; set; }
    public string? SpaceId { get; set; }
}