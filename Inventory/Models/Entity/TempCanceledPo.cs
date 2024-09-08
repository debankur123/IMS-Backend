﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class TempCanceledPo
{
    public long Poid { get; set; }

    public string? Type { get; set; }

    public string? PurchaseType { get; set; }

    public string? PolabelType { get; set; }

    public string? Poanmtype { get; set; }

    public long? ReqId { get; set; }

    public long QuotationId { get; set; }

    public long? NoteSheetId { get; set; }

    public string? Pono { get; set; }

    public string? Pcdays { get; set; }

    public string? RefPono { get; set; }

    public DateTime? Podate { get; set; }

    public long? CvId { get; set; }

    public long? UnitId { get; set; }

    public long? LocationId { get; set; }

    public long? AreaId { get; set; }

    public decimal? GrandTotal { get; set; }

    public decimal? GrossAmount { get; set; }

    public decimal? TotalDiscountAmt { get; set; }

    public decimal? TotalDiscountPer { get; set; }

    public decimal? DeliveryCharges { get; set; }

    public decimal? NetAmount { get; set; }

    public string? Description { get; set; }

    public string? Remarks { get; set; }

    public string? TermCond { get; set; }

    public string? TermCond1 { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public long? CollegeId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? ApprovalStatus { get; set; }

    public byte? ApprovedLevel { get; set; }

    public string? SuppDocName1 { get; set; }

    public string? SuppDocName2 { get; set; }

    public string? SuppDocName3 { get; set; }

    public byte[]? SuppDoc1 { get; set; }

    public byte[]? SuppDoc2 { get; set; }

    public byte[]? SuppDoc3 { get; set; }

    public string? Noofapproval { get; set; }

    public string? Experiment { get; set; }

    public string? Justification { get; set; }

    public int? DigitalSign { get; set; }

    public int? Paid { get; set; }

    public bool? Billed { get; set; }

    public string? SourceType { get; set; }

    public long? UnitBillingId { get; set; }

    public string? MonthwiseBillType { get; set; }
}
