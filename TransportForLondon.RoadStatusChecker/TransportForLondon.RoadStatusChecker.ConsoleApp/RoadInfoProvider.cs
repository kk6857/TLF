namespace TransportForLondon.RoadStatusChecker
{
    using TransportForLondon.RoadStatusChecker.Exceptions;
    using TransportForLondon.RoadStatusChecker.Services;

    public class RoadInfoProvider
    {
        private readonly ITflApiService _apiService;

        public RoadInfoProvider(ITflApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<int> RunAsync(string[] args)
        {
            try
            {
                string roadId = GetRoadIdFromArgs(args);

                var roadStatus = await _apiService.GetRoadStatusAsync(roadId);

                Console.WriteLine(string.Format(Constants.StatusMessageFormat, roadStatus.DisplayName));
                Console.WriteLine(string.Format(Constants.RoadStatusMessageFormat, roadStatus.StatusSeverity));
                Console.WriteLine(string.Format(Constants.StatusDescriptionMessageFormat, roadStatus.StatusSeverityDescription));

                return 0;
            }
            catch (RoadNotFoundException ex)
            {
                Console.WriteLine(string.Format(Constants.InvalidRoadMessage, ex.RoadId));
                return 1;
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }

        private string GetRoadIdFromArgs(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine(Constants.ProvideRoadIdMessage);
                Environment.Exit(1);
            }

            return args[0];
        }

    }
}
