namespace TransportForLondon.RoadStatusChecker.Services
{
    using System.Net;
    using TransportForLondon.RoadStatusChecker.Exceptions;
    using TransportForLondon.RoadStatusChecker.Helper;
    using TransportForLondon.RoadStatusChecker.Model;

    public class TflApiService : ITflApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TflApiSettings _apiSettings;

        public TflApiService(HttpClient httpClient, TflApiSettings apiSettings)
        {
            Guard.AgainstNull(httpClient, nameof(httpClient));
            Guard.AgainstNull(apiSettings, nameof(apiSettings));

            _httpClient = httpClient;
            _apiSettings = apiSettings;
        }

        public async Task<RoadStatus> GetRoadStatusAsync(string roadId)
        {
            string apiUrl = ApiHelper.BuildApiUrl(_apiSettings, roadId);

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var roadStatus = (await response.Content.ReadAsAsync<RoadStatus[]>()).FirstOrDefault();
                return roadStatus;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new RoadNotFoundException(roadId);
            }
            else
            {
                throw new ApiException(Constants.ErrorFetchingRoadStatusMessage);
            }
        }
    }
}
