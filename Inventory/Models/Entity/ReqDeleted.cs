﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class ReqDeleted
{
    public long ReqId { get; set; }

    public string? RefReqNo { get; set; }

    public string? ReqNo { get; set; }

    public DateTime? ReqDate { get; set; }

    public string? ReqType { get; set; }

    public string? Type { get; set; }

    public string? ReqAnmtype { get; set; }

    public string? WorkStatus { get; set; }

    public long? UnitId { get; set; }

    public long? LocationId { get; set; }

    public long? AreaId { get; set; }

    public string? Description { get; set; }

    public string? Justification { get; set; }

    public string? Remarks { get; set; }

    public string? Experiment { get; set; }

    public string? RejectRemarks { get; set; }

    public long? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? ApprovalStatus { get; set; }

    public byte? ApprovedLevel { get; set; }

    public string? SuppDocName1 { get; set; }

    public byte[]? SuppDoc1 { get; set; }

    public string? SuppDocName2 { get; set; }

    public byte[]? SuppDoc2 { get; set; }

    public string? SuppDocName3 { get; set; }

    public byte[]? SuppDoc3 { get; set; }

    public int? Noofapproval { get; set; }

    public string? ContactNo { get; set; }

    public string? InitBy { get; set; }

    public string? ProcessRemarks { get; set; }
}
