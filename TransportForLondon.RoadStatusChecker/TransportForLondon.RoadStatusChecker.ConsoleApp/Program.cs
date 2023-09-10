namespace TransportForLondon.RoadStatusChecker
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TransportForLondon.RoadStatusChecker.Model;
    using TransportForLondon.RoadStatusChecker.Services;

    internal class Program
    {
        private static IConfigurationRoot Configuration { get; set; }

        private static async Task Main(string[] args)
        {
            InitialiseConfiguration();

            var serviceProvider = ConfigureServices();
            var roadStatusChecker = serviceProvider.GetRequiredService<RoadInfoProvider>();

            var exitCode = await roadStatusChecker.RunAsync(args);

            Environment.Exit(exitCode);
        }

        private static void InitialiseConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static IServiceProvider ConfigureServices()
        {
            var apiSettings = Configuration.GetSection("TflApiSettings").Get<TflApiSettings>();
            var services = new ServiceCollection();

            // Register services
            services.AddScoped<RoadInfoProvider>();
            services.AddSingleton(apiSettings);
            services.AddHttpClient<ITflApiService, TflApiService>();

            // Build the service provider
            return services.BuildServiceProvider();
        }
    }
}