﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Quotation
{
    public long QuotationId { get; set; }

    public string? Type { get; set; }

    public string? PurchaseType { get; set; }

    public string? QuotationNo { get; set; }

    public string? QuotationAnmtype { get; set; }

    public string? RefQuotationNo { get; set; }

    public string? ReqNo { get; set; }

    public long? ReqId { get; set; }

    public DateTime? QuotationDate { get; set; }

    public long? CvId { get; set; }

    public long? UnitId { get; set; }

    public long? LocationId { get; set; }

    public long? AreaId { get; set; }

    public string? Experiment { get; set; }

    public string Description { get; set; } = null!;

    public string? Justification { get; set; }

    public string? Remarks { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public long? CollegeId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? TermCond { get; set; }

    public string? TermCond1 { get; set; }

    public string? WorkStatus { get; set; }

    public string? ApprovalStatus { get; set; }

    public string? Noofapproval { get; set; }

    public byte? ApprovedLevel { get; set; }

    public byte[]? SuppDoc1 { get; set; }

    public byte[]? SuppDoc2 { get; set; }

    public byte[]? SuppDoc3 { get; set; }

    public string? SuppDocName1 { get; set; }

    public string? SuppDocName2 { get; set; }

    public string? SuppDocName3 { get; set; }

    public virtual Area? Area { get; set; }

    public virtual Company? Company { get; set; }

    public virtual CustomerVendor? Cv { get; set; }
}
