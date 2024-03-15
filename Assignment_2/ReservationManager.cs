namespace Assignment_2
{
    internal class ReservationManager
    {
        private List<Reservation> _reservations = new List<Reservation>();

        // Method to add reservations to the list for testing
        public void AddReservation(Reservation reservation)
        {
            _reservations.Add(reservation);
        }

        // FindReservations method
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
}
