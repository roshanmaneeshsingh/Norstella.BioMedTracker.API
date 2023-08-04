
namespace BioMedTracker.Shared.Models
{
    public class ValidationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ValidationResponse()
        {
            Success = true;
            Message = "";
        }
        public ValidationResponse(string message)
        {
            Success = false;
            Message = message;
        }
    }
}
