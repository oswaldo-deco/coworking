using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Models
{
    public class Spaces
    {
        public Spaces()
        {
            Id = Guid.NewGuid(); // Using Guid to generate IDs
            Reservations = new List<Reservation>(); // Initializing the list of reservations
        }

        public Guid Id { get; set; } // Change to Guid
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerHour { get; set; }
        public List<Reservation> Reservations { get; set; }

        public bool ReserveSpace(Reservation reservation)
        {
            // Check if the reservation lasts more than 1 hour
            if ((reservation.EndDate - reservation.StartDate).TotalHours > 1)
            {
                Console.WriteLine("The reservation must last a maximum of 1 hour.");
                return false;
            }

            // Check for overlap with existing reservations
            if (Reservations.Any(r => r.Overlaps(reservation)))
            {
                Console.WriteLine("The space is already reserved at this time.");
                return false; // Not available
            }

            Reservations.Add(reservation);
            return true; // Reservation successful
        }

        public int TotalHoursReservedPerDay(DateTime day)
        {
            return (int)Reservations.Where(r => r.StartDate.Date == day.Date)
                                    .Select(r => (r.EndDate - r.StartDate).TotalHours)
                                    .Sum(); // Total hours reserved in a day
        }
    }

    public class Reservation
    {
        public Guid Id { get; set; } // Change to Guid
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool Overlaps(Reservation otherReservation)
        {
            return StartDate < otherReservation.EndDate && EndDate > otherReservation.StartDate;
        }
    }
}