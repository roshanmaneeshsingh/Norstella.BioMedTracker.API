namespace BioMedTracker.Shared.Models
{
    public partial class DrugEvent
    {
        public int RecordId { get; set; }

        public int? DrugId { get; set; }

        public int? IndicationId { get; set; }

        public int? EventTypeId { get; set; }

        public DateTime? EventDate { get; set; }

        public string TrialId { get; set; }

    }
}
