﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Item
{
    public long ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public long? ItemCode { get; set; }

    public string? ItemDescHtml { get; set; }

    public int? UnitId { get; set; }

    public int? LocationId { get; set; }

    public int? AreaId { get; set; }

    public string? Exprement { get; set; }

    public decimal? Rate { get; set; }

    public decimal? Rol { get; set; }

    public decimal? Rqty { get; set; }

    public long? Uomid { get; set; }

    public int? StoreUomid { get; set; }

    public decimal? Soh { get; set; }

    public long? ItemSubGroupId { get; set; }

    public decimal? Vat { get; set; }

    public decimal? ServiceTax { get; set; }

    public byte? AssetTypeId { get; set; }

    public string? ItemType { get; set; }

    public bool? IsActive { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? ItemShortCode { get; set; }

    public virtual ICollection<ItemDetail> ItemDetails { get; set; } = new List<ItemDetail>();

    public virtual ICollection<ItemStock> ItemStocks { get; set; } = new List<ItemStock>();
}
