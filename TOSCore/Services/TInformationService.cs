﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using TOSCore.Models;
using TOSCore.Context;

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
    }
}
