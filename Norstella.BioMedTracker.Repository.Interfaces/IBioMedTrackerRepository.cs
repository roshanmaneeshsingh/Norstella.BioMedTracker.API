using BioMedTracker.Shared.Models;
using System.Threading.Tasks;

namespace BioMedTracker.Repository.Interfaces
{
    public interface IBioMedTrackerRepository
    {
        Task<Client> GetClientAsync(int clientId);
        Task<Feature[]> GetFeaturesAsync();
        Task<Drug[]> GetAllDrugs();
        Task<DrugIndication[]> GetAllDrugIndications();
        Task<TrialDataNetRow[]> GetTrialsData(int drugIdFrom, int drugIdCompareTo);
    }
}
