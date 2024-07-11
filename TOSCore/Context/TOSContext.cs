using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TOSCore.Models;

namespace TOSCore.Context
{
    public partial class TOSContext : DbContext
    {
        public TOSContext()
        {
        }

        public TOSContext(DbContextOptions<TOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LLog> LLogs { get; set; } = null!;
        public virtual DbSet<MBrand> MBrands { get; set; } = null!;
        public virtual DbSet<MCompany> MCompanies { get; set; } = null!;
        public virtual DbSet<MCompanyBrand> MCompanyBrands { get; set; } = null!;
        public virtual DbSet<MCompanyShipping> MCompanyShippings { get; set; } = null!;
        public virtual DbSet<MCompanyTag> MCompanyTags { get; set; } = null!;
        public virtual DbSet<MGroup> MGroups { get; set; } = null!;
        public virtual DbSet<MGroupList> MGroupLists { get; set; } = null!;
        public virtual DbSet<MItem> MItems { get; set; } = null!;
        public virtual DbSet<MJobTimeable> MJobTimeables { get; set; } = null!;
        public virtual DbSet<MMultiPorpose> MMultiPorposes { get; set; } = null!;
        public virtual DbSet<MPrice> MPrices { get; set; } = null!;
        public virtual DbSet<MSku> MSkus { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Sheet1> Sheet1s { get; set; } = null!;
        public virtual DbSet<TInformation> TInformations { get; set; } = null!;
        public virtual DbSet<TInformationDestination> TInformationDestinations { get; set; } = null!;
        public virtual DbSet<TInventory> TInventories { get; set; } = null!;
        public virtual DbSet<TOrderDetail> TOrderDetails { get; set; } = null!;
        public virtual DbSet<TOrderHeader> TOrderHeaders { get; set; } = null!;

        //public virtual DbSet<TInformationModel> GetEmployeesWithDepartment_Results { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LLog>(entity =>
            {
                entity.HasKey(e => e.Seq);

                entity.ToTable("L_Log");

                entity.Property(e => e.Seq).HasColumnName("SEQ");

                entity.Property(e => e.AccessPc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AccessPC");

                entity.Property(e => e.CompanyCd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CompanyCD");

                entity.Property(e => e.KeyItem)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OperateDate).HasColumnType("date");

                entity.Property(e => e.OperateMode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessedProgram)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Processed_Program");
            });

            modelBuilder.Entity<MBrand>(entity =>
            {
                entity.HasKey(e => e.BrandCd);

                entity.ToTable("M_Brand");

                entity.HasIndex(e => e.BrandCd, "IX_M_Brand");

                entity.Property(e => e.BrandCd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BrandCD");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyCd);

                entity.ToTable("M_Company");

                entity.Property(e => e.CompanyCd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CompanyCD");

                entity.Property(e => e.Address1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PresidentName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCd1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ZipCD1");

                entity.Property(e => e.ZipCd2)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ZipCD2");
            });

            modelBuilder.Entity<MCompanyBrand>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("M_CompanyBrand");

                entity.Property(e => e.BrandCd).HasColumnName("BrandCD");

                entity.Property(e => e.CompanyCd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CompanyCD");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MCompanyShipping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("M_CompanyShipping");

                entity.Property(e => e.Address1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CompanyCD");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FaxNO");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingId).HasColumnName("ShippingID");

                entity.Property(e => e.ShippingName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TelephoneNO");

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCd1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ZipCD1");

                entity.Property(e => e.ZipCd2)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ZipCD2");
            });

            modelBuilder.Entity<MCompanyTag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("M_CompanyTag");

                entity.Property(e => e.CompanyCd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CompanyCD");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Tag)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("M_Group");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("GroupID");

                entity.Property(e => e.GroupIdinfo)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("GroupIDInfo");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MGroupList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("M_GroupList");

                entity.Property(e => e.CompanyCd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CompanyCD");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("GroupID");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MItem>(entity =>
            {
                entity.HasKey(e => e.MakerItemAdminCd);

                entity.ToTable("M_Item");

                entity.HasIndex(e => e.MakerItemAdminCd, "IX_M_Item");

                entity.Property(e => e.MakerItemAdminCd)
                    .ValueGeneratedNever()
                    .HasColumnName("MakerItemAdminCD");

                entity.Property(e => e.AdvenceClassName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BrandCd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BrandCD");

                entity.Property(e => e.CatelogNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralClassName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImageName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ListPriceInTax)
                    .HasColumnType("money")
                    .HasColumnName("ListPrice(InTax)");

                entity.Property(e => e.ListPriceWithoutTax)
                    .HasColumnType("money")
                    .HasColumnName("ListPrice(WithoutTax)");

                entity.Property(e => e.MakerItemCd)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("MakerItemCD");

                entity.Property(e => e.NormalClassName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SalePriceInTax)
                    .HasColumnType("money")
                    .HasColumnName("SalePrice(InTax)");

                entity.Property(e => e.SalePriceWithoutTax)
                    .HasColumnType("money")
                    .HasColumnName("SalePrice(WithoutTax)");

                entity.Property(e => e.Season)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MJobTimeable>(entity =>
            {
                entity.HasKey(e => e.CompanyCd);

                entity.ToTable("M_JobTimeable");

                entity.Property(e => e.CompanyCd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CompanyCD");

                entity.Property(e => e.CancelAblePeriod)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionAboutPeriod)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.OrderAblePeriod)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MMultiPorpose>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("M_MultiPorpose");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Datetime1).HasColumnType("datetime");

                entity.Property(e => e.Datetime2).HasColumnType("datetime");

                entity.Property(e => e.Datetime3).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Idname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IDName");

                entity.Property(e => e.Key)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KEY")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Num1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Text1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("text1");

                entity.Property(e => e.Text2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("text2");

                entity.Property(e => e.Text3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("text3");

                entity.Property(e => e.Text4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("text4");

                entity.Property(e => e.Text5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("text5");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Updater)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MPrice>(entity =>
            {
                entity.HasKey(e => e.MakerItemAdminCd);

                entity.ToTable("M_Price");

                entity.Property(e => e.MakerItemAdminCd)
                    .ValueGeneratedNever()
                    .HasColumnName("MakerItemAdminCD");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SalePrice).HasColumnType("money");

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MSku>(entity =>
            {
                entity.HasKey(e => e.AdminCd);

                entity.ToTable("M_SKU");

                entity.HasIndex(e => e.AdminCd, "IX_M_SKU");

                entity.Property(e => e.AdminCd)
                    .ValueGeneratedNever()
                    .HasColumnName("AdminCD");

                entity.Property(e => e.ColorName).HasMaxLength(60);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Jancd)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("JANCD");

                entity.Property(e => e.MakerItemAdminCd).HasColumnName("MakerItemAdminCD");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Skucd)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SKUCD");

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Message");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Creater)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Key)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("KEY")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Message1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Message2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Message3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Message4)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Message5)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.Property(e => e.Updater)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sheet1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sheet1$");

                entity.Property(e => e.AdvenceClassName).HasMaxLength(255);

                entity.Property(e => e.GeneralClassName).HasMaxLength(255);

                entity.Property(e => e.ItemName).HasMaxLength(255);

                entity.Property(e => e.ListPriceInTax).HasColumnName("ListPrice(InTax)");

                entity.Property(e => e.MakerItemAdminCd).HasColumnName("MakerItemAdminCD");

                entity.Property(e => e.MakerItemCd)
                    .HasMaxLength(255)
                    .HasColumnName("MakerItemCD");

                entity.Property(e => e.NormalClassName).HasMaxLength(255);

                entity.Property(e => e.SalePriceInTax).HasColumnName("SalePrice(InTax)");

                entity.Property(e => e.Season).HasMaxLength(255);
            });

            modelBuilder.Entity<TInformation>(entity =>
            {
                entity.HasKey(e => e.InformationId);

                entity.ToTable("T_Information");

                entity.Property(e => e.InformationId).HasColumnName("InformationID");

                entity.Property(e => e.AttachedFile1)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.AttachedFile2)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.AttachedFile3)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.AttachedFile4)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DetailInformation)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayEndDate).HasColumnType("date");

                entity.Property(e => e.DisplayStartDate).HasColumnType("date");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TitleName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TInformationDestination>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_InformationDestination");

                entity.Property(e => e.DestinationId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DestinationID");

                entity.Property(e => e.InformationId).HasColumnName("InformationID");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TInventory>(entity =>
            {
                entity.HasKey(e => e.AdminCd);

                entity.ToTable("T_Inventory");

                entity.HasIndex(e => e.AdminCd, "IX_T_Inventory");

                entity.Property(e => e.AdminCd)
                    .ValueGeneratedNever()
                    .HasColumnName("AdminCD");

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

                entity.Property(e => e.InsertOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TOrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_OrderDetail");

                entity.Property(e => e.AdminCd).HasColumnName("AdminCD");

                entity.Property(e => e.AvailableShippingDate).HasColumnType("date");

                entity.Property(e => e.CustomerCd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CustomerCD");

                entity.Property(e => e.DeliveryCompanyCd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DeliveryCompanyCD");

                entity.Property(e => e.Memo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDateTime).HasColumnType("datetime");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.SalePrice).HasColumnType("money");

                entity.Property(e => e.ShippingDate).HasColumnType("date");

                entity.Property(e => e.Shippingfee).HasColumnType("money");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TOrderHeader>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("T_OrderHeader");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.Address1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumptionTax).HasColumnType("money");

                entity.Property(e => e.CustomerCd)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CustomerCD");

                entity.Property(e => e.Memo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDateTime).HasColumnType("datetime");

                entity.Property(e => e.ShippingId).HasColumnName("ShippingID");

                entity.Property(e => e.ShippingName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TelephoneNO");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateOperator)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCd1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ZipCD1");

                entity.Property(e => e.ZipCd2)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ZipCD2");
            });

            //modelBuilder.Entity<TInformationModel>(entity =>
            //{
            //    entity.HasKey(e => e.TitleName);

            //    //entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.TitleName)
            //        .HasMaxLength(150)
            //        .IsUnicode(false)
            //        .HasColumnName("TitleName");

            //    entity.Property(e => e.InfoClass)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("InfoClass");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
