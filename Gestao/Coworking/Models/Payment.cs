namespace API.Models;

public class Payment
{
    public Payment()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }
    public string? Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
    public DateTime CriadoEm { get; set; }
}