namespace TransportForLondon.RoadStatusChecker.Services
{
    using TransportForLondon.RoadStatusChecker.Model;

    public interface ITflApiService
    {
        Task<RoadStatus> GetRoadStatusAsync(string roadId);
    }
}
