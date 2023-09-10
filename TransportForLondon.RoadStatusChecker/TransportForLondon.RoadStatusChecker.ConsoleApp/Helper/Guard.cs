namespace TransportForLondon.RoadStatusChecker.Helper
{
    using System.Diagnostics.CodeAnalysis;

    public static class Guard
    {
        public static void AgainstNullOrWhiteSpace([NotNull] string value, string argName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(argName);
            }
        }

        public static void AgainstNull([NotNull] object value, string argName)
        {
            if (value is null)
            {
                throw new ArgumentNullException(argName);
            }
        }
    }
}
