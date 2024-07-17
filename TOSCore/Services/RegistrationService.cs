using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using TOSCore.Context;
using TOSCore.Models;

namespace TOSCore.Services
{
    public class RegistrationService
    {
        TOSContext _context = new TOSContext();
        public async Task<List<GroupModel>> GetGroupView()
        public async Task<List<MBrand>> GetBrand()
        {
            List<GroupModel> gpInfoList = new List<GroupModel>();
            DbCommand cmd = _context.Database.GetDbConnection().CreateCommand(); ;
            DbDataReader rdr;
            string sql = "Group_View_Select";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar) { Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter("@option", SqlDbType.VarChar) { Value = 1 });
            _context.Database.OpenConnection();
            rdr = await cmd.ExecuteReaderAsync();
            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    gpInfoList.Add(new GroupModel
                    {
                        No = rdr["No"].ToString(),
                        GroupID = rdr["GroupID"].ToString(),
                        GroupName = rdr["GroupName"].ToString(),
                        GroupDesignation = rdr["GroupDesignation"].ToString(),

                    });
                }
            }
            return gpInfoList;
            List<MBrand> brandList = await _context.MBrands.ToListAsync();
            return brandList;
        }

    }
}
