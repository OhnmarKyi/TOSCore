using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using TOSCore.Models;
using TOSCore.Context;
using System.Reflection.PortableExecutable;

namespace TOSCore.Services
{
    public class TInformationService
    {
        TOSContext _context = new TOSContext();
        public async Task<List<TInformationModel>> GetInformation(string CompanyCD)
        {
            List<TInformationModel> TInfoList = new List<TInformationModel>();
            DbCommand cmd = _context.Database.GetDbConnection().CreateCommand(); ;
            DbDataReader rdr;
            string sql = "T_Information_Select_ForHomePage";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("companyCd", CompanyCD));
            _context.Database.OpenConnection();
            rdr = await cmd.ExecuteReaderAsync();
            while (rdr.Read())
            {
                TInfoList.Add(new TInformationModel
                {
                    Date = rdr["Date"].ToString(),
                    TitleName = rdr["TitleName"].ToString(),
                    InfoText = rdr["InfoText"].ToString(),
                    InfoClass=rdr["InfoClass"].ToString(),
                    InformationID= Convert.ToInt32(rdr["InformationID"].ToString())
                });
            }
            return TInfoList;
        }

        public async Task<TInformationModel> GetInformationDetails(string id)
        {
            int infoID = Convert.ToInt32(id);
            TInformationModel? tinfo = new TInformationModel();

            DbCommand cmd = _context.Database.GetDbConnection().CreateCommand(); ;
            DbDataReader rdr;
            string sql = "Select_InformationTitle";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("InformationID", infoID));
            _context.Database.OpenConnection();
            rdr = await cmd.ExecuteReaderAsync();
            while (rdr.Read())
            {
                tinfo.TitleName = rdr.GetString(0);
                string dt = rdr.GetString(1);
                tinfo.Date = dt;
                tinfo.DetailInformation = rdr.GetString(2);
                if (!rdr.IsDBNull(3))
                    tinfo.AttachedFile1 = rdr.GetString(3);
                if (!rdr.IsDBNull(4))
                    tinfo.AttachedFile2 = rdr.GetString(4);
                if (!rdr.IsDBNull(5))
                    tinfo.AttachedFile3 = rdr.GetString(5);
                if (!rdr.IsDBNull(6))
                    tinfo.AttachedFile4 = rdr.GetString(6);
            }            
            return tinfo;
        }
    }
}
