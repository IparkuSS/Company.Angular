using Company.BLL.DataTransferObjects.CompanyDto;
using Company.BLL.Services.Contracts;
using Company.Logger.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly ICompanyServices _companyService;
        public CompanyController(ILoggerManager logger, ICompanyServices companyService)
        {
            _companyService = companyService;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCompany()
        {
            throw new Exception();
            var companyDto = await _companyService.GetAllCompany();
            return Ok(companyDto);
        }

        [HttpGet("{id}", Name = "CompanyById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var companyDto = await _companyService.GetCompany(id);
            if (companyDto == null)
            {
                _logger.LogError($"company with id: {id} doesn't exist");
                return NotFound($"company with id: {id} doesn't exist");
            }
            return Ok(companyDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {
            if (company == null)
            {
                _logger.LogError("CompanyForCreationDto object is null");
                return BadRequest("CompanyForCreationDto object is null");
            }
            var companyDto = await _companyService.CreateCompany(company);
            return NoContent();
        }

        /// <summary>
        /// Deletes a section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            var companyDto = await _companyService.DeleteCompany(id);
            if (companyDto == false)
            {
                _logger.LogError("companyDto object is null");
                return BadRequest("companyDto object is null");
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            if (company == null)
            {
                _logger.LogError("company object sent from client is null.");
                return BadRequest("company object is null");
            }
            var companyDto = await _companyService.UpdateCompany(id, company);
            if (companyDto == false)
            {
                _logger.LogInfo($"companyDto with id: {id} doesn't exist.");
                return NotFound($"companyDto with id: {id} doesn't exist");
            }
            return NoContent();
        }

    }
}
