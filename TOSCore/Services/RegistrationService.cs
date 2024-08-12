using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using TOSCore.Context;
using TOSCore.Models;
using System.Xml.Linq;

namespace TOSCore.Services
{
    public class RegistrationService
    {
        TOSContext _context = new TOSContext();
        public async Task<List<GroupModel>> GetGroupView()
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
        }

        public async Task<List<MBrand>> GetBrand()
        {           
            List<MBrand> brandList = await _context.MBrands.ToListAsync();
            return brandList;
        }
        public async Task<List<MCompany>> GetCompany()
        {
            List<MCompany> companyList = await _context.MCompanies.ToListAsync();
            return companyList;
        }

        //public async Task<string> InsertCompany(M_CompanyModel mModel)
        //{
        //    string result = string.Empty;
        //    if (mModel.Mode == "INSERT")
        //    {
        //        MCompany? mcompany = await _context.MCompanies.Where(x => x.CompanyCd == mModel.CompanyCD).FirstOrDefaultAsync();
        //        if (mcompany != null)
        //        {
        //            Message? message = await _context.Messages.Where(x => x.Key == "1006" && x.Id == "I").SingleOrDefaultAsync();
        //            if (message != null)
        //                result = "Duplicate CompanyCD" + mcompany.CompanyCd;
        //            else
        //            {
        //                using (var transaction = _context.Database.BeginTransaction())
        //                {
        //                    string[] zips = mModel.ZipCode.Split(new Char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
        //                    MCompany newcompany = new MCompany();
        //                    newcompany.CompanyCd = mModel.CompanyCD;
        //                    newcompany.CompanyName = mModel.CompanyName;
        //                    newcompany.Password = mModel.Password;
        //                    newcompany.UserRole = mModel.UserRole;
        //                    newcompany.ShortName = mModel.ShortName;
        //                    newcompany.ZipCd1 = zips[0];
        //                    newcompany.ZipCd2 = zips[1];
        //                    newcompany.Address1 = mModel.Address1;
        //                    newcompany.Address2 = mModel.Address2;
        //                    newcompany.TelephoneNo = mModel.TelephoneNo;
        //                    newcompany.FaxNo = mModel.FaxNo;
        //                    newcompany.PresidentName = mModel.PresidentName;
        //                    newcompany.RankingFlg = mModel.RankingFlg;
        //                    newcompany.InsertDateTime = DateTime.Now;
        //                    newcompany.InsertOperator = "";
        //                    _context.MCompanies.Add(newcompany);
        //                    await _context.SaveChangesAsync();

        //                    if (mModel.ShippingModel.Count > 0)
        //                    {
        //                        foreach(M_CompanyShippingModel shipModel in mModel.ShippingModel)
        //                        {
        //                            if(shipModel.ShippingID!=0 && string.IsNullOrEmpty(shipModel.ShippingName))
        //                            {
        //                                string zipShip1 = string.Empty;
        //                                string zipShip2 = string.Empty;
        //                                if (shipModel.ZipCD1 != null)
        //                                {
        //                                    string[] zipships = shipModel.ZipCD1.Split(new Char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
        //                                     zipShip1 = zipships[0].ToString();
        //                                     zipShip2 = zipships[1].ToString();
        //                                }

        //                                M_CompanyShippingModel newshipModel = new M_CompanyShippingModel();
        //                                newshipModel.ShippingID = shipModel.ShippingID;
        //                                newshipModel.ShippingName = shipModel.ShippingName;
        //                                newshipModel.ZipCD1 = zipShip1;
        //                                newshipModel.ZipCD2 = zipShip2;
        //                                newshipModel.Address1 = shipModel.Address1;
        //                                newshipModel.Address2 = shipModel.Address2;
        //                                newshipModel.TelephoneNO = shipModel.TelephoneNO;
        //                                newshipModel.CompanyCD = mModel.CompanyCD;
        //                                newshipModel.FaxNO = shipModel.FaxNO;
                                        
        //                            }
        //                        }
        //                    }
        //                }

        //            }
        //        }

        //    }
        //    else
        //    {
        //        return result;
        //        //
        //    }
        //}
    }
}
