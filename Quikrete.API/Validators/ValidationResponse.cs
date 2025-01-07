using System.Net;

namespace Quikrete.API.Validators
{
    public class ValidationResponse
    {
        public HttpStatusCode Code { get; set; } = HttpStatusCode.OK;

        public string? Message { get; set; }
    }
}
