namespace TransportForLondon.RoadStatusChecker.Exceptions
{
    using TransportForLondon.RoadStatusChecker.Helper;

    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {
            Guard.AgainstNullOrWhiteSpace(message, nameof(message));
        }
    }
}
