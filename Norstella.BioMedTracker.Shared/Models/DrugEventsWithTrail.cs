namespace BioMedTracker.Shared.Models
{
    public class DrugEventsWithTrail
    {
        public int RecordID { get; set; }
        public int TrialDataID { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
    }
}
