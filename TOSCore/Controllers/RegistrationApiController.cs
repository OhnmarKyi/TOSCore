using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Buffers.Text;
using System.Data;
using System.Xml.Linq;
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
        [HttpGet("GetGroupView")]
        public async Task<List<GroupModel>> GetGroupView()
        [HttpGet("GetBrandList")]
        public async Task<List<MBrand>> GetBrandList()
        {
            return await _service.GetGroupView();
            return await _service.GetBrand();
        }
    }
}
