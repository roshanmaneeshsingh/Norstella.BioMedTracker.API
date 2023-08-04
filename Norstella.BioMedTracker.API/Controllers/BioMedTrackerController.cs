using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BioMedTracker.Api.Controllers;
using BioMedTracker.Api.Models;
using BioMedTracker.Service.Interfaces;
using BioMedTracker.Shared.Models;
using System;
using System.Threading.Tasks;


namespace BioMedTracker.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("BioMedTracker/v1/Trials")]
    [Produces("application/json")]
    public class BioMedTrackerController : CCControllerBase
    {
        private readonly IBioMedTrackerService _bioMedTrackerService;

        public BioMedTrackerController(IBioMedTrackerService bioMedTrackerService) : base()
        {
            _bioMedTrackerService = bioMedTrackerService;
        }

        [HttpGet, Route("drugs")]
        public async Task<CCApiResponse<Drug[]>> GetAllDrugs()
        {
            try
            {
                Drug[] ret = await _bioMedTrackerService.GetAllDrugs();
                return GetResponse(ret);
            }
            catch (Exception e)
            {
                return GetResponse<Drug[]>(e);
            }
        }

        [HttpGet, Route("drugIndications")]
        public async Task<CCApiResponse<DrugIndication[]>> GetAllDrugIndications()
        {
            try
            {
                DrugIndication[] ret = await _bioMedTrackerService.GetAllDrugIndications();
                return GetResponse(ret);
            }
            catch (Exception e)
            {
                return GetResponse<DrugIndication[]>(e);
            }
        }

        [HttpGet, Route("trialsData/{drugIdFrom}/{drugIdCompareTo}")]
        public async Task<CCApiResponse<TrialDataNetRow[]>> GetTrialsData(int drugIdFrom, int drugIdCompareTo)
        {
            try
            {
                TrialDataNetRow[] ret = await _bioMedTrackerService.GetTrialsData(drugIdFrom, drugIdCompareTo);
                return GetResponse(ret);
            }
            catch (Exception e)
            {
                return GetResponse<TrialDataNetRow[]>(e);
            }
        }

        [HttpGet, Route("GetDrugsIndicationWithSubIndication/{drugIdFrom}/{drugIdCompareTo}")]
        public async Task<CCApiResponse<DrugsIndicationWithSubIndication[]>> GetDrugsIndicationWithSubIndication(int drugIdFrom, int drugIdCompareTo)
        {
            try
            {
                DrugsIndicationWithSubIndication[] ret = await _bioMedTrackerService.GetDrugsIndicationWithSubIndication(drugIdFrom, drugIdCompareTo);
                return GetResponse(ret);
            }
            catch (Exception e)
            {
                return GetResponse<DrugsIndicationWithSubIndication[]>(e);
            }
        }

        [HttpGet, Route("GetDrugEventsWithTrail/{drugId}/{indicationId}")]
        public async Task<CCApiResponse<DrugEventsWithTrail[]>> GetDrugEventsWithTrail(int drugId, int indicationId)
        {
            try
            {
                DrugEventsWithTrail[] ret = await _bioMedTrackerService.GetDrugEventsWithTrail(drugId, indicationId);
                return GetResponse(ret);
            }
            catch (Exception e)
            {
                return GetResponse<DrugEventsWithTrail[]>(e);
            }
        }
        [HttpGet, Route("GetTrailDataDescription/{fromTrialDataID}/{toTrialDataID}/{description}")]
        public async Task<CCApiResponse<TrailDataDescription[]>> GetTrailDataDescription(int fromTrialDataID, int toTrialDataID, string description)
        {
            try
            {
                TrailDataDescription[] ret = await _bioMedTrackerService.GetTrailDataDescription(fromTrialDataID, toTrialDataID, description);
                return GetResponse(ret);
            }
            catch (Exception e)
            {
                return GetResponse<TrailDataDescription[]>(e);
            }
        }

        [HttpGet, Route("GetTrailData/{trialDataID}")]
        public async Task<CCApiResponse<TrailDataDetails[]>> GetTrailData(int trialDataID)
        {
            try
            {
                TrailDataDetails[] ret = await _bioMedTrackerService.GetTrailData(trialDataID);
                return GetResponse(ret);
            }
            catch (Exception e)
            {
                return GetResponse<TrailDataDetails[]>(e);
            }
        }

        [HttpGet, Route("GetTrailDataDescriptionDetails/{trialDescIDFrom}/{trialDescIDTo}")]
        public async Task<CCApiResponse<TrailDataDescriptionDetails[]>> GetTrailDataDescriptionDetails(int trialDescIDFrom, int trialDescIDTo)
        {
            try
            {
                TrailDataDescriptionDetails[] ret = await _bioMedTrackerService.GetTrailDataDescriptionDetails(trialDescIDFrom, trialDescIDTo);
                return GetResponse(ret);
            }
            catch (Exception e)
            {
                return GetResponse<TrailDataDescriptionDetails[]>(e);
            }
        }
        [HttpGet, Route("GetTrailInfo/{drugID}/{indicationID}")]
        public async Task<CCApiResponse<TrailInfo[]>> GetTrailInfo(int drugID, int indicationID)
        {
            try
            {
                TrailInfo[] ret = await _bioMedTrackerService.GetTrailInfo(drugID, indicationID);
                return GetResponse(ret);
            }
            catch (Exception e)
            {
                return GetResponse<TrailInfo[]>(e);
            }
        }

    }
}