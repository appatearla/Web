using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace API
{
    public static class Matchs
    {
        [FunctionName("Matchs_GetAll")]
        public static async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/matchs")] HttpRequest req,
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

        [FunctionName("Matchs_Get")]
        public static async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/matchs/{id}")] HttpRequest req,
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

        [FunctionName("Matchs_Post")]
        public static async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/matchs")] HttpRequest req,
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

        [FunctionName("Matchs_Put")]
        public static async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "api/matchs/{id}")] HttpRequest req,
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

        [FunctionName("Matchs_Delete")]
        public static async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "api/matchs/{id}")] HttpRequest req,
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
