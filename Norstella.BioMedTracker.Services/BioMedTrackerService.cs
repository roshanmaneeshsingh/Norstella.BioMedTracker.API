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

        public async Task<Client> GetClientAsync(int clientId)
        {
            return await _bioMedTrackerRepository.GetClientAsync(clientId);
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
    }
}
