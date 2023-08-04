using BioMedTracker.Repository;
using BioMedTracker.Repository.EFModels;
using BioMedTracker.Repository.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ServiceEntities = BioMedTracker.Shared.Models;

namespace BioMedTracker.Repository
{
    public class BioMedTrackerRepository : IBioMedTrackerRepository
    {
        private readonly BioMedTrackerDbContext _dbContext;

        public BioMedTrackerRepository(BioMedTrackerDbContext context)
        {
            _dbContext = context;
        }

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
        #region DrugEventsWithTrail Data
        public async Task<ServiceEntities.DrugEventsWithTrail[]> GetDrugEventsWithTrail(int drugId, int indicationId)
        {
            string[] jsonArray = await _dbContext.Database.SqlQuery<string>(

                @$"select de.RecordID, 
                    td.TrialDataID,
                    et.EventType,
                    de.EventDate 
                    from dbo.DrugEvents de
                    join dbo.TrialData td on de.RecordID = td.EventID 
                    left join dbo.EventTypes et on de. EventTypeID = et.EventTypeID
                    where de. DrugID={drugId} and de.IndicationID = {indicationId}
                    order by de.EventDate desc
                    for json path")
                .ToArrayAsync();
            string jsonResult = string.Concat(jsonArray);
            DrugEventsWithTrail[] result = System.Text.Json.JsonSerializer.Deserialize<DrugEventsWithTrail[]>(jsonResult);
            return result.Adapt<ServiceEntities.DrugEventsWithTrail[]>();
        }
        #endregion

        #region DrugEventsWithTrail Data
        public async Task<ServiceEntities.TrailDataDescription[]> GetTrailDataDescription(int fromTrialDataID, int toTrialDataID, string description)
        {
            string[] jsonArray = await _dbContext.Database.SqlQuery<string>(
                 @$"select
                 tdd. TrialDescID,
                 tdd.Description
                 from dbo.TrialDataDesc tdd 
                 left join dbo.TrialData td on tdd.TrialDataID = td. TrialDataID
                 left join dbo.DrugEvents de on td.EventID=de.RecordID
                 where tdd. TrialDataID in ({fromTrialDataID}, {toTrialDataID}) and
                 (tdd. Description like '%{description}%')
                    for json path")
                .ToArrayAsync();
            string jsonResult = string.Concat(jsonArray);
            TrailDataDescription[] result = System.Text.Json.JsonSerializer.Deserialize<TrailDataDescription[]>(jsonResult);
            return result.Adapt<ServiceEntities.TrailDataDescription[]>();
        }
        #endregion

        #region Drugs Indication With SubIndication DATA
        public async Task<ServiceEntities.DrugsIndicationWithSubIndication[]> GetDrugsIndicationWithSubIndication(int drugIdFrom, int drugIdCompareTo)
        {
            string[] jsonArray = await _dbContext.Database.SqlQuery<string>(

                @$"select distinct i.IndicationID, 
i.IndicationName,
si.SubIndicationID, 
si.SubIndicationName,
ssi.SubSubIndicationID, 
ssi.SubSubIndicationName
from BioMedTracker.dbo.DrugIndications di
left join dbo.Indications i on di.IndicationID = i.IndicationID
left join dbo.SubIndications si on di.SubIndicationID = si.SubIndicationID 
left join dbo.SubSubIndications ssi on di.SubSubIndicationID=ssi.SubSubIndicationID
where DrugID = {drugIdFrom}
intersect
select distinct  i.IndicationID,
i.IndicationName, 
si.SubIndicationID,
si.SubIndicationName, 
ssi.SubSubIndicationID, 
ssi.SubSubIndicationName
from DrugIndications di
left join dbo.Indications i on di.IndicationID = i.IndicationID
left join dbo.SubIndications si on di.SubIndicationID = si.SubIndicationID 
left join dbo.SubSubIndications ssi on di.SubSubIndicationID= ssi.SubSubIndicationID
where DrugID={drugIdCompareTo}
order by i.IndicationID, si.SubIndicationID, ssi.SubSubIndicationID) 
                    for json path")
                .ToArrayAsync();
            string jsonResult = string.Concat(jsonArray);
            DrugsIndicationWithSubIndication[] result = System.Text.Json.JsonSerializer.Deserialize<DrugsIndicationWithSubIndication[]>(jsonResult);
            return result.Adapt<ServiceEntities.DrugsIndicationWithSubIndication[]>();
        }
        #endregion

        #region Trials Data
        public async Task<ServiceEntities.TrailDataDetails[]> GetTrailData(int trialDataID)
        {
            string[] jsonArray = await _dbContext.Database.SqlQuery<string>(

                @$"select
                tdd.Description,
                tdmt.MeasureTypeID,
                (select tdg.TreatDesc from dbo.TrialDataGroup tdg where tdg.TrialDataID=td.TrialDataID and tdg.SortOrder = 1) TreatDesc_O1,
                tdd.Grp1Sign,
                tdd.Grp1Measure,
                (select tdg.TreatDesc from dbo.TrialDataGroup tdg where tdg.TrialDataID = td.TrialDataID and tdg.SortOrder = 2)TreatDesc_O2,
                tdd.Grp2Sign,
                tdd.Grp2Measure,
                (select tdg.TreatDesc from BioMedTracker.dbo.TrialDataGroup tdg where tdg.TrialDataID = td.TrialDataID and tdg.SortOrder = 3)TreatDesc_O3,
                tdd.Grp3Sign,
                tdd.Grp3Measure,
                (select tdg.TreatDesc from dbo.TrialDataGroup tdg where tdg.TrialDataID = td.TrialDataID and tdg.SortOrder = 4) TreatDesc_O4,
                tdd.Grp4Sign,
                tdd.Grp4Measure
                from dbo.TrialDataDesc tdd
                left join dbo.TrialData td on tdd.TrialDataID = td.TrialDataID left join dbo.DrugEvents de on td.EventID=de.RecordID
                left join dbo.TrialDataMeasureType tdmt on tdd.MeasureTypeID= tdmt.MeasureTypeID
                where tdd.TrialDataID={trialDataID}
                for json path")
                .ToArrayAsync();
            string jsonResult = string.Concat(jsonArray);
            TrailDataDetails[] result = System.Text.Json.JsonSerializer.Deserialize<TrailDataDetails[]>(jsonResult);
            return result.Adapt<ServiceEntities.TrailDataDetails[]>();
        }
        #endregion

        #region  GetTrailDataDescriptionDetails
        public async Task<ServiceEntities.TrailDataDescriptionDetails[]> GetTrailDataDescriptionDetails(int trialDescIDFrom, int trialDescIDTo)
        {
            string[] jsonArray = await _dbContext.Database.SqlQuery<string>(

                @$"select
                (select string_agg(t.TrialName, ', ') from dbo.Trials t where t.TrialID in (select value from string_split(de.TrialID, ','))) as TrialName,
                tdd.Description,
                (select tdg.TreatDesc from dbo.TrialDataGroup tdg where tdg.TrialDataID= td.TrialDataID and tdg.SortOrder = 1) TreatDesc_O1,
                (select tdgt.GroupType from dbo.TrialDataGroupType tdgt where tdgt.GroupTypeID= td.Grp1ID) GroupType_O1,
                tdd.Grp1Measure,
                (select tdg.TreatDesc from dbo.TrialDataGroup tdg where tdg.TrialDataID=td.TrialDataID and tdg.SortOrder = 2) TreatDesc_O2,
                (select tdgt.GroupType from dbo.TrialDataGroupType tdgt where tdgt.GroupTypeID = td.Grp2ID) GroupType_O2,
                tdd.Grp2Measure,
                (select tdg.TreatDesc from dbo.TrialDataGroup tdg where tdg.TrialDataID = td.TrialDataID and tdg.SortOrder = 3) TreatDesc_O3,
                (select tdgt.GroupType from dbo.TrialDataGroupType tdgt where tdgt.GroupTypeID= td.Grp3ID) GroupType_O3,
                tdd.Grp3Measure,
                (select tdg.TreatDesc from BioMedTracker.dbo.TrialDataGroup tdg where tdg.TrialDataID = td.TrialDataID and tdg.SortOrder = 4) TreatDesc_O4,
                (select tdgt.GroupType from dbo.TrialDataGroupType tdgt where tdgt.GroupTypeID= td.Grp4ID) GroupType_O4,
                tdd.Grp4Measure
                from dbo.TrialDataDesc tdd
                left join dbo.TrialData td on tdd.TrialDataID = td.TrialDataID
                left join dbo.DrugEvents de on td.EventID=de.RecordID where tdd.TrialDescID in ({trialDescIDFrom}, {trialDescIDTo})
                for json path")
                .ToArrayAsync();
            string jsonResult = string.Concat(jsonArray);
            TrailDataDescriptionDetails[] result = System.Text.Json.JsonSerializer.Deserialize<TrailDataDescriptionDetails[]>(jsonResult);
            return result.Adapt<ServiceEntities.TrailDataDescriptionDetails[]>();
        }
        #endregion

    }
}
