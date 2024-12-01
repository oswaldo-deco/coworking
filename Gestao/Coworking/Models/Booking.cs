
using System;


public class Booking {
    public string Id { get; set; }
    public User User { get; set; }
    public DateTime CriadoEm { get; set; }
    public Space Space { get; set; }

    public Booking() {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }
}
