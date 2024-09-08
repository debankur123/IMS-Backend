﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Area
{
    public long AreaId { get; set; }

    public string AreaName { get; set; } = null!;

    public long? UnitId { get; set; }

    public string? AreaCode { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<ItemStock> ItemStocks { get; set; } = new List<ItemStock>();

    public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();
}
