using TOSCore.Context;
using TOSCore.Interfaces;
using TOSCore.Models;

namespace TOSCore.Interfaces
{
    public  interface IUserService
    {
        public Task<MCompany> CheckLogin(MCompany company);
       
    }
}
