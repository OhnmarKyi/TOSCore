using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TOSCore.Context;

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
    }
}
