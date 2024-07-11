using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TOSCore.Context;
using TOSCore.Services;
using TOSCore.Models;

namespace TOSCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        [HttpGet("GetCompanyList")]
       public List<MCompany> GetCompanyList()
        {
            TOSContext _context = new TOSContext();
            return _context.MCompanies.ToList();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost("CheckLogin")]
        public async Task<MCompany> CheckLogin(MCompany company)
        {
            UserService _service = new UserService();
            return await _service.CheckLogin(company);
        }
    }
}
