namespace BioMedTracker.Shared.Models
{
    public class DrugsIndicationWithSubIndication
    {
        public int IndicationID { get; set; }
        public string IndicationName { get; set; }
        public int SubIndicationID { get; set; }
        public string SubIndicationName { get; set; }
        public int SubSubIndicationID { get; set; }
        public string SubSubIndicationName { get; set; }
        //  public int DrugID { get; set; }
    }
}
