﻿using BioMedTracker.Shared.Models;

namespace BioMedTracker.Service.Interfaces
{
    public interface IBioMedTrackerService
    {
        Task<Drug[]> GetAllDrugs();
        Task<DrugIndication[]> GetAllDrugIndications();
        Task<TrialDataNetRow[]> GetTrialsData(int drugIdFrom, int drugIdCompareTo);
    }
}
