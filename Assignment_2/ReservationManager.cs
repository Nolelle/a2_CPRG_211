namespace Assignment_2
{
    internal class ReservationManager
    {
        private List<Reservation> _reservations = new List<Reservation>();

        public void AddReservation(Reservation reservation)
        {
            _reservations.Add(reservation);
        }

        public Reservation makeReservation(Flight flight, string? fullName, string? citizenship)
        {
            if (flight == null) throw new InvalidReservationDataException("Flight cannot be null.");
            // Assuming Flight class has a SeatsAvailable property to check if the flight is fully booked
            if (flight.SeatsAvailable <= 0) throw new FlightFullyBookedException();
            if (string.IsNullOrWhiteSpace(fullName)) throw new InvalidReservationDataException("Traveler's name cannot be empty.");
            if (string.IsNullOrWhiteSpace(citizenship)) throw new InvalidReservationDataException("Citizenship cannot be empty.");

            Reservation newReservation = new Reservation
            {
                ReservationCode = GenerateReservationCode(),
                FlightCode = flight.FlightCode,
                Airline = flight.Airline,
                Cost = flight.Cost,
                Citizenship = citizenship,
                TravelerFullName = fullName,
            };

            AddReservation(newReservation);
            return newReservation;

        }


        public List<Reservation> FindReservations(string? reservationCode = null, string? airline = null, string? travelerFullName = null)
        {
            // If no criteria are provided, return all reservations
            if (string.IsNullOrWhiteSpace(reservationCode) && string.IsNullOrWhiteSpace(airline) && string.IsNullOrWhiteSpace(travelerFullName))
            {
                return _reservations;
            }

            // Filter the reservations based on the provided criteria
            var filteredReservations = _reservations.Where(reservation =>
                (string.IsNullOrWhiteSpace(reservationCode) || reservation.ReservationCode.Equals(reservationCode, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(airline) || reservation.Airline.Equals(airline, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(travelerFullName) || reservation.TravelerFullName.Equals(travelerFullName, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            return filteredReservations;
        }
    }
    public class ReservationException : Exception
    {
        public ReservationException(string message) : base(message) { }
    }

    public class FlightFullyBookedException : ReservationException
    {
        public FlightFullyBookedException() : base("The flight is completely booked.") { }
    }

    public class InvalidReservationDataException : ReservationException
    {
        public InvalidReservationDataException(string message) : base(message) { }
    }

}
