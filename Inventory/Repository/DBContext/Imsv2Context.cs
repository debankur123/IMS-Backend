﻿using System;
using System.Collections.Generic;
using Inventory.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repository.DBContext;

public partial class Imsv2Context : DbContext
{
    public Imsv2Context(DbContextOptions<Imsv2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ApproveModule> ApproveModules { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetType> AssetTypes { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<BillInstallAmt> BillInstallAmts { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CustVendItemType> CustVendItemTypes { get; set; }

    public virtual DbSet<CustVendJobType> CustVendJobTypes { get; set; }

    public virtual DbSet<CustomerVendor> CustomerVendors { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<FinYear> FinYears { get; set; }

    public virtual DbSet<Grn> Grns { get; set; }

    public virtual DbSet<Grndetail> Grndetails { get; set; }

    public virtual DbSet<HtmlTemplate> HtmlTemplates { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemDetail> ItemDetails { get; set; }

    public virtual DbSet<ItemGroup> ItemGroups { get; set; }

    public virtual DbSet<ItemPrefix> ItemPrefixes { get; set; }

    public virtual DbSet<ItemStock> ItemStocks { get; set; }

    public virtual DbSet<ItemSubGroup> ItemSubGroups { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobType> JobTypes { get; set; }

    public virtual DbSet<Layer> Layers { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuAccess> MenuAccesses { get; set; }

    public virtual DbSet<NoteSheet> NoteSheets { get; set; }

    public virtual DbSet<NoteSheetDetail> NoteSheetDetails { get; set; }

    public virtual DbSet<OldAsset> OldAssets { get; set; }

    public virtual DbSet<OldAssetRegister> OldAssetRegisters { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentBillLedger> PaymentBillLedgers { get; set; }

    public virtual DbSet<PaymentTran> PaymentTrans { get; set; }

    public virtual DbSet<Po> Pos { get; set; }

    public virtual DbSet<PoAto> PoAtos { get; set; }

    public virtual DbSet<Poadv> Poadvs { get; set; }

    public virtual DbSet<PoadvDet> PoadvDets { get; set; }

    public virtual DbSet<PoadvPayment> PoadvPayments { get; set; }

    public virtual DbSet<Pobill> Pobills { get; set; }

    public virtual DbSet<PobillDetail> PobillDetails { get; set; }

    public virtual DbSet<PobillItemDetail> PobillItemDetails { get; set; }

    public virtual DbSet<Podetail> Podetails { get; set; }

    public virtual DbSet<PodetailAto> PodetailAtos { get; set; }

    public virtual DbSet<Prefix> Prefixes { get; set; }

    public virtual DbSet<PurchasePayDet> PurchasePayDets { get; set; }

    public virtual DbSet<PurchasePayment> PurchasePayments { get; set; }

    public virtual DbSet<Quotation> Quotations { get; set; }

    public virtual DbSet<QuotationDetail> QuotationDetails { get; set; }

    public virtual DbSet<Req> Reqs { get; set; }

    public virtual DbSet<ReqDeleted> ReqDeleteds { get; set; }

    public virtual DbSet<ReqDetail> ReqDetails { get; set; }

    public virtual DbSet<SecurityQuestion> SecurityQuestions { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Stc> Stcs { get; set; }

    public virtual DbSet<Stcdetail> Stcdetails { get; set; }

    public virtual DbSet<StockDepartment> StockDepartments { get; set; }

    public virtual DbSet<StudentPortalPaymentAccess> StudentPortalPaymentAccesses { get; set; }

    public virtual DbSet<TempAsset> TempAssets { get; set; }

    public virtual DbSet<TempAsset27april2018> TempAsset27april2018s { get; set; }

    public virtual DbSet<TempCanceledPo> TempCanceledPos { get; set; }

    public virtual DbSet<TempCanceledPodetail> TempCanceledPodetails { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<UnitLocation> UnitLocations { get; set; }

    public virtual DbSet<Uom> Uoms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserUnit> UserUnits { get; set; }

    public virtual DbSet<UserWorkApproval> UserWorkApprovals { get; set; }

    public virtual DbSet<UsersUnit> UsersUnits { get; set; }

    public virtual DbSet<VwBank> VwBanks { get; set; }

    public virtual DbSet<WorkFlow> WorkFlows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApproveModule>(entity =>
        {
            entity.HasKey(e => e.ApproveModuleId).HasName("PK_ApproverType");

            entity.ToTable("ApproveModule");

            entity.Property(e => e.ApproveModuleId).HasColumnName("ApproveModuleID");
            entity.Property(e => e.ApproveModuleItype)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ApproveModuleIType");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.ModuleName).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.ToTable("Area");

            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.AreaCode)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
        });

        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK__Asset__4349237265A26AAC");

            entity.ToTable("Asset");

            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssetCode).HasMaxLength(100);
            entity.Property(e => e.BookValue).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.BookValueOpBal).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.DepreciationAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.DepreciationMethod)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Grnid).HasColumnName("GRNID");
            entity.Property(e => e.IssuedDate).HasColumnType("datetime");
            entity.Property(e => e.IssuedPerson)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ItemCode).HasMaxLength(100);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.PurchasePrice).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Sflag).HasColumnName("sflag");
            entity.Property(e => e.StockDeptId).HasColumnName("StockDeptID");
            entity.Property(e => e.StockId).HasColumnName("StockID");
            entity.Property(e => e.Year).HasColumnType("numeric(4, 0)");
        });

        modelBuilder.Entity<AssetType>(entity =>
        {
            entity.ToTable("AssetType");

            entity.Property(e => e.AssetTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AssetTypeID");
            entity.Property(e => e.AssetType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AssetType");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.BankId).HasName("PK__Bank__AA08CB333F47746F");

            entity.ToTable("Bank");

            entity.Property(e => e.BankId).HasColumnName("BankID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BankName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BaranchName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IfscCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ifsc_Code");
        });

        modelBuilder.Entity<BillInstallAmt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BillInstallAmt");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.InstallmentAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PobillId).HasColumnName("POBillId");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<CustVendItemType>(entity =>
        {
            entity.HasKey(e => e.CvItemTypeId).HasName("PK_CustVendType");

            entity.ToTable("CustVendItemType");

            entity.Property(e => e.CvItemTypeId).HasColumnName("CV_ItemTypeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.CvId).HasColumnName("CV_ID");
            entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

            entity.HasOne(d => d.Cv).WithMany(p => p.CustVendItemTypes)
                .HasForeignKey(d => d.CvId)
                .HasConstraintName("FK_CustVendItemType_CustomerVendor");
        });

        modelBuilder.Entity<CustVendJobType>(entity =>
        {
            entity.HasKey(e => e.CvJobTypeId);

            entity.ToTable("CustVendJobType");

            entity.Property(e => e.CvJobTypeId).HasColumnName("CV_JobTypeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.CvId).HasColumnName("CV_ID");
            entity.Property(e => e.DescripTion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");

            entity.HasOne(d => d.Cv).WithMany(p => p.CustVendJobTypes)
                .HasForeignKey(d => d.CvId)
                .HasConstraintName("FK_CustVendJobType_CustomerVendor");
        });

        modelBuilder.Entity<CustomerVendor>(entity =>
        {
            entity.HasKey(e => e.CvId);

            entity.ToTable("CustomerVendor");

            entity.Property(e => e.CvId).HasColumnName("CV_ID");
            entity.Property(e => e.AccType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountNumber).HasMaxLength(100);
            entity.Property(e => e.Bankbranch).HasMaxLength(100);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.ContactPerson).HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.CvAddress)
                .HasMaxLength(500)
                .HasColumnName("CV_Address");
            entity.Property(e => e.CvCode)
                .HasMaxLength(10)
                .HasColumnName("CV_Code");
            entity.Property(e => e.CvCstNo)
                .HasMaxLength(50)
                .HasColumnName("CV_CST_NO");
            entity.Property(e => e.CvEmail)
                .HasMaxLength(100)
                .HasColumnName("CV_Email");
            entity.Property(e => e.CvMobile)
                .HasMaxLength(100)
                .HasColumnName("CV_Mobile");
            entity.Property(e => e.CvName)
                .HasMaxLength(100)
                .HasColumnName("CV_Name");
            entity.Property(e => e.CvPancardNo)
                .HasMaxLength(50)
                .HasColumnName("CV_PANCardNo");
            entity.Property(e => e.CvPhone)
                .HasMaxLength(100)
                .HasColumnName("CV_Phone");
            entity.Property(e => e.CvPinCode)
                .HasMaxLength(50)
                .HasColumnName("CV_PinCode");
            entity.Property(e => e.CvState).HasColumnName("CV_State");
            entity.Property(e => e.CvTag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CV_Tag");
            entity.Property(e => e.CvTan)
                .HasMaxLength(50)
                .HasColumnName("CV_TAN");
            entity.Property(e => e.CvWbstNo)
                .HasMaxLength(50)
                .HasColumnName("CV_WBST_NO");
            entity.Property(e => e.CvWebsite)
                .HasMaxLength(100)
                .HasColumnName("CV_Website");
            entity.Property(e => e.Cvdistrict)
                .HasMaxLength(100)
                .HasColumnName("CVDistrict");
            entity.Property(e => e.DealsIn).HasMaxLength(20);
            entity.Property(e => e.Ifsccode)
                .HasMaxLength(100)
                .HasColumnName("IFSCCode");
            entity.Property(e => e.Login).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.RegDate).HasColumnType("date");
            entity.Property(e => e.RegNumber).HasMaxLength(100);
            entity.Property(e => e.ServiceTaxNumber).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
            entity.Property(e => e.Vat)
                .HasMaxLength(100)
                .HasColumnName("VAT");
            entity.Property(e => e.VendoreFile)
                .HasMaxLength(50)
                .HasColumnName("vendoreFile");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK__District__85FDA4A63E76E6A7");

            entity.ToTable("District");

            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StateId).HasColumnName("StateID");
        });

        modelBuilder.Entity<FinYear>(entity =>
        {
            entity.ToTable("FinYEAR");

            entity.Property(e => e.FinYearId).HasColumnName("FinYearID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.FinYearName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Grn>(entity =>
        {
            entity.HasKey(e => e.Grnid).HasName("PK_GRN_IN");

            entity.ToTable("GRN");

            entity.Property(e => e.Grnid).HasColumnName("GRNID");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.ChallanDate).HasColumnType("datetime");
            entity.Property(e => e.ChallanNo).HasMaxLength(100);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.DeliveryBy).HasMaxLength(100);
            entity.Property(e => e.DescripTion).HasMaxLength(100);
            entity.Property(e => e.Grndate)
                .HasColumnType("datetime")
                .HasColumnName("GRNdate");
            entity.Property(e => e.Grnno)
                .HasMaxLength(100)
                .HasColumnName("GRNNo");
            entity.Property(e => e.InspectDate).HasColumnType("datetime");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.QcBy).HasMaxLength(100);
            entity.Property(e => e.QcDate).HasColumnType("datetime");
            entity.Property(e => e.QcRemarks).HasMaxLength(100);
            entity.Property(e => e.RefGrnno)
                .HasMaxLength(50)
                .HasColumnName("RefGRNNo");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.TransportMode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TransportNo).HasMaxLength(100);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");

            entity.HasOne(d => d.Company).WithMany(p => p.Grns)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_GRN_IN_Company");

            entity.HasOne(d => d.ReceivedByNavigation).WithMany(p => p.Grns)
                .HasForeignKey(d => d.ReceivedBy)
                .HasConstraintName("FK_GRN_IN_Users");
        });

        modelBuilder.Entity<Grndetail>(entity =>
        {
            entity.ToTable("GRNDetail");

            entity.Property(e => e.GrndetailId).HasColumnName("GRNDetailID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Grnid).HasColumnName("GRNID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.OrderQty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PdId).HasColumnName("PdID");
            entity.Property(e => e.Qcby).HasColumnName("QCBy");
            entity.Property(e => e.Qcdate)
                .HasColumnType("datetime")
                .HasColumnName("QCdate");
            entity.Property(e => e.Qcstatus)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("QCstatus");
            entity.Property(e => e.Rate).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.RecItemTotal).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.RecQty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.RemQty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");

            entity.HasOne(d => d.Company).WithMany(p => p.Grndetails)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_GRNDetail_Company");
        });

        modelBuilder.Entity<HtmlTemplate>(entity =>
        {
            entity.HasKey(e => e.HtmlTemplateId).HasName("PK__HtmlTemp__57F760FCDA78288F");

            entity.ToTable("HtmlTemplate");

            entity.Property(e => e.HtmlTemplateId).HasColumnName("HtmlTemplateID");
            entity.Property(e => e.HtmlTemplate1).HasColumnName("HtmlTemplate");
            entity.Property(e => e.HtmlType).HasMaxLength(10);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.AssetTypeId).HasColumnName("AssetTypeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Exprement)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemDescHtml).HasColumnName("ItemDescHTML");
            entity.Property(e => e.ItemName).IsUnicode(false);
            entity.Property(e => e.ItemShortCode).IsUnicode(false);
            entity.Property(e => e.ItemSubGroupId).HasColumnName("ItemSubGroupID");
            entity.Property(e => e.ItemType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Rate).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.Rol)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("ROL");
            entity.Property(e => e.Rqty)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("RQTY");
            entity.Property(e => e.ServiceTax).HasColumnType("numeric(6, 2)");
            entity.Property(e => e.Soh)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("SOH");
            entity.Property(e => e.StoreUomid).HasColumnName("StoreUOMID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid)
                .HasColumnType("datetime")
                .HasColumnName("UpdatedUID");
            entity.Property(e => e.Vat)
                .HasColumnType("numeric(6, 2)")
                .HasColumnName("VAT");
        });

        modelBuilder.Entity<ItemDetail>(entity =>
        {
            entity.HasKey(e => e.ItemDetailId).HasName("PK_ItemAMC");

            entity.ToTable("ItemDetail");

            entity.Property(e => e.ItemDetailId).HasColumnName("ItemDetailID");
            entity.Property(e => e.AmcProviderId).HasColumnName("AmcProviderID");
            entity.Property(e => e.AmcRenewDate).HasColumnType("datetime");
            entity.Property(e => e.AmcScope).IsUnicode(false);
            entity.Property(e => e.AmcStartDate).HasColumnType("datetime");
            entity.Property(e => e.AmcType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AmcValue).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Expdate)
                .HasColumnType("datetime")
                .HasColumnName("EXPDate");
            entity.Property(e => e.Grnid)
                .HasMaxLength(50)
                .HasColumnName("GRNID");
            entity.Property(e => e.IndentId).HasColumnName("IndentID");
            entity.Property(e => e.InstallationDate).HasColumnType("datetime");
            entity.Property(e => e.ItemCode).HasMaxLength(50);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.LogBookSerial).HasMaxLength(50);
            entity.Property(e => e.Make).HasMaxLength(100);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.PobillId).HasColumnName("POBillID");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.QuotationId).HasColumnName("QuotationID");
            entity.Property(e => e.ReqId).HasColumnName("ReqID");
            entity.Property(e => e.Serial).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SupplierContactNo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.WarrantyDetail).IsUnicode(false);

            entity.HasOne(d => d.Item).WithMany(p => p.ItemDetails)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_ItemDetail_Item");
        });

        modelBuilder.Entity<ItemGroup>(entity =>
        {
            entity.ToTable("ItemGroup");

            entity.Property(e => e.ItemGroupId).HasColumnName("ItemGroupID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.ItemGroupName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemPrefix>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ItemPrefix");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemPrefixId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ItemPrefixID");
            entity.Property(e => e.ItemSubGroupId).HasColumnName("ItemSubGroupID");
            entity.Property(e => e.PrefixVlue)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemStock>(entity =>
        {
            entity.ToTable("ItemStock");

            entity.Property(e => e.ItemStockId).HasColumnName("ItemStockID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.GrnId).HasColumnName("GrnID");
            entity.Property(e => e.IssuedDate).HasColumnType("datetime");
            entity.Property(e => e.IssuedPerson)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Soh)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("SOH");
            entity.Property(e => e.StockDepartmentId).HasColumnName("StockDepartmentID");
            entity.Property(e => e.StockQty).HasColumnName("StockQTY");
            entity.Property(e => e.StockType)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.TransferId).HasColumnName("TransferID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");

            entity.HasOne(d => d.Area).WithMany(p => p.ItemStocks)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_ItemStock_Area");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemStocks)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK_ItemStock_Item");

            entity.HasOne(d => d.Unit).WithMany(p => p.ItemStocks)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemStock_Unit");
        });

        modelBuilder.Entity<ItemSubGroup>(entity =>
        {
            entity.ToTable("ItemSubGroup");

            entity.Property(e => e.ItemSubGroupId).HasColumnName("ItemSubGroupID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.ItemGroupId).HasColumnName("ItemGroupID");
            entity.Property(e => e.ItemSubGroupName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ItemGroup).WithMany(p => p.ItemSubGroups)
                .HasForeignKey(d => d.ItemGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemSubGroup_ItemGroup");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.ToTable("Job");

            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");

            entity.HasOne(d => d.JobType).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.JobTypeId)
                .HasConstraintName("FK_Job_JobType");
        });

        modelBuilder.Entity<JobType>(entity =>
        {
            entity.ToTable("JobType");

            entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.JobTypeName).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
        });

        modelBuilder.Entity<Layer>(entity =>
        {
            entity.ToTable("Layer");

            entity.Property(e => e.LayerId).HasColumnName("LayerID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InitialPage)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.MenuName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MenuUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ParentMenuId).HasColumnName("ParentMenuID");
        });

        modelBuilder.Entity<MenuAccess>(entity =>
        {
            entity.ToTable("MenuAccess");

            entity.Property(e => e.MenuAccessId).HasColumnName("MenuAccessID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.CreatedU).WithMany(p => p.MenuAccesses)
                .HasForeignKey(d => d.CreatedUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuAccess_Users");
        });

        modelBuilder.Entity<NoteSheet>(entity =>
        {
            entity.ToTable("NoteSheet");

            entity.Property(e => e.NoteSheetId).HasColumnName("NoteSheetID");
            entity.Property(e => e.AdjustAmt).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.ApprovedLevel)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.CvId).HasColumnName("CV_ID");
            entity.Property(e => e.DeliveryCharges).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.GrandTotal).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.NetAmount).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Noofapproval)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NOOFAPPROVAL");
            entity.Property(e => e.NoteSheetAnmtype)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("NoteSheetANMtype");
            entity.Property(e => e.NoteSheetDate).HasColumnType("datetime");
            entity.Property(e => e.NoteSheetNo).IsUnicode(false);
            entity.Property(e => e.PurchaseType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.QuotationId).HasColumnName("QuotationID");
            entity.Property(e => e.ReqId).HasColumnName("ReqID");
            entity.Property(e => e.SuppDocName1).HasMaxLength(200);
            entity.Property(e => e.SuppDocName2).HasMaxLength(200);
            entity.Property(e => e.SuppDocName3).HasMaxLength(200);
            entity.Property(e => e.TotalDiscountAmt).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.TotalDiscountPer).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid)
                .HasColumnType("datetime")
                .HasColumnName("UpdatedUID");
            entity.Property(e => e.WorkStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<NoteSheetDetail>(entity =>
        {
            entity.ToTable("NoteSheetDetail");

            entity.Property(e => e.NoteSheetDetailId).HasColumnName("NoteSheetDetailID");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Cst)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("CST");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Discount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.NetAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.NoteSheetId).HasColumnName("NoteSheetID");
            entity.Property(e => e.Qty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ServiceTax).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");
            entity.Property(e => e.Vat)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("VAT");
        });

        modelBuilder.Entity<OldAsset>(entity =>
        {
            entity.HasKey(e => e.OldId).HasName("PK_Old");

            entity.ToTable("OldAsset");

            entity.Property(e => e.OldId).HasColumnName("OldID");
            entity.Property(e => e.AssetCode).HasMaxLength(20);
            entity.Property(e => e.AssetRegId).HasColumnName("AssetRegID");
            entity.Property(e => e.AssetType).HasMaxLength(20);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Grnid).HasColumnName("GRNID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
        });

        modelBuilder.Entity<OldAssetRegister>(entity =>
        {
            entity.HasKey(e => e.OldRegisterId).HasName("PK_OldAsset");

            entity.ToTable("OldAssetRegister");

            entity.Property(e => e.OldRegisterId).HasColumnName("OldRegisterID");
            entity.Property(e => e.AmcendDate)
                .HasColumnType("datetime")
                .HasColumnName("AMCEndDate");
            entity.Property(e => e.AmcstartDate)
                .HasColumnType("datetime")
                .HasColumnName("AMCStartDate");
            entity.Property(e => e.Amount).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.BillDate).HasColumnType("datetime");
            entity.Property(e => e.BillNo).HasMaxLength(50);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.IsAmcasset)
                .HasMaxLength(20)
                .HasColumnName("IsAMCAsset");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemSpecification).IsUnicode(false);
            entity.Property(e => e.Qty).HasColumnType("numeric(12, 0)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.BankBranch).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(50);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.CvId).HasColumnName("CV_ID");
            entity.Property(e => e.Dddate)
                .HasColumnType("datetime")
                .HasColumnName("DDDate");
            entity.Property(e => e.Ddno)
                .HasMaxLength(20)
                .HasColumnName("DDNo");
            entity.Property(e => e.Ifsc)
                .HasMaxLength(50)
                .HasColumnName("IFSC");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.PaidAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PayMode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentNo).HasMaxLength(50);
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
        });

        modelBuilder.Entity<PaymentBillLedger>(entity =>
        {
            entity.HasKey(e => e.PaymentBillLedgerId).HasName("PK__PaymentB__3F4E16BCC42AA33B");

            entity.ToTable("PaymentBillLedger");

            entity.Property(e => e.PaymentBillLedgerId).HasColumnName("PaymentBillLedgerID");
            entity.Property(e => e.BankName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BillDate).HasColumnType("datetime");
            entity.Property(e => e.BillNo)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChqDate).HasColumnType("datetime");
            entity.Property(e => e.ChqNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CrAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.DrAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DrLedger)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FileName).IsUnicode(false);
            entity.Property(e => e.PayType)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PobillId).HasColumnName("POBillID");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.Pono)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PONo");
            entity.Property(e => e.RcptDate).HasColumnType("datetime");
            entity.Property(e => e.RcptNo)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TrnsType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
        });

        modelBuilder.Entity<PaymentTran>(entity =>
        {
            entity.HasKey(e => e.PayTransId).HasName("PK_PurchaseTrans");

            entity.Property(e => e.PayTransId).HasColumnName("PayTransID");
            entity.Property(e => e.BillAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.PayAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.PobillId).HasColumnName("POBillID");
        });

        modelBuilder.Entity<Po>(entity =>
        {
            entity.ToTable("PO");

            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.CvId).HasColumnName("CV_ID");
            entity.Property(e => e.DeliveryCharges).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Experiment).HasMaxLength(200);
            entity.Property(e => e.GrandTotal).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.IsPocancel).HasColumnName("IsPOCancel");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.MonthwiseBillType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NetAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Noofapproval)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NOOFAPPROVAL");
            entity.Property(e => e.NoteSheetId).HasColumnName("NoteSheetID");
            entity.Property(e => e.Pcdays)
                .HasMaxLength(50)
                .HasColumnName("PCDays");
            entity.Property(e => e.Poanmtype)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("POANMType");
            entity.Property(e => e.Poatodate)
                .HasColumnType("datetime")
                .HasColumnName("POATODate");
            entity.Property(e => e.PocancelBy).HasColumnName("POCancelBy");
            entity.Property(e => e.PocancelDate)
                .HasColumnType("datetime")
                .HasColumnName("POCancelDate");
            entity.Property(e => e.PocancelReason)
                .HasColumnType("text")
                .HasColumnName("POCancelReason");
            entity.Property(e => e.Podate)
                .HasColumnType("datetime")
                .HasColumnName("PODate");
            entity.Property(e => e.PolabelType)
                .HasMaxLength(10)
                .HasColumnName("POLabelType");
            entity.Property(e => e.Pono)
                .HasMaxLength(50)
                .HasColumnName("PONo");
            entity.Property(e => e.ProformaAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ProformaInvoiceType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PurchaseType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuotationId).HasColumnName("QuotationID");
            entity.Property(e => e.RefPono)
                .HasMaxLength(50)
                .HasColumnName("RefPONo");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReqId).HasColumnName("ReqID");
            entity.Property(e => e.SourceType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.SuppDocName1).HasMaxLength(250);
            entity.Property(e => e.SuppDocName2).HasMaxLength(250);
            entity.Property(e => e.SuppDocName3).HasMaxLength(250);
            entity.Property(e => e.TotalDiscountAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.TotalDiscountPer).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UnitBillingId).HasColumnName("UnitBillingID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
        });

        modelBuilder.Entity<PoAto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PO_ATO");

            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.CvId).HasColumnName("CV_ID");
            entity.Property(e => e.DeliveryCharges).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Experiment).HasMaxLength(200);
            entity.Property(e => e.GrandTotal).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Justification).HasMaxLength(400);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.NetAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Noofapproval)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NOOFAPPROVAL");
            entity.Property(e => e.NoteSheetId).HasColumnName("NoteSheetID");
            entity.Property(e => e.Pcdays)
                .HasMaxLength(50)
                .HasColumnName("PCDays");
            entity.Property(e => e.Poanmtype)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("POANMType");
            entity.Property(e => e.Podate)
                .HasColumnType("datetime")
                .HasColumnName("PODate");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.PolabelType)
                .HasMaxLength(10)
                .HasColumnName("POLabelType");
            entity.Property(e => e.Pono)
                .HasMaxLength(50)
                .HasColumnName("PONo");
            entity.Property(e => e.PurchaseType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuotationId).HasColumnName("QuotationID");
            entity.Property(e => e.RefPono)
                .HasMaxLength(50)
                .HasColumnName("RefPONo");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReqId).HasColumnName("ReqID");
            entity.Property(e => e.SourceType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.SuppDocName1).HasMaxLength(250);
            entity.Property(e => e.SuppDocName2).HasMaxLength(250);
            entity.Property(e => e.SuppDocName3).HasMaxLength(250);
            entity.Property(e => e.TotalDiscountAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.TotalDiscountPer).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UnitBillingId).HasColumnName("UnitBillingID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
        });

        modelBuilder.Entity<Poadv>(entity =>
        {
            entity.ToTable("POadv");

            entity.HasIndex(e => e.Poid, "ux_poadvPOID").IsUnique();

            entity.Property(e => e.PoadvId).HasColumnName("POadvID");
            entity.Property(e => e.AdvDate).HasColumnType("datetime");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.Remarks).HasMaxLength(50);
            entity.Property(e => e.TotalAdvance).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");

            entity.HasOne(d => d.Po).WithOne(p => p.Poadv)
                .HasForeignKey<Poadv>(d => d.Poid)
                .HasConstraintName("FK_POadv_PO");
        });

        modelBuilder.Entity<PoadvDet>(entity =>
        {
            entity.ToTable("POAdvDet");

            entity.HasIndex(e => e.PoadvId, "ux_poadvdetAdvID").IsUnique();

            entity.HasIndex(e => e.Poid, "ux_poadvdetpoID").IsUnique();

            entity.Property(e => e.PoadvDetId).HasColumnName("POAdvDetID");
            entity.Property(e => e.AdvDate).HasColumnType("datetime");
            entity.Property(e => e.BankBranch).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(50);
            entity.Property(e => e.Dddate)
                .HasColumnType("datetime")
                .HasColumnName("DDDate");
            entity.Property(e => e.Ddno)
                .HasMaxLength(50)
                .HasColumnName("DDNo");
            entity.Property(e => e.DueAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.NetAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PayMode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PayableAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PoadvId).HasColumnName("POadvID");
            entity.Property(e => e.Poid).HasColumnName("POID");
        });

        modelBuilder.Entity<PoadvPayment>(entity =>
        {
            entity.HasKey(e => e.PoadvId);

            entity.ToTable("POAdvPayment");

            entity.Property(e => e.PoadvId).HasColumnName("POAdvID");
            entity.Property(e => e.BankBranch).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(50);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Dddate)
                .HasColumnType("datetime")
                .HasColumnName("DDDate");
            entity.Property(e => e.Ddno)
                .HasMaxLength(20)
                .HasColumnName("DDNo");
            entity.Property(e => e.Ifsc)
                .HasMaxLength(50)
                .HasColumnName("IFSC");
            entity.Property(e => e.PayMode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.Remarks).HasMaxLength(50);
            entity.Property(e => e.TotalAdvance).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
        });

        modelBuilder.Entity<Pobill>(entity =>
        {
            entity.ToTable("POBill");

            entity.Property(e => e.PobillId).HasColumnName("POBillID");
            entity.Property(e => e.AdjustAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ApprovAcctDate).HasColumnType("datetime");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.BillAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.CvId).HasColumnName("CV_ID");
            entity.Property(e => e.CvPobillNo)
                .HasMaxLength(100)
                .HasColumnName("CV_POBillNo");
            entity.Property(e => e.DelCharge).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Gstinclusive).HasColumnName("GSTInclusive");
            entity.Property(e => e.ItemJobType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.PobillDate)
                .HasColumnType("datetime")
                .HasColumnName("POBillDate");
            entity.Property(e => e.PobillNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POBillNo");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.PurchaseType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RcvdHo).HasColumnName("RcvdHO");
            entity.Property(e => e.RcvdHodate)
                .HasColumnType("datetime")
                .HasColumnName("RcvdHOdate");
            entity.Property(e => e.RcvdSiteDate).HasColumnType("datetime");
            entity.Property(e => e.RefPobillNo)
                .HasMaxLength(50)
                .HasColumnName("RefPOBillNo");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.Sent2AcctDate).HasColumnType("datetime");
            entity.Property(e => e.Sent2AuditDate).HasColumnType("datetime");
            entity.Property(e => e.Sent2PurcDate).HasColumnType("datetime");
            entity.Property(e => e.SuppDoc1).HasMaxLength(250);
            entity.Property(e => e.SuppDoc2).HasMaxLength(250);
            entity.Property(e => e.SuppDoc3).HasMaxLength(250);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
        });

        modelBuilder.Entity<PobillDetail>(entity =>
        {
            entity.ToTable("POBillDetail");

            entity.Property(e => e.PobillDetailId).HasColumnName("POBillDetailID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Cst)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("CST");
            entity.Property(e => e.Discount).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.Grnid).HasColumnName("GRNID");
            entity.Property(e => e.Grnrate)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("GRNRate");
            entity.Property(e => e.GrnrecQty)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("GRNRecQty");
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.NetAmount).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.PoDetId).HasColumnName("PoDetID");
            entity.Property(e => e.PobillId).HasColumnName("POBillID");
            entity.Property(e => e.Qty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ServiceTax).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");
            entity.Property(e => e.Vat)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("VAT");
        });

        modelBuilder.Entity<PobillItemDetail>(entity =>
        {
            entity.ToTable("POBillItemDetail");

            entity.Property(e => e.PobillItemDetailId).HasColumnName("POBillItemDetailID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Grnid).HasColumnName("GRNID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.PobilllDetailId).HasColumnName("POBilllDetailID");
            entity.Property(e => e.Qty).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");

            entity.HasOne(d => d.PobilllDetail).WithMany(p => p.PobillItemDetails)
                .HasForeignKey(d => d.PobilllDetailId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_POBillItemDetail_POBillDetail");
        });

        modelBuilder.Entity<Podetail>(entity =>
        {
            entity.ToTable("PODetail");

            entity.Property(e => e.PodetailId).HasColumnName("PODetailID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Cst)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("CST");
            entity.Property(e => e.DiscountPer).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.DiscountRs)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("DiscountRS");
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.NetAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.Qty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.RemQty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ServiceTax).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");
            entity.Property(e => e.Vat)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("VAT");
        });

        modelBuilder.Entity<PodetailAto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PODetail_ATO");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Cst)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("CST");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DiscountPer).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.DiscountRs)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("DiscountRS");
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.NetAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PodetailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PODetailID");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.Qty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.RemQty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ServiceTax).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");
            entity.Property(e => e.Vat)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("VAT");
        });

        modelBuilder.Entity<Prefix>(entity =>
        {
            entity.ToTable("Prefix");

            entity.Property(e => e.PrefixId).HasColumnName("PrefixID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.PrefixType)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PrefixValue)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
        });

        modelBuilder.Entity<PurchasePayDet>(entity =>
        {
            entity.HasKey(e => e.PayDetId);

            entity.ToTable("PurchasePayDet");

            entity.Property(e => e.PayDetId).HasColumnName("PayDetID");
            entity.Property(e => e.Bdid).HasColumnName("BDID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Cst)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("CST");
            entity.Property(e => e.Discount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.DueAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.GrossAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.NetAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.ServTax).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Vat)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("VAT");

            entity.HasOne(d => d.Payment).WithMany(p => p.PurchasePayDets)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchasePayDet_PuchasePayment");
        });

        modelBuilder.Entity<PurchasePayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK_PuchasePayment");

            entity.ToTable("PurchasePayment");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.AdvAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.BankBranch).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(50);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.CvId).HasColumnName("CV_ID");
            entity.Property(e => e.Dddate)
                .HasColumnType("datetime")
                .HasColumnName("DDDate");
            entity.Property(e => e.Ddno)
                .HasMaxLength(20)
                .HasColumnName("DDNo");
            entity.Property(e => e.DelCharge).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.DueAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Ifsc)
                .HasMaxLength(50)
                .HasColumnName("IFSC");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.PaidAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PayDate).HasColumnType("datetime");
            entity.Property(e => e.PayMode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PaymentNo).HasMaxLength(50);
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
        });

        modelBuilder.Entity<Quotation>(entity =>
        {
            entity.ToTable("Quotation");

            entity.Property(e => e.QuotationId).HasColumnName("QuotationID");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.CvId).HasColumnName("CV_ID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Experiment).HasMaxLength(500);
            entity.Property(e => e.Justification).HasMaxLength(500);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Noofapproval)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NOOFAPPROVAL");
            entity.Property(e => e.PurchaseType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuotationAnmtype)
                .HasMaxLength(10)
                .HasColumnName("QuotationANMType");
            entity.Property(e => e.QuotationDate).HasColumnType("datetime");
            entity.Property(e => e.RefQuotationNo).IsUnicode(false);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.ReqId).HasColumnName("ReqID");
            entity.Property(e => e.SuppDocName1).HasMaxLength(500);
            entity.Property(e => e.SuppDocName2).HasMaxLength(500);
            entity.Property(e => e.SuppDocName3).HasMaxLength(500);
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
            entity.Property(e => e.WorkStatus)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Area).WithMany(p => p.Quotations)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK_Quotation_Area");

            entity.HasOne(d => d.Company).WithMany(p => p.Quotations)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Quotation_Company");

            entity.HasOne(d => d.Cv).WithMany(p => p.Quotations)
                .HasForeignKey(d => d.CvId)
                .HasConstraintName("FK_Quotation_CustomerVendor");
        });

        modelBuilder.Entity<QuotationDetail>(entity =>
        {
            entity.ToTable("QuotationDetail");

            entity.Property(e => e.QuotationDetailId).HasColumnName("QuotationDetailID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Igst)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("igst");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.NetAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Qty).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.QuotationId).HasColumnName("QuotationID");
            entity.Property(e => e.Rate).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.ServiceTax).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");
            entity.Property(e => e.Vat)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("VAT");
        });

        modelBuilder.Entity<Req>(entity =>
        {
            entity.ToTable("Req");

            entity.Property(e => e.ReqId).HasColumnName("ReqID");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.BackwardDate).HasColumnType("datetime");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.ContactNo).HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Experiment).HasMaxLength(500);
            entity.Property(e => e.ForwordDate).HasColumnType("datetime");
            entity.Property(e => e.ForwordId).HasColumnName("ForwordID");
            entity.Property(e => e.ForwordStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InitBy).HasMaxLength(50);
            entity.Property(e => e.Justification).HasMaxLength(500);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Noofapproval)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("NOOFAPPROVAL");
            entity.Property(e => e.RefReqNo).IsUnicode(false);
            entity.Property(e => e.RejectRemarks)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.ReqAnmtype)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ReqANMType");
            entity.Property(e => e.ReqDate).HasColumnType("datetime");
            entity.Property(e => e.ReqNo).HasMaxLength(100);
            entity.Property(e => e.ReqType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SuppDocName1).HasMaxLength(500);
            entity.Property(e => e.SuppDocName2).HasMaxLength(500);
            entity.Property(e => e.SuppDocName3).HasMaxLength(500);
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
            entity.Property(e => e.WorkStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReqDeleted>(entity =>
        {
            entity.HasKey(e => e.ReqId);

            entity.ToTable("Req_Deleted");

            entity.Property(e => e.ReqId).HasColumnName("ReqID");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.ContactNo).HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Experiment).HasMaxLength(100);
            entity.Property(e => e.InitBy).HasMaxLength(50);
            entity.Property(e => e.Justification).HasMaxLength(500);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Noofapproval).HasColumnName("NOOFAPPROVAL");
            entity.Property(e => e.RefReqNo).IsUnicode(false);
            entity.Property(e => e.RejectRemarks)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.ReqAnmtype)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ReqANMType");
            entity.Property(e => e.ReqDate).HasColumnType("datetime");
            entity.Property(e => e.ReqNo).HasMaxLength(100);
            entity.Property(e => e.ReqType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SuppDocName1).HasMaxLength(50);
            entity.Property(e => e.SuppDocName2).HasMaxLength(50);
            entity.Property(e => e.SuppDocName3).HasMaxLength(50);
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
            entity.Property(e => e.WorkStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReqDetail>(entity =>
        {
            entity.ToTable("ReqDetail");

            entity.Property(e => e.ReqDetailId).HasColumnName("ReqDetailID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Qty).HasColumnType("numeric(10, 3)");
            entity.Property(e => e.Rate).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.ReqId).HasColumnName("ReqID");
            entity.Property(e => e.ReqType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");

            entity.HasOne(d => d.Company).WithMany(p => p.ReqDetails)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_ReqDetail_Company");
        });

        modelBuilder.Entity<SecurityQuestion>(entity =>
        {
            entity.HasKey(e => e.SecurityId);

            entity.ToTable("SecurityQuestion");

            entity.Property(e => e.SecurityId).HasColumnName("SecurityID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.ForSecurity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecurityQuestion1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("SecurityQuestion");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUid).HasColumnName("UpdateUID");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("State");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.StateId)
                .ValueGeneratedOnAdd()
                .HasColumnName("StateID");
            entity.Property(e => e.StateName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stc>(entity =>
        {
            entity.ToTable("STC");

            entity.Property(e => e.Stcid).HasColumnName("STCID");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.DestAreaId).HasColumnName("DestAreaID");
            entity.Property(e => e.DestLocationId).HasColumnName("DestLocationID");
            entity.Property(e => e.DestUnitId).HasColumnName("DestUnitID");
            entity.Property(e => e.IndentId).HasColumnName("IndentID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.RefStcno)
                .HasMaxLength(50)
                .HasColumnName("RefSTCNo");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.ReqId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ReqID");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Stcdate)
                .HasColumnType("datetime")
                .HasColumnName("STCDate");
            entity.Property(e => e.Stcno)
                .HasMaxLength(50)
                .HasColumnName("STCNo");
            entity.Property(e => e.StockType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
        });

        modelBuilder.Entity<Stcdetail>(entity =>
        {
            entity.ToTable("STCDetail");

            entity.Property(e => e.StcdetailId)
                .ValueGeneratedNever()
                .HasColumnName("STCDetailID");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Qty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.Stcid).HasColumnName("STCID");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");

            entity.HasOne(d => d.Stc).WithMany(p => p.Stcdetails)
                .HasForeignKey(d => d.Stcid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_STCDetail_STC");
        });

        modelBuilder.Entity<StockDepartment>(entity =>
        {
            entity.ToTable("StockDepartment");

            entity.Property(e => e.StockDepartmentId).HasColumnName("StockDepartmentID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("date");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.SdDescription)
                .IsUnicode(false)
                .HasColumnName("SD_Description");
            entity.Property(e => e.StockDepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
        });

        modelBuilder.Entity<StudentPortalPaymentAccess>(entity =>
        {
            entity.HasKey(e => e.PaymentAccessId);

            entity.ToTable("StudentPortalPaymentAccess");
        });

        modelBuilder.Entity<TempAsset>(entity =>
        {
            entity.HasKey(e => e.AssetId);

            entity.ToTable("Temp_Asset");

            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssetCode).HasMaxLength(100);
            entity.Property(e => e.BookValue).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.BookValueOpBal).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.DepreciationAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.DepreciationMethod)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Grnid).HasColumnName("GRNID");
            entity.Property(e => e.ItemCode).HasMaxLength(100);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.PurchasePrice).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Sflag).HasColumnName("sflag");
            entity.Property(e => e.Year).HasColumnType("numeric(4, 0)");
        });

        modelBuilder.Entity<TempAsset27april2018>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Temp_Asset_27April2018");

            entity.Property(e => e.AssetCode).HasMaxLength(100);
            entity.Property(e => e.AssetId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AssetID");
            entity.Property(e => e.BookValue).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.BookValueOpBal).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.DepreciationAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.DepreciationMethod)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Grnid).HasColumnName("GRNID");
            entity.Property(e => e.ItemCode).HasMaxLength(100);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.PurchasePrice).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Sflag).HasColumnName("sflag");
            entity.Property(e => e.Year).HasColumnType("numeric(4, 0)");
        });

        modelBuilder.Entity<TempCanceledPo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Temp_Canceled_PO");

            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CollegeId).HasColumnName("CollegeID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.CvId).HasColumnName("CV_ID");
            entity.Property(e => e.DeliveryCharges).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Experiment).HasMaxLength(200);
            entity.Property(e => e.GrandTotal).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.MonthwiseBillType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NetAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Noofapproval)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NOOFAPPROVAL");
            entity.Property(e => e.NoteSheetId).HasColumnName("NoteSheetID");
            entity.Property(e => e.Pcdays)
                .HasMaxLength(50)
                .HasColumnName("PCDays");
            entity.Property(e => e.Poanmtype)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("POANMType");
            entity.Property(e => e.Podate)
                .HasColumnType("datetime")
                .HasColumnName("PODate");
            entity.Property(e => e.Poid)
                .ValueGeneratedOnAdd()
                .HasColumnName("POID");
            entity.Property(e => e.PolabelType)
                .HasMaxLength(10)
                .HasColumnName("POLabelType");
            entity.Property(e => e.Pono)
                .HasMaxLength(50)
                .HasColumnName("PONo");
            entity.Property(e => e.PurchaseType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuotationId).HasColumnName("QuotationID");
            entity.Property(e => e.RefPono)
                .HasMaxLength(50)
                .HasColumnName("RefPONo");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReqId).HasColumnName("ReqID");
            entity.Property(e => e.SourceType)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.SuppDocName1).HasMaxLength(250);
            entity.Property(e => e.SuppDocName2).HasMaxLength(250);
            entity.Property(e => e.SuppDocName3).HasMaxLength(250);
            entity.Property(e => e.TotalDiscountAmt).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.TotalDiscountPer).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UnitBillingId).HasColumnName("UnitBillingID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
        });

        modelBuilder.Entity<TempCanceledPodetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Temp_Canceled_PODetail");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Cst)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("CST");
            entity.Property(e => e.DiscountPer).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.DiscountRs)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("DiscountRS");
            entity.Property(e => e.GrossAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.NetAmount).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.PodetailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PODetailID");
            entity.Property(e => e.Poid).HasColumnName("POID");
            entity.Property(e => e.Qty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.RemQty).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ServiceTax).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Uomid).HasColumnName("UOMID");
            entity.Property(e => e.Vat)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("VAT");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("Unit");

            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.LogoUrl).IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Sbucode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SBUcode");
            entity.Property(e => e.Sbutype)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SBUType");
            entity.Property(e => e.ShortCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UnitName).IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUid).HasColumnName("UpdateUID");
        });

        modelBuilder.Entity<UnitLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId);

            entity.ToTable("UnitLocation");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
        });

        modelBuilder.Entity<Uom>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UOM");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Uomid)
                .ValueGeneratedOnAdd()
                .HasColumnName("UOMID");
            entity.Property(e => e.Uomname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UOMname");
            entity.Property(e => e.Uomtype)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UOMtype");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.DigitalSignPath).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).IsUnicode(false);
            entity.Property(e => e.LastName).IsUnicode(false);
            entity.Property(e => e.LastOtpDate).HasColumnType("datetime");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName).IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.RefreshTokenExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.RefreshTokenStartDate).HasColumnType("datetime");
            entity.Property(e => e.RegDate).HasColumnType("datetime");
            entity.Property(e => e.Sbutype)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SBUType");
            entity.Property(e => e.SecurityAnswer1).IsUnicode(false);
            entity.Property(e => e.SecurityAnswer2).IsUnicode(false);
            entity.Property(e => e.SecurityQuestion1).IsUnicode(false);
            entity.Property(e => e.SecurityQuestion2).IsUnicode(false);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserUnit>(entity =>
        {
            entity.HasKey(e => e.UserUnitId).HasName("PK__UserUnit__2DC94419EF431346");

            entity.ToTable("UserUnit");

            entity.Property(e => e.UserUnitId).HasColumnName("UserUnitID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.Sbutype)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SBUType");
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UnitName).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedUid).HasColumnName("UpdatedUID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<UserWorkApproval>(entity =>
        {
            entity.HasKey(e => e.Uaid).HasName("PK_UserApproval");

            entity.ToTable("UserWorkApproval");

            entity.Property(e => e.Uaid).HasColumnName("UAID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserWorkFlowId).HasColumnName("UserWorkFlowID");
        });

        modelBuilder.Entity<UsersUnit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UsersUnit");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<VwBank>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_Bank");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BankId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BankID");
            entity.Property(e => e.BankName)
                .HasMaxLength(103)
                .IsUnicode(false);
            entity.Property(e => e.IfscCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ifsc_Code");
        });

        modelBuilder.Entity<WorkFlow>(entity =>
        {
            entity.ToTable("WorkFlow");

            entity.Property(e => e.WorkFlowId).HasColumnName("WorkFlowID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.WorkFlowName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
