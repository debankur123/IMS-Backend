﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class ItemStock
{
    public long ItemStockId { get; set; }

    public long ItemId { get; set; }

    public long UnitId { get; set; }

    public long? AreaId { get; set; }

    public long? LocationId { get; set; }

    public decimal? Soh { get; set; }

    public long? Uomid { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreatedDate { get; set; }

    public long? GrnId { get; set; }

    public long? StockQty { get; set; }

    public string? StockType { get; set; }

    public long? TransferId { get; set; }

    public long? StockDepartmentId { get; set; }

    public string? ItemDescription { get; set; }

    public string? IssuedPerson { get; set; }

    public DateTime? IssuedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual Area? Area { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
