using Microsoft.AspNetCore.Mvc;
using BioMedTracker.Api.Models;
using BioMedTracker.Shared.Models;
using System;

namespace BioMedTracker.Api.Controllers
{
    public class CCControllerBase : ControllerBase
    {
        public CCControllerBase()
        {
        }

        public CCApiResponse<T> GetResponse<T>(T Data) 
        {
            CCApiResponse<T> ret = new CCApiResponse<T>(Data);
            return ret;
        }

        public CCApiResponse<T> GetResponse<T>(Exception exception)
        {
            CCApiResponse<T> ret = new CCApiResponse<T>(exception);
            return ret;
        }

        public CCApiResponse<T> GetResponse<T>(string error)
        {
            CCApiResponse<T> ret = new CCApiResponse<T>(error);
            return ret;
        }

        protected CCApiResponse<bool> BuildValidationResponse(ValidationResponse response)
        {
            if (response.Success)
            {
                return GetResponse(true);
            }
            else
            {
                return GetResponse<bool>(response.Message);
            }
        }
    }
}
