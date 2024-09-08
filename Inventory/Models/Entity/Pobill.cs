﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Pobill
{
    public long PobillId { get; set; }

    public DateTime? PobillDate { get; set; }

    public string? PobillNo { get; set; }

    public string? CvPobillNo { get; set; }

    public string? RefPobillNo { get; set; }

    public long? Poid { get; set; }

    public long? CvId { get; set; }

    public long? UnitId { get; set; }

    public long? LocationId { get; set; }

    public long? AreaId { get; set; }

    public string Description { get; set; } = null!;

    public string? Remarks { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public long? CollegeId { get; set; }

    public bool? ApprovedStatus { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? ApprovalStatus { get; set; }

    public byte? ApprovedLevel { get; set; }

    public string? SuppDoc1 { get; set; }

    public string? SuppDoc2 { get; set; }

    public string? SuppDoc3 { get; set; }

    public bool? RcvdSite { get; set; }

    public DateTime? RcvdSiteDate { get; set; }

    public bool? RcvdHo { get; set; }

    public DateTime? RcvdHodate { get; set; }

    public bool? Sent2Audit { get; set; }

    public DateTime? Sent2AuditDate { get; set; }

    public bool? Sent2Purch { get; set; }

    public DateTime? Sent2PurcDate { get; set; }

    public bool? Sent2Acct { get; set; }

    public DateTime? Sent2AcctDate { get; set; }

    public bool? Approved { get; set; }

    public DateTime? ApprovAcctDate { get; set; }

    public bool? Paid { get; set; }

    public decimal? BillAmount { get; set; }

    public decimal? DelCharge { get; set; }

    public decimal? AdjustAmount { get; set; }

    public string? ItemJobType { get; set; }

    public string? PurchaseType { get; set; }

    public bool? Gstinclusive { get; set; }

    public bool? RateContract { get; set; }
}
