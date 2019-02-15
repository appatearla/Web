using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace API
{
    public static class Teams
    {
        [FunctionName("Teams_GetAll")]
        public static async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/teams")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var principal = await SecurityHelper.ValidateTokenAsync(req);

            if (principal == null)
            {
                return new UnauthorizedResult();
            }

            return new OkObjectResult(string.Empty);
        }

        [FunctionName("Teams_Get")]
        public static async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/teams/{id}")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var principal = await SecurityHelper.ValidateTokenAsync(req);

            if (principal == null)
            {
                return new UnauthorizedResult();
            }

            return new OkObjectResult(string.Empty);
        }

        [FunctionName("Teams_Post")]
        public static async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/teams")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var principal = await SecurityHelper.ValidateTokenAsync(req);

            if (principal == null)
            {
                return new UnauthorizedResult();
            }

            return new OkObjectResult(string.Empty);
        }

        [FunctionName("Teams_Put")]
        public static async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "api/teams/{id}")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var principal = await SecurityHelper.ValidateTokenAsync(req);

            if (principal == null)
            {
                return new UnauthorizedResult();
            }

            return new OkObjectResult(string.Empty);
        }

        [FunctionName("Teams_Delete")]
        public static async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "api/teams/{id}")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var principal = await SecurityHelper.ValidateTokenAsync(req);

            if (principal == null)
            {
                return new UnauthorizedResult();
            }

            return new OkObjectResult(string.Empty);
        }
    }
}
