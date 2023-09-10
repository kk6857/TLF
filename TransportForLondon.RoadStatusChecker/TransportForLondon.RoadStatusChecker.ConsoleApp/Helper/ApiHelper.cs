namespace TransportForLondon.RoadStatusChecker.Helper
{
    using System.Web;
    using TransportForLondon.RoadStatusChecker.Model;

    public class ApiHelper
    {
        public static string BuildApiUrl(TflApiSettings apiSettings, string roadId)
        {
            Guard.AgainstNullOrWhiteSpace(roadId, nameof(roadId));
            Guard.AgainstNull(apiSettings, nameof(apiSettings));

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("app_id", apiSettings.AppId);
            queryString.Add("app_key", apiSettings.AppKey);

            return $"{apiSettings.BaseUrl}/{apiSettings.Endpoint}/{roadId}?{queryString}";
        }
    }
}
