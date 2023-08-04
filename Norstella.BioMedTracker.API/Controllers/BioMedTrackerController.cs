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
    }
}