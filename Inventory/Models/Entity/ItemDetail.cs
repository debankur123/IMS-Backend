﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class ItemDetail
{
    public long ItemDetailId { get; set; }

    public long ItemId { get; set; }

    public string? ItemCode { get; set; }

    public long? ReqId { get; set; }

    public long? IndentId { get; set; }

    public long? QuotationId { get; set; }

    public string? Grnid { get; set; }

    public long? Poid { get; set; }

    public long? PobillId { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? Serial { get; set; }

    public string? LogBookSerial { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public DateTime? InstallationDate { get; set; }

    public DateTime? Expdate { get; set; }

    public byte? WarrantyTerm { get; set; }

    public string? WarrantyDetail { get; set; }

    public long? AmcProviderId { get; set; }

    public DateTime? AmcStartDate { get; set; }

    public DateTime? AmcRenewDate { get; set; }

    public string? AmcScope { get; set; }

    public decimal? AmcValue { get; set; }

    public string? AmcType { get; set; }

    public long? SupplierId { get; set; }

    public string? SupplierContactNo { get; set; }

    public string? Status { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Item Item { get; set; } = null!;
}
