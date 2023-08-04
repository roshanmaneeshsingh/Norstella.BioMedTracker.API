using BioMedTracker.Shared.Models;
using System.Threading.Tasks;

namespace BioMedTracker.Repository.Interfaces
{
    public interface IBioMedTrackerRepository
    {
        Task<Drug[]> GetAllDrugs();
        Task<DrugIndication[]> GetAllDrugIndications();
        Task<TrialDataNetRow[]> GetTrialsData(int drugIdFrom, int drugIdCompareTo);
        Task<DrugsIndicationWithSubIndication[]> GetDrugsIndicationWithSubIndication(int drugIdFrom, int drugIdCompareTo);
        Task<DrugEventsWithTrail[]> GetDrugEventsWithTrail(int drugId, int indicationId);
    }
}
