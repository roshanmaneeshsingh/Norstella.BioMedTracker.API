using BioMedTracker.Shared.Models;

namespace BioMedTracker.Service.Interfaces
{
    public interface IBioMedTrackerService
    {
        Task<Drug[]> GetAllDrugs();
        Task<DrugIndication[]> GetAllDrugIndications();
        Task<DrugEventsWithTrail[]> GetDrugEventsWithTrail(int drugId, int indicationId);
        Task<TrialDataNetRow[]> GetTrialsData(int drugIdFrom, int drugIdCompareTo);
        Task<DrugsIndicationWithSubIndication[]> GetDrugsIndicationWithSubIndication(int drugIdFrom, int drugIdCompareTo);
        Task<TrailDataDescription[]> GetTrailDataDescription(int fromTrialDataID, int toTrialDataID, string description);
        Task<TrailDataDetails[]> GetTrailData(int trialDataID);
        Task<TrailDataDescriptionDetails[]> GetTrailDataDescriptionDetails(int trialDescIDFrom, int trialDescIDTo);
    }
}
