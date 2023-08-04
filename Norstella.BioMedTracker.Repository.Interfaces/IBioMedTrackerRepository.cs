using BioMedTracker.Shared.Models;
using System.Threading.Tasks;

namespace BioMedTracker.Repository.Interfaces
{
    public interface IBioMedTrackerRepository
    {
        Task<Drug[]> GetAllDrugs();
        Task<DrugIndication[]> GetAllDrugIndications();
        Task<TrialDataNetRow[]> GetTrialsData(int drugIdFrom, int drugIdCompareTo);
    }
}
