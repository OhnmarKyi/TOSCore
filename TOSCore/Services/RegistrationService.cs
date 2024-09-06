using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using TOSCore.Context;
using Newtonsoft.Json;
using TOSCore.Models;
using System.Buffers.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Xml.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Runtime;

namespace TOSCore.Services
{
    public class RegistrationService
    {
        TOSContext _context = new TOSContext();
        TOS_DL dl = new TOS_DL();

        public async Task<List<GroupModel>> GetGroupView()
        {
            List<GroupModel> gpInfoList = new List<GroupModel>();
            DbCommand cmd = _context.Database.GetDbConnection().CreateCommand(); 
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
        public GroupModel GetGroupData(string id)
        {
            GroupModel gmodel = new GroupModel();
            DataTable dt = new DataTable();
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = new SqlParameter("@id", SqlDbType.VarChar) { Value = id };
            prms[1] = new SqlParameter("@option", SqlDbType.VarChar) { Value = 2 };
           dt= dl.SelectData("Group_View_Select", prms);
           

            if(dt.Rows.Count>0)
            {
                gmodel.GroupID = dt.Rows[0]["GroupID"].ToString();
                gmodel.GroupName = dt.Rows[0]["GroupName"].ToString();
                gmodel.GroupInfoFlg = dt.Rows[0]["GroupInfoFlg"].ToString();
                gmodel.GroupSpecInfo = dt.Rows[0]["GroupSpecInfo"].ToString();

                return gmodel;              

            }
            else    
                
            return null ;
        }
        public string InsertGroupEntry(GroupModel group)
        {
            string PcName = System.Environment.MachineName;
            string insertflag = "success";
            Boolean duplicated = checkDuplicatedGroupId(group);
            if(duplicated is true)
            {
                insertflag = "fail";
            }
           
            else
            {
                insertflag = InsertGroup(group, PcName);
               // successflag = "success";
               
            }
            return insertflag;
        }

        public string UpdateGroupEntry(GroupModel group)
        {
            string updateflag = "fail";
            updateflag = UpdateGroup(group);
            return updateflag ;
        }

        public Boolean checkDuplicatedGroupId(GroupModel group)
        {
         Boolean dr=_context.MGroups.Select(s => s.GroupId == group.GroupID).FirstOrDefault();
           if(dr is true)
            {
                return true;
            }
           else
            return false;
        }
        public String InsertGroup(GroupModel mModel, string PcName)
        {
            try
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrWhiteSpace(mModel.ConpanyName))
                    mModel.GroupInfoFlg = "1";
                else if (!string.IsNullOrWhiteSpace(mModel.BrandName))
                    mModel.GroupInfoFlg = "2";
                else mModel.GroupInfoFlg = "3";

                //BaseDL dl = new BaseDL();
                SqlParameter[] prms = new SqlParameter[9];
                prms[0] = new SqlParameter("@groupID", SqlDbType.VarChar) { Value = mModel.GroupID };
                prms[1] = new SqlParameter("@groupName", SqlDbType.VarChar) { Value = mModel.GroupName };
                prms[2] = new SqlParameter("@groupInfoFlag", SqlDbType.VarChar) { Value = mModel.GroupInfoFlg };
                if (!string.IsNullOrWhiteSpace(mModel.ConpanyName))
                {
                    prms[3] = new SqlParameter("@companyName", SqlDbType.VarChar) { Value = mModel.ConpanyName };
                }
                else
                {
                    prms[3] = new SqlParameter("@companyName", SqlDbType.VarChar) { Value = DBNull.Value };
                }
                if (!string.IsNullOrWhiteSpace(mModel.BrandName))
                {
                    prms[4] = new SqlParameter("@BrandName", SqlDbType.VarChar) { Value = mModel.BrandName };
                }
                else
                {
                    prms[4] = new SqlParameter("@BrandName", SqlDbType.VarChar) { Value = DBNull.Value };
                }
                if (!string.IsNullOrWhiteSpace(mModel.TabName))
                {
                    prms[5] = new SqlParameter("@tag", SqlDbType.VarChar) { Value = mModel.TabName };
                }
                else
                {
                    prms[5] = new SqlParameter("@tag", SqlDbType.VarChar) { Value = DBNull.Value };
                }
                prms[6] = new SqlParameter("@AccessPC", SqlDbType.VarChar) { Value = PcName };
                prms[7] = new SqlParameter("@insertOperator", SqlDbType.VarChar) { Value = mModel.InsertOperator };
                prms[8] = new SqlParameter("@saveUpdateFlag", SqlDbType.VarChar) { Value = "Save" };
                dl.InsertUpdateDeleteData("Group_Entry_Insert", prms);
                return "success";
            }
            catch (Exception ex)
            {
                string aa = ex.Message;
                return "fail";
            }

        }

        public string UpdateGroup(GroupModel mModel)
        {

            try
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrWhiteSpace(mModel.ConpanyName))
                    mModel.GroupInfoFlg = "1";
                else if (!string.IsNullOrWhiteSpace(mModel.BrandName))
                    mModel.GroupInfoFlg = "2";
                else mModel.GroupInfoFlg = "3";

                //BaseDL dl = new BaseDL();
                SqlParameter[] prms = new SqlParameter[9];
                prms[0] = new SqlParameter("@groupID", SqlDbType.VarChar) { Value = mModel.GroupID };
                prms[1] = new SqlParameter("@groupName", SqlDbType.VarChar) { Value = mModel.GroupName };
                prms[2] = new SqlParameter("@groupInfoFlag", SqlDbType.VarChar) { Value = mModel.GroupInfoFlg };
                if (!string.IsNullOrWhiteSpace(mModel.ConpanyName))
                {
                    prms[3] = new SqlParameter("@companyName", SqlDbType.VarChar) { Value = mModel.ConpanyName };
                }
                else
                {
                    prms[3] = new SqlParameter("@companyName", SqlDbType.VarChar) { Value = DBNull.Value };
                }
                if (!string.IsNullOrWhiteSpace(mModel.BrandName))
                {
                    prms[4] = new SqlParameter("@BrandName", SqlDbType.VarChar) { Value = mModel.BrandName };
                }
                else
                {
                    prms[4] = new SqlParameter("@BrandName", SqlDbType.VarChar) { Value = DBNull.Value };
                }
                if (!string.IsNullOrWhiteSpace(mModel.TabName))
                {
                    prms[5] = new SqlParameter("@tag", SqlDbType.VarChar) { Value = mModel.TabName };
                }
                else
                {
                    prms[5] = new SqlParameter("@tag", SqlDbType.VarChar) { Value = DBNull.Value };
                }
                prms[6] = new SqlParameter("@AccessPC", SqlDbType.VarChar) { Value = System.Environment.MachineName };
                prms[7] = new SqlParameter("@insertOperator", SqlDbType.VarChar) { Value = mModel.InsertOperator };
                prms[8] = new SqlParameter("@saveUpdateFlag", SqlDbType.VarChar) { Value = "Update" };
                dl.InsertUpdateDeleteData("Group_Entry_Insert", prms);
                return "success";
            }
            catch (Exception ex)
            {
                string aa = ex.Message;
                return "fail";
            }
        }

        public async Task<int> InsertCompany(M_CompanyModel mModel)
        {
            int result = 0;
            if (mModel.Mode == "INSERT")
            {
                MCompany? mcompany = await _context.MCompanies.Where(x => x.CompanyCd == mModel.CompanyCD).FirstOrDefaultAsync();
                if (mcompany == null)
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            string[] zips = mModel.ZipCode.Split(new Char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                            MCompany newcompany = new MCompany();
                            newcompany.CompanyCd = mModel.CompanyCD;
                            newcompany.CompanyName = mModel.CompanyName;
                            newcompany.Password = mModel.Password;
                            newcompany.UserRole =Convert.ToByte(mModel.UserRole);
                            newcompany.ShortName = mModel.ShortName;
                            newcompany.ZipCd1 = zips[0];
                            newcompany.ZipCd2 = zips[1];
                            newcompany.Address1 = mModel.Address1;
                            newcompany.Address2 = mModel.Address2;
                            newcompany.TelephoneNo = mModel.TelephoneNo;
                            newcompany.FaxNo = mModel.FaxNo;
                            newcompany.PresidentName = mModel.PresidentName;
                            newcompany.RankingFlg = Convert.ToByte(mModel.RankingFlg);
                            newcompany.InsertDateTime = DateTime.Now;
                            newcompany.InsertOperator = "";
                            _context.MCompanies.Add(newcompany);
                            await _context.SaveChangesAsync();

                            if (mModel.ShippingModel.Count > 0)
                            {
                                foreach (M_CompanyShippingModel shipModel in mModel.ShippingModel)
                                {
                                    if (shipModel.ShippingID != 0 && !string.IsNullOrEmpty(shipModel.ShippingName))
                                    {
                                        string zipShip1 = string.Empty;
                                        string zipShip2 = string.Empty;
                                        if (shipModel.ZipCD1 != null)
                                        {
                                            string[] zipships = shipModel.ZipCD1.Split(new Char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                                            zipShip1 = zipships[0].ToString();
                                            zipShip2 = zipships[1].ToString();
                                        }

                                        MCompanyShipping newshipModel = new MCompanyShipping();
                                        newshipModel.ShippingId = shipModel.ShippingID == null ? 0 : Convert.ToInt32(shipModel.ShippingID);
                                        newshipModel.ShippingName = shipModel.ShippingName;
                                        newshipModel.ZipCd1 = zipShip1;
                                        newshipModel.ZipCd2 = zipShip2;
                                        newshipModel.Address1 = shipModel.Address1;
                                        newshipModel.Address2 = shipModel.Address2;
                                        newshipModel.TelephoneNo = shipModel.TelephoneNO;
                                        newshipModel.CompanyCd = mModel.CompanyCD;
                                        newshipModel.FaxNo = shipModel.FaxNO;
                                        _context.MCompanyShippings.Add(newshipModel);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }

                            if (mModel.TagModel.Count > 0)
                            {
                                for(int i = 0; i < mModel.TagModel.Count; i++)
                                {
                                    if (mModel.TagModel[i].Tag!=null && !string.IsNullOrEmpty(mModel.TagModel[i].Tag))
                                    {                                       
                                        SqlParameter[] prms = new SqlParameter[4];
                                        prms[0] = new SqlParameter("@CompanyCD", SqlDbType.VarChar) { Value = mModel.CompanyCD };
                                        prms[1] = new SqlParameter("@Tag", SqlDbType.VarChar) { Value = mModel.TagModel[i].Tag };
                                        prms[2] = new SqlParameter("@InsertOperator", SqlDbType.VarChar) { Value ="000001"};
                                        prms[3] = new SqlParameter("@AccessPC", SqlDbType.VarChar) { Value = "pc" };
                                        dl.InsertUpdateDeleteData("M_CompanyTag_Insert", prms);                                        
                                    }
                                }                                
                            }

                            if (mModel.brand.Count>0)
                            {
                                string brandNameList = string.Empty;
                                foreach (M_BrandModel bModel in mModel.brand)
                                {
                                     brandNameList += bModel.brandName + ",";
                                }
                                
                                SqlParameter[] prms = new SqlParameter[4];
                                prms[0] = new SqlParameter("@CompanyCD", SqlDbType.VarChar) { Value = mModel.CompanyCD };
                                prms[1] = new SqlParameter("@BrandName", SqlDbType.VarChar) { Value = brandNameList };
                                prms[2] = new SqlParameter("@InsertOperator", SqlDbType.VarChar) { Value = "000001" };
                                prms[3] = new SqlParameter("@AccessPC", SqlDbType.VarChar) { Value = "pc" };
                                dl.InsertUpdateDeleteData("M_CompanyBrand_Insert", prms);
                            }
                            await transaction.CommitAsync();
                            result = 1;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            result = 0;
                        }
                    }
                }
                else
                {
                    Message? message = await _context.Messages.Where(x => x.Key == "1006" && x.Id == "I").SingleOrDefaultAsync();
                    if (message != null)
                        result = 2;
                }
                return result;
            }
            else
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        MCompany mcompany = await _context.MCompanies.Where(x => x.CompanyCd == mModel.CompanyCD).FirstOrDefaultAsync();
                        string[] zips = mModel.ZipCode.Split(new Char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        mcompany.CompanyName = mModel.CompanyName;
                        mcompany.Password = mModel.Password;
                        mcompany.UserRole = Convert.ToByte(mModel.UserRole);
                        mcompany.ShortName = mModel.ShortName;
                        mcompany.ZipCd1 = zips[0];
                        mcompany.ZipCd2 = zips[1];
                        mcompany.Address1 = mModel.Address1;
                        mcompany.Address2 = mModel.Address2;
                        mcompany.TelephoneNo = mModel.TelephoneNo;
                        mcompany.FaxNo = mModel.FaxNo;
                        mcompany.PresidentName = mModel.PresidentName;
                        mcompany.RankingFlg = Convert.ToByte(mModel.RankingFlg);
                        mcompany.InsertDateTime = DateTime.Now;
                        mcompany.InsertOperator = "";
                        await _context.SaveChangesAsync();

                        DataTable dtCompanyShipping = new DataTable("shipping");
                        dtCompanyShipping.Columns.Add("ShippingID", typeof(int));
                        dtCompanyShipping.Columns.Add("ShippingName", typeof(String));
                        dtCompanyShipping.Columns.Add("ZipCD1", typeof(string));
                        dtCompanyShipping.Columns.Add("ZipCD2", typeof(string));
                        dtCompanyShipping.Columns.Add("Address1", typeof(string));
                        dtCompanyShipping.Columns.Add("Address2", typeof(string));
                        dtCompanyShipping.Columns.Add("TelephoneNO", typeof(string));
                        dtCompanyShipping.Columns.Add("FaxNO", typeof(string));
                        int i = 0;
                        foreach (M_CompanyShippingModel shipping in mModel.ShippingModel)
                        {
                            if (shipping.ShippingID > 0)
                            {
                                dtCompanyShipping.Rows.Add();
                                dtCompanyShipping.Rows[i]["ShippingID"] = shipping.ShippingID;
                                dtCompanyShipping.Rows[i]["ShippingName"] = shipping.ShippingName;
                                //dtCompanyShipping.Rows[i]["ZipCD1"] = "111";
                                //dtCompanyShipping.Rows[i]["ZipCD2"] = "111";
                                dtCompanyShipping.Rows[i]["ZipCD1"] = shipping.ZipCD1.Split('-')[0];
                                dtCompanyShipping.Rows[i]["ZipCD2"] = shipping.ZipCD1.Split('-')[1];
                                dtCompanyShipping.Rows[i]["Address1"] = shipping.Address1;
                                dtCompanyShipping.Rows[i]["Address2"] = shipping.Address2;
                                dtCompanyShipping.Rows[i]["TelephoneNO"] = shipping.TelephoneNO;
                                dtCompanyShipping.Rows[i]["FaxNO"] = shipping.FaxNO;
                                i++;
                            }
                        }

                        SqlParameter[] prms = new SqlParameter[3];
                        prms[0] = new SqlParameter("@CompanyCD", SqlDbType.VarChar) { Value = mModel.CompanyCD };
                        prms[1] = new SqlParameter("@AccessPC", SqlDbType.VarChar) { Value = "pc" };
                        System.IO.StringWriter writer = new System.IO.StringWriter();
                        dtCompanyShipping.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                        string xmlshipping = writer.ToString();
                        prms[2] = new SqlParameter("@xml", SqlDbType.Xml) { Value = xmlshipping };
                        dl.InsertUpdateDeleteData("M_CompanyShipping_Update", prms);


                        DataTable dtCompanyTag = new DataTable("shipping");
                        dtCompanyTag.Columns.Add("CompanyCD", typeof(string));
                        dtCompanyTag.Columns.Add("Tag", typeof(String));
                        int j = 0;
                        foreach (M_CompanyTagModel tag in mModel.TagModel)
                        {
                            if (!string.IsNullOrEmpty(tag.Tag))
                            {
                                dtCompanyTag.Rows.Add();
                                dtCompanyTag.Rows[j]["CompanyCD"] = mModel.CompanyCD;
                                dtCompanyTag.Rows[j]["Tag"] = tag.Tag;
                                j++;
                            }
                        }

                        SqlParameter[] prms1 = new SqlParameter[3];
                        prms1[0] = new SqlParameter("@CompanyCD", SqlDbType.VarChar) { Value = mModel.CompanyCD };
                        prms1[1] = new SqlParameter("@AccessPC", SqlDbType.VarChar) { Value = "pc" };
                        System.IO.StringWriter writer1 = new System.IO.StringWriter();
                        dtCompanyTag.WriteXml(writer1, XmlWriteMode.WriteSchema, false);
                        string xmltag = writer1.ToString();
                        prms1[2] = new SqlParameter("@xml", SqlDbType.Xml) { Value = xmltag };
                        dl.InsertUpdateDeleteData("M_CompanyTag_Update", prms1);

                        if (mModel.brand.Count > 0)
                        {
                            string brandNameList = string.Empty;
                            foreach (M_BrandModel bModel in mModel.brand)
                            {
                                brandNameList += bModel.brandName + ",";
                            }

                            SqlParameter[] prms2 = new SqlParameter[4];
                            prms2[0] = new SqlParameter("@CompanyCD", SqlDbType.VarChar) { Value = mModel.CompanyCD };
                            prms2[1] = new SqlParameter("@BrandName", SqlDbType.VarChar) { Value = brandNameList };
                            prms2[2] = new SqlParameter("@UpdateOperator", SqlDbType.VarChar) { Value = "000001" };
                            prms2[3] = new SqlParameter("@AccessPC", SqlDbType.VarChar) { Value = "pc" };
                            dl.InsertUpdateDeleteData("M_CompanyBrand_Update", prms2);
                        }
                        await transaction.CommitAsync();
                        result = 1;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        result = 0;
                    }
                }
                return result;
            }
        }

        public async Task<List<CompanyViewModel>> GetCompanyViewList()
        {
            List<CompanyViewModel> companyList = new List<CompanyViewModel>();
            DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
            DbDataReader rdr;
            string sql = "CompanyUpdateView_Select";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            _context.Database.OpenConnection();
            rdr = await cmd.ExecuteReaderAsync();
            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    companyList.Add(new CompanyViewModel
                    {
                        No = rdr["No"].ToString(),
                        CompanyCD = rdr["CompanyCD"].ToString(),
                        CompanyName = rdr["CompanyName"].ToString(),
                        ShortName = rdr["ShortName"].ToString(),
                        PresidentName = rdr["PresidentName"].ToString(),
                        RankingFlg = rdr["RankingFlg"].ToString()
                    }) ;
                }
            }
            return companyList;
        }

        public async Task<Boolean> CompanyUpdate_View_Delete(string CompanyCD,string AccessPC)
        {
            DataTable dt = new DataTable();
            DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
            DbDataReader rdr;
            string sql = "CompanyUpdateView_Delete";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CompanyCD", SqlDbType.VarChar) { Value = CompanyCD});
            cmd.Parameters.Add(new SqlParameter("@AccessPC", SqlDbType.VarChar) { Value = "pc" });
            _context.Database.OpenConnection();
            rdr = await cmd.ExecuteReaderAsync();
            dt.Load(rdr);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public async Task<M_CompanyModel> CompanyView_Edit(string CompanyCD)
        {
            M_CompanyModel model = new M_CompanyModel();
            model.ShippingModel = new List<M_CompanyShippingModel>();
            model.TagModel = new List<M_CompanyTagModel>();
            model.brand = new List<M_BrandModel>();
            if (!string.IsNullOrEmpty(CompanyCD))
            {
                try
                {
                    MCompany company = await _context.MCompanies.Where(x => x.CompanyCd == CompanyCD).SingleOrDefaultAsync();
                    if (company != null)
                    {
                        model.CompanyCD = company.CompanyCd;
                        model.CompanyName = company.CompanyName;
                        model.Password = company.Password;
                        model.UserRole = company.UserRole;
                        model.ShortName = company.ShortName;
                        model.ZipCode = company.ZipCd1 + "-" + company.ZipCd2;
                        model.Address1 = company.Address1;
                        model.Address2 = company.Address2;
                        model.TelephoneNo = company.TelephoneNo;
                        model.FaxNo = company.FaxNo;
                        model.PresidentName = company.PresidentName;
                        model.RankingFlg = company.RankingFlg;
                    }
                    List<MCompanyShipping> shipping = await _context.MCompanyShippings.Where(x => x.CompanyCd == CompanyCD).ToListAsync();
                    foreach (MCompanyShipping shippingItem in shipping)
                    {
                        M_CompanyShippingModel shipModel = new M_CompanyShippingModel();
                        shipModel.CompanyCD = shippingItem.CompanyCd;
                        shipModel.ShippingID = shippingItem.ShippingId;
                        shipModel.ShippingName = shippingItem.ShippingName;
                        shipModel.ZipCD1 = shippingItem.ZipCd1+"-"+ shippingItem.ZipCd2;                        
                        shipModel.Address1 = shippingItem.Address1;
                        shipModel.Address2 = shippingItem.Address2;
                        shipModel.TelephoneNO = shippingItem.TelephoneNo;
                        shipModel.FaxNO = shippingItem.FaxNo;
                        model.ShippingModel.Add(shipModel);
                    }
                    List<MCompanyTag> tag = await _context.MCompanyTags.Where(x => x.CompanyCd == CompanyCD).ToListAsync();
                    foreach (MCompanyTag tagItem in tag)
                    {
                        M_CompanyTagModel tagModel = new M_CompanyTagModel();
                        tagModel.CompanyCD = tagItem.CompanyCd;
                        tagModel.Tag = tagItem.Tag;
                        model.TagModel.Add(tagModel);
                    }

                    List<MBrand> brand = await _context.MBrands.FromSqlRaw("SELECT b.* from M_CompanyBrand  mb inner join M_Brand b on mb.BrandCD = b.BrandCD where CompanyCD = @CompanyCD", new SqlParameter("@CompanyCD", SqlDbType.VarChar) { Value = CompanyCD }).ToListAsync();
                    foreach (MBrand brandItem in brand)
                    {
                        M_BrandModel brandModel = new M_BrandModel();
                        brandModel.brandCd = brandItem.BrandCd;
                        brandModel.brandName = brandItem.BrandName;
                        model.brand.Add(brandModel);
                    }
                }
                catch(Exception ex)
                {
                    string st = ex.Message;
                }

            }
            return model;
        }
    }
}
