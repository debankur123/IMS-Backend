﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Grn
{
    public long Grnid { get; set; }

    public long? Poid { get; set; }

    public string? ChallanNo { get; set; }

    public DateTime? ChallanDate { get; set; }

    public string? Grnno { get; set; }

    public string? DeliveryBy { get; set; }

    public string? QcBy { get; set; }

    public DateTime? QcDate { get; set; }

    public string? QcRemarks { get; set; }

    public string? TransportMode { get; set; }

    public string? TransportNo { get; set; }

    public string? DescripTion { get; set; }

    public string? RefGrnno { get; set; }

    public DateTime? Grndate { get; set; }

    public string? Remarks { get; set; }

    public long? ReceivedBy { get; set; }

    public long? InspectedBy { get; set; }

    public DateTime? InspectDate { get; set; }

    public long? UnitId { get; set; }

    public long? LocationId { get; set; }

    public long? AreaId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? SuppDocName1 { get; set; }

    public byte[]? SuppDoc1 { get; set; }

    public string? SuppDocName2 { get; set; }

    public byte[]? SuppDoc2 { get; set; }

    public string? SuppDocName3 { get; set; }

    public byte[]? SuppDoc3 { get; set; }

    public long? ApprovedBy { get; set; }

    public string? ApprovalStatus { get; set; }

    public byte? ApprovedLevel { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedUid { get; set; }

    public virtual Company? Company { get; set; }

    public virtual User? ReceivedByNavigation { get; set; }
}
