using System;
using System.Collections.Generic;

namespace BioMedTracker.Api.Models
{
    /// <summary>
    /// Common response object for the API.  This is used to wrap the response from the service and return it to the client.
    /// </summary>
    public class CCApiResponse<T>
    {
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Status { get; set; }
        public bool Success { get; set; }

        public CCApiResponse()
        {
            Success = true;
        }

        public CCApiResponse(T obj)
        {
            Success = true;
            Data = obj;
        }

        public CCApiResponse(string error)
        {
            Success = false;
            Status = error;
            Errors = Array.Empty<string>();
        }

        public CCApiResponse(Exception exception)
        {
            Success = false;
            Errors = new string[] { exception.ToString() };
            Status = exception.Message;
        }
    }
}
