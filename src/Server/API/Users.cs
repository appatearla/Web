using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace API
{
    public static class Users
    {
        [FunctionName("Users_GetAll")]
        public static async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/users")] HttpRequest req,
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

        [FunctionName("Users_Get")]
        public static async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/users/{id}")] HttpRequest req,
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

        [FunctionName("Users_Post")]
        public static async Task<IActionResult> Post(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/users")] HttpRequest req,
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

        [FunctionName("Users_Put")]
        public static async Task<IActionResult> Put(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "api/users/{id}")] HttpRequest req,
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

        [FunctionName("Users_Delete")]
        public static async Task<IActionResult> Delete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "api/users/{id}")] HttpRequest req,
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
