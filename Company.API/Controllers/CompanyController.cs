using Company.Logger;
using Company.Logger.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ILoggerManager _logger;

        public CompanyController(ILoggerManager logger)
        {
            _logger = logger;
        }




        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is info message from our values controller."); _logger.LogDebug("Here is debug message from our values controller."); _logger.LogWarn("Here is warn message from our values controller."); _logger.LogError("Here is an error message from our values controller.");

            return new string[] { "value1", "value2" };
        }
    }
}
