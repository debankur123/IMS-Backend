﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Stc
{
    public long Stcid { get; set; }

    public string? Stcno { get; set; }

    public string? RefStcno { get; set; }

    public long? IndentId { get; set; }

    public DateTime? Stcdate { get; set; }

    public string? StockType { get; set; }

    public string? Type { get; set; }

    public long? UnitId { get; set; }

    public long? LocationId { get; set; }

    public long? AreaId { get; set; }

    public long? DestUnitId { get; set; }

    public long? DestLocationId { get; set; }

    public long? DestAreaId { get; set; }

    public string? Description { get; set; }

    public string? Remarks { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string? Status { get; set; }

    public long? CollegeId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? ReqId { get; set; }

    public string? ApprovalStatus { get; set; }

    public byte? ApprovedLevel { get; set; }

    public virtual ICollection<Stcdetail> Stcdetails { get; set; } = new List<Stcdetail>();
}
