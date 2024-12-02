using Coworking.Models;

public class Booking {
    public string Id { get; set; }
    public User User { get; set; }
    public DateTime CriadoEm { get; set; }
    public Spaces Spaces { get; set; }

    public Booking() {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
        User = new User();
        Spaces = new Spaces();
        
    }
}
