namespace Assignment_2.Data
{
    public class AirportManager
    {
        private List<Airport> _airports = new List<Airport>();

        public void AddAirport(Airport airport)
        {
            _airports.Add(airport);
        }

        public void LoadAirportsFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var columns = line.Split(',');

                if (columns.Length >= 2)
                {
                    Airport airport = new Airport(columns[0].Trim(), columns[1].Trim());
                    _airports.Add(airport);
                }
            }
        }
        public List<Airport> GetAirports()
        {
            return _airports;
        }
    }
}
