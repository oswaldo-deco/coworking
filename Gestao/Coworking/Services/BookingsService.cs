using API.Models;

private class BookingService {
    public BookingService() {
        // Construtor
    }

    public BookingModel[] GetAll() {
        return BookingRepositories.GetAll(); 
    }
    public BookingModel Create(string userName, DateTime date) {
        BookingModel booking = new BookingModel {
            Users = userName,
            Date = date,
            Id = BookingRepositories.GenerateNewId()
        };

        BookingRepositories.Create(booking);
        return booking;
    }

    public BookingModel Update(string id, string newUserName, DateTime newDate) {
        BookingModel bookingToUpdate = BookingRepositories.GetById(id);

        if (bookingToUpdate != null) {
            bookingToUpdate.Users = newUserName;
            bookingToUpdate.Date = newDate;

            BookingRepositories.UpdateById(id, bookingToUpdate);
            return bookingToUpdate; 
        }

        throw new Exception("Booking não encontrado.");
    }

    public void Delete(string id) {
        BookingRepositories.DeleteById(id);
    }

    public BookingModel GetById(string id) {
        return BookingRepositories.GetById(id); 
    }
}
