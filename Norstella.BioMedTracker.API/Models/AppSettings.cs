using System.Collections.Generic;

namespace BioMedTracker.Api.Models
{
    public class AppSettings
    {
        public List<string> Origins { get; set; }
        public Connection Connection { get; set; }
        public Auth0 Auth0 { get; set; }
    }
}
