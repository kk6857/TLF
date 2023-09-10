namespace TransportForLondon.RoadStatusChecker.Exceptions
{
    using TransportForLondon.RoadStatusChecker.Helper;

    public class RoadNotFoundException : Exception
    {
        public string RoadId { get; }

        public RoadNotFoundException(string roadId)
        {
            Guard.AgainstNullOrWhiteSpace(roadId, nameof(roadId));

            RoadId = roadId;
        }
    }
}
