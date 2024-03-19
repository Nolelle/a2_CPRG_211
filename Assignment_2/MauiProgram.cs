using Assignment_2.Data;
using Microsoft.Extensions.Logging;

namespace Assignment_2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            var airportManager = new AirportManager();
            airportManager.LoadAirportsFromFile("C:\\Users\\edm_h\\sait_winter_2024\\CPRG 211 OOP2\\a2_CPRG_211\\Assignment_2\\airports.csv");
            builder.Services.AddSingleton<AirportManager>(airportManager);

            var flightManager = new FlightManager();
            flightManager.LoadFlightsFromCsv("C:\\Users\\edm_h\\sait_winter_2024\\CPRG 211 OOP2\\a2_CPRG_211\\Assignment_2\\flights.csv");
            builder.Services.AddSingleton<FlightManager>(flightManager);

            var reservationManager = new ReservationManager();
            builder.Services.AddSingleton<ReservationManager>(reservationManager);


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
