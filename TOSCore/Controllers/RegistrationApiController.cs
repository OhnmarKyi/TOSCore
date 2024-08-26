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
        {
            return await _service.GetGroupView();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("GetBrandList")]
        public async Task<List<MBrand>> GetBrandList()
        {            
            return await _service.GetBrand();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("GetCompanyList")]
        public async Task<List<MCompany>> GetCompanyList()
        {
            return await _service.GetCompany();
        }
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost("InsertGroupEntry")]
        public string InsertGroupEntry(GroupModel group)
        {
           return _service.InsertGroupEntry(group);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("GetGroupData")]
        public GroupModel GetGroupData(string id )
        {
            return  _service.GetGroupData(id);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("UpdateGroupEntry")]
        public string UpdateGroupEntry(GroupModel group)
        {
            return _service.UpdateGroupEntry(group);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost("InsertCompany")]
        public async Task<string> InsertCompany(M_CompanyModel model)
        {
            return await _service.InsertCompany(model);
            //return true;
        }


    }
}
