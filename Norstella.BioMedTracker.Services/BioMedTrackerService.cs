using BioMedTracker.Service.Interfaces;
using BioMedTracker.Shared.Models;
using BioMedTracker.Repository.Interfaces;


namespace BioMedTracker.Services
{
    public class BioMedTrackerService : IBioMedTrackerService
    {
        private readonly IBioMedTrackerRepository _bioMedTrackerRepository;

        public BioMedTrackerService(IBioMedTrackerRepository bioMedTrackerRepository)
        {
            _bioMedTrackerRepository = bioMedTrackerRepository;
        }

        public async Task<Drug[]> GetAllDrugs()
        {
            Drug[] result = await _bioMedTrackerRepository.GetAllDrugs();
            return result;
        }

        public async Task<DrugIndication[]> GetAllDrugIndications()
        {
            DrugIndication[] result = await _bioMedTrackerRepository.GetAllDrugIndications();
            return result;
        }

        public async Task<TrialDataNetRow[]> GetTrialsData(int drugIdFrom, int drugIdCompareTo)
        {
            TrialDataNetRow[] result = await _bioMedTrackerRepository.GetTrialsData(drugIdFrom, drugIdCompareTo);
            return result;
        }

        public async Task<DrugsIndicationWithSubIndication[]> GetDrugsIndicationWithSubIndication(int drugIdFrom, int drugIdCompareTo)
        {
            DrugsIndicationWithSubIndication[] result = await _bioMedTrackerRepository.GetDrugsIndicationWithSubIndication(drugIdFrom, drugIdCompareTo);
            return result;
        }
        public async Task<DrugEventsWithTrail[]> GetDrugEventsWithTrail(int drugId, int indicationId)
        {
            DrugEventsWithTrail[] result = await _bioMedTrackerRepository.GetDrugEventsWithTrail(drugId, indicationId);
            return result;
        }
        public async Task<TrailDataDescription[]> GetTrailDataDescription(int fromTrialDataID, int toTrialDataID, string description)
        {
            TrailDataDescription[] result = await _bioMedTrackerRepository.GetTrailDataDescription(fromTrialDataID, toTrialDataID, description);
            return result;
        }
        public async Task<TrailDataDetails[]> GetTrailData(int trialDataID)
        {
            TrailDataDetails[] result = await _bioMedTrackerRepository.GetTrailData(trialDataID);
            return result;
        }

        public async Task<TrailDataDescriptionDetails[]> GetTrailDataDescriptionDetails(int trialDescIDFrom, int trialDescIDTo)
        {
            TrailDataDescriptionDetails[] result = await _bioMedTrackerRepository.GetTrailDataDescriptionDetails(trialDescIDFrom, trialDescIDTo);
            return result;
        }
        public async Task<TrailInfo[]> GetTrailInfo(int drugID, int indicationID)
        {
            TrailInfo[] result = await _bioMedTrackerRepository.GetTrailInfo(drugID, indicationID);
            return result;
        }
    }
}
