using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;
using TOSCore.Context;
using TOSCore.Interfaces;
using TOSCore.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TOSCore.Services
{
    public  class UserService:IUserService
    {
        TOSContext _context = new TOSContext();
        public async Task<MCompany> CheckLogin(MCompany com)
        {           
            MCompany company =await _context.MCompanies.Where<MCompany>(x => x.CompanyCd == com.CompanyCd && x.Password == com.Password).SingleOrDefaultAsync();
            return company;
        } 
    }
}
