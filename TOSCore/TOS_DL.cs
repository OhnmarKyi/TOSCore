using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using TOSCore.Context;
using TOSCore.Models;
using System.Buffers.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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

    }
}
