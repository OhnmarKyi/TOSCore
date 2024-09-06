using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using TOSCore.Context;
using TOSCore.Models;
using System.Buffers.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TOSCore
{
    public class TOS_DL
    {
        TOSContext _context = new TOSContext();
       
        
        public void InsertUpdateDeleteData(string sSQL, params SqlParameter[] para)
        {
            DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(para);
            _context.Database.OpenConnection();
            cmd.ExecuteNonQuery();
        }

        public DataTable SelectData(string sSQL, params SqlParameter[] para)
        {
            DataTable dt = new DataTable();
            var newCon = new SqlConnection(_context.Database.GetConnectionString());
            using (var adapt = new SqlDataAdapter(sSQL, newCon))
            {
                newCon.Open();
                adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    adapt.SelectCommand.Parameters.AddRange(para);
                adapt.Fill(dt);
                newCon.Close();
            }
            return dt;

        }

    }
}
