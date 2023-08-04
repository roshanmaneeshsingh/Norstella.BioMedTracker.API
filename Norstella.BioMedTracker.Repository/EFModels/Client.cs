using System.ComponentModel.DataAnnotations;

namespace BioMedTracker.Repository.EFModels
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int? CopyFromClientId { get; set; }
    }
}
