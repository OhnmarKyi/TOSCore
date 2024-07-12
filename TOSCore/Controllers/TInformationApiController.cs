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
    public class TInformationApiController : ControllerBase
    {
        TInformationService _service = new TInformationService();
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("GetInformation")]
        public async Task<List<TInformationModel>> GetInformation(string CompanyCD)
        {            
            return await _service.GetInformation(CompanyCD);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("GetInformationDetails")]
        public async Task<TInformationModel> GetInformationDetails(string id)
        {
            return await _service.GetInformationDetails(id);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("DownloadFile")]
        public IActionResult DownloadFile(string filename)
        {
            var get_allFiles = Directory.GetFiles("C:\\My Data\\Projects\\InformationFiles\\");
            byte[] fileBytes = System.IO.File.ReadAllBytes("C:\\My Data\\Projects\\InformationFiles\\" + filename);
            return File(fileBytes, "application/pdf", filename);
        }
    }
}
