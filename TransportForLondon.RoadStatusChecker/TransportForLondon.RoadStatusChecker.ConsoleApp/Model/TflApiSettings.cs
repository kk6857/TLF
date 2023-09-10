namespace TransportForLondon.RoadStatusChecker.Model
{
    using System.ComponentModel.DataAnnotations;

    public class TflApiSettings
    {
        [Required]
        public string BaseUrl { get; set; }

        [Required]
        public string Endpoint { get; set; }

        [Required]
        public string AppId { get; set; }

        [Required]
        public string AppKey { get; set; }
    }
}
