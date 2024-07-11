using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using TOSCore.Models;

namespace TOSCore.Interfaces
{
    public interface ITInformationService
    {
        public Task<List<TInformationModel>> GetInformation(string CompanyCD);       
    }
}
