using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mapster;
using ServiceEntities = BioMedTracker.Shared.Models;
using ValidationResponse=BioMedTracker.Shared.Models.ValidationResponse;
using BioMedTracker.Repository.EFModels;
using BioMedTracker.Repository.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace BioMedTracker.Repository
{
    public class BioMedTrackerRepository : IBioMedTrackerRepository
    {
        private readonly BioMedTrackerDbContext _dbContext;

        public BioMedTrackerRepository(BioMedTrackerDbContext context)
        {
            _dbContext = context;
        }

        #region Clients

        public async Task<ServiceEntities.Client> GetClientAsync(int clientId)
        {
            Client client = await _dbContext.Clients.AsNoTracking().FirstOrDefaultAsync(t => t.ClientId == clientId);
            if (client == null)
            {
                return null;
            }
            ServiceEntities.Client result = new ServiceEntities.Client
            {
                ClientId = clientId,
                ClientName = client.ClientName,
                CopyFromClientId = client.CopyFromClientId == null ? 0 : client.CopyFromClientId.Value,
            };
            return result;
        }
        
        #endregion

        #region Features
        public async Task<ServiceEntities.Feature[]> GetFeaturesAsync()
        {
            var result = await _dbContext.Features.AsNoTracking().ToListAsync();

            return result.Adapt<ServiceEntities.Feature[]>();
        }
        #endregion

        #region Drugs and Indications
        public async Task<ServiceEntities.Drug[]> GetAllDrugs()
        {
            Drug[] result = await _dbContext.Drugs.AsNoTracking().ToArrayAsync();
            return result.Adapt<ServiceEntities.Drug[]>();
        }

        public async Task<ServiceEntities.DrugIndication[]> GetAllDrugIndications()
        {
            string[] jsonArray = await _dbContext.Database.SqlQuery<string>(@$"select di.RecordID, di.DrugID, di.IndicationID, di.SubIndicationID, di.SubSubIndicationID, i.IndicationName, si.SubIndicationName, ssi.SubSubIndicationName from dbo.DrugIndications di left join dbo.Indications i on di.IndicationID = i.IndicationID left join dbo.SubIndications si on di.SubIndicationID = si.SubIndicationID left join .dbo.SubSubIndications ssi on di.SubSubIndicationID = ssi.SubSubIndicationID for json path").ToArrayAsync();
            string jsonResult = string.Concat(jsonArray);
            return System.Text.Json.JsonSerializer.Deserialize<ServiceEntities.DrugIndication[]>(jsonResult);
        }

        #endregion

        #region Trials Data
        public async Task<ServiceEntities.TrialDataNetRow[]> GetTrialsData(int drugIdFrom, int drugIdCompareTo)
        {
            string[] jsonArray = await _dbContext.Database.SqlQuery<string>(
                
                @$"select distinct
                        de.DrugID,
	                    tdd.TrialDescID,
	                    tdd.TrialDataID,
	                    tdd.Description,
	                    tdd.EffectID,
	                    tdd.EndpointID,
	                    tdd.MeasureTypeID,
	                    tdd.Grp1Measure,
	                    tdd.Grp1Sign,
	                    tdd.Grp1PValue,
	                    tdd.Grp1MeasureValue,
	                    tdd.Grp2Measure,
	                    tdd.Grp2Sign,
	                    tdd.Grp2PValue,
	                    tdd.Grp2MeasureValue,
	                    tdd.Grp3Measure,
	                    tdd.Grp3Sign,
	                    tdd.Grp3PValue,
	                    tdd.Grp3MeasureValue,
	                    tdd.Grp4Measure,
	                    tdd.Grp4Sign,
	                    tdd.Grp4PValue,
	                    tdd.Grp4MeasureValue,
	                    tdd.Grp5Measure,
	                    tdd.Grp5Sign,
	                    tdd.Grp5PValue,
	                    tdd.Grp5MeasureValue,
	                    tdd.Grp6Measure,
	                    tdd.Grp6Sign,
	                    tdd.Grp6PValue,
	                    tdd.Grp6MeasureValue,
	                    tdd.SortOrder
                    from BioMedTracker.dbo.TrialDataDesc tdd
                    left join BioMedTracker.dbo.TrialData td on tdd.TrialDataID = td.TrialDataID 
                    left join BioMedTracker.dbo.DrugEvents de on td.EventID = de.RecordID 
                    where de.DrugID in ({drugIdFrom}, {drugIdCompareTo}) 
                    for json path")
                .ToArrayAsync();
            string jsonResult = string.Concat(jsonArray);
            TrialDataNetRow[] result = System.Text.Json.JsonSerializer.Deserialize<TrialDataNetRow[]>(jsonResult);
            return result.Adapt<ServiceEntities.TrialDataNetRow[]>();
        }
        #endregion

    }
}
