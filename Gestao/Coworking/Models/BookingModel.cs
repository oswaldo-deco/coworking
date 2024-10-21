using System; // Para DateTime

public class BookingModel {
    public int Id { get; set; } // Identificador único do booking
    public string Users { get; set; } // Armazena o nome do usuário que fez a reserva
    public DateTime Date { get; set; } // Representa a data e a hora da reserva

    // Construtor opcional, se necessário
    public BookingModel() {
        // Inicializações, se necessárias
    }
}
