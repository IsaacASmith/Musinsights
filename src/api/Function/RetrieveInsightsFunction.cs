using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
using UseCases;
using UseCases.Enums;
using MusicProvider.Auth;
using Function.ViewModels;

namespace Functions
{
    public class RetrieveInsightsFunction
    {
        private readonly IAuthenticationManager _authManager;
        private readonly IRetrieveInsightsUseCase _retrieveInsightsUseCase;

        private const string AccessTokenKey = "AccessToken";
        private const string UserIdKey = "UserId";
        private const string TimeRangeKey = "TimeRange";

        public RetrieveInsightsFunction(IAuthenticationManager authManager, IRetrieveInsightsUseCase retrieveInsightsUseCase)
        {
            _authManager = authManager;
            _retrieveInsightsUseCase = retrieveInsightsUseCase;
        }

        [FunctionName("RetrieveInsights")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest req, ILogger log)
        {
            log.LogInformation("---==--- Started RetrieveInsights ---==---\n\n");

            try
            {
                if (!req.Headers.ContainsKey(AccessTokenKey))
                {
                    return new BadRequestObjectResult("Access token is missing from request.");
                }
                if (!req.Query.ContainsKey(UserIdKey))
                {
                    return new BadRequestObjectResult("UserId is missing from request.");
                }

                _authManager.SetAccessToken(req.Query[UserIdKey], req.Headers[AccessTokenKey]);

                var useCaseResult = await _retrieveInsightsUseCase.GetInsights(req.Query[UserIdKey]);

                if (!useCaseResult.Success)
                {
                    return new BadRequestObjectResult($"An error ocurred: {useCaseResult.Message}");
                }

                log.LogInformation("---==--- Completed RetrieveInsights ---==---\n");
                return new JsonResult(new RetrieveInsightsViewModel(useCaseResult));
            }
            catch (FailedAuthenticationException)
            {
                log.LogWarning("Authentication failed.");
                return new UnauthorizedResult();
            }
            catch (Exception ex)
            {
                log.LogError(ex, "--- RetrieveInsights threw an uncaught exception ---");
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

        }
    }
}
