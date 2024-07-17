using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TOSCore.Context;
using TOSCore.Models;
using TOSCore.Services;

namespace TOSCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationApiController : ControllerBase
    {
        RegistrationService _service = new RegistrationService();
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("GetBrandList")]
        public async Task<List<MBrand>> GetBrandList()
        {
            return await _service.GetBrand();
        }
    }
}
