using System.Runtime.Serialization.Formatters.Binary;
#pragma warning disable SYSLIB0011

namespace Assignment_2.Data
{
    internal class ReservationManager
    {

        private List<Reservation> _reservations = new List<Reservation>();
        private Random _random = new Random();

        public void AddReservation(Reservation reservation)
        {
            _reservations.Add(reservation);
        }
        private string GenerateReservationCode()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            return $"{letters[_random.Next(letters.Length)]}" +
                   $"{digits[_random.Next(digits.Length)]}" +
                   $"{digits[_random.Next(digits.Length)]}" +
                   $"{digits[_random.Next(digits.Length)]}" +
                   $"{digits[_random.Next(digits.Length)]}";
        }

        public Reservation makeReservation(Flight flight, string firstName, string lastName, string citizenship)
        {
            if (flight == null)
            {
                throw new ArgumentException("No flight selected");
            }
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Name field is empty");
            }
            if (string.IsNullOrWhiteSpace(citizenship))
            {
                throw new ArgumentException("Citizenship field is empty");
            }

            string reservationCode = GenerateReservationCode();

            Reservation newReservation = new Reservation(
                flight.Airline,
                flight.Day,
                flight.Time,
                flight.Price,
                firstName,
                lastName,
                citizenship,
                reservationCode,
                ReservationStatus.Active
            );

            AddReservation(newReservation);

            return newReservation;
        }


        public List<Reservation> FindReservations(string? reservationCode = null, string? airline = null, string? firstName = null, string? lastName = null)
        {
            return _reservations.Where(reservation =>
                (string.IsNullOrEmpty(reservationCode) || reservation.ReservationCode.Equals(reservationCode, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(airline) || reservation.Airline.Equals(airline, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(firstName) || reservation.FirstName.Equals(firstName.Trim(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(lastName) || reservation.LastName.Equals(lastName.Trim(), StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }

        public void UpdateReservation(string reservationCode, string firstName, string lastName, string citizenship, ReservationStatus status)
        {

            var reservationToUpdate = _reservations.FirstOrDefault(reservation => reservation.ReservationCode.Equals(reservationCode, StringComparison.OrdinalIgnoreCase));

            if (reservationToUpdate == null)
            {
                throw new InvalidReservationDataException($"No reservation found with code: {reservationCode}");
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new InvalidReservationDataException("First name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new InvalidReservationDataException("Last name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(citizenship))
            {
                throw new InvalidReservationDataException("Citizenship cannot be empty.");
            }

            reservationToUpdate.FirstName = firstName;
            reservationToUpdate.LastName = lastName;
            reservationToUpdate.Citizenship = citizenship;
            reservationToUpdate.Status = status;

            SaveReservations();
        }
        public void SaveReservations()
        {
            // Path to your binary file
            string filePath = "reservations.bin";

            // Create a BinaryFormatter and FileStream to write to the file
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Serialize the reservations list to the file
                formatter.Serialize(fs, _reservations);
            }
        }

        public void LoadReservations()
        {
            string filePath = "reservations.bin";

            // Check if the file exists to avoid FileNotFoundException
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    // Deserialize the list from the file
                    _reservations = (List<Reservation>)formatter.Deserialize(fs);
                }
            }
            else
            {
                // Initialize with an empty list if the file does not exist
                _reservations = new List<Reservation>();
            }
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
