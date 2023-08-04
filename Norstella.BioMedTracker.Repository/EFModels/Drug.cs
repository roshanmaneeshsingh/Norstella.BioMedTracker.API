using System.ComponentModel.DataAnnotations;

namespace BioMedTracker.Repository.EFModels
{
    public partial class Drug
    {
        public int DrugID { get; set; }
        public string DrugName { get; set; }
        public string BrandName { get; set; }
        public string GenericName { get; set; }
    }
}
