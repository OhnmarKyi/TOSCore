using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TOSCore.Models;
using TOSCore.Services;

namespace TOSCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TInformationApiController : ControllerBase
    {
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("GetInformation")]
        public async Task<List<TInformationModel>> GetInformation(string CompanyCD)
        {
            TInformationService _service = new TInformationService();
            return await _service.GetInformation(CompanyCD);
        }
    }
}
