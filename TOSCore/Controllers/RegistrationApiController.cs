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
        [HttpPost("UpdateGroupEntry")]
        public string UpdateGroupEntry(GroupModel group)
        {
            return _service.UpdateGroupEntry(group);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost("InsertCompany")]
        public async Task<int> InsertCompany(M_CompanyModel model)
        {
            return await _service.InsertCompany(model);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("GetCompanyViewList")]
        public async Task<List<CompanyViewModel>> GetCompanyViewList()
        {
            return await _service.GetCompanyViewList();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("CompanyUpdate_View_Delete")]
        public async Task<Boolean> CompanyUpdate_View_Delete(string CompanyCD,string AccessPC)
        {
            return await _service.CompanyUpdate_View_Delete(CompanyCD, AccessPC);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("CompanyView_Edit")]
        public async Task<M_CompanyModel> CompanyView_Edit(string CompanyCD)
        {
            return await _service.CompanyView_Edit(CompanyCD);
        }
    }
}
