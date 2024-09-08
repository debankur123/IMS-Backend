﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Unit
{
    public long UnitId { get; set; }

    public string UnitName { get; set; } = null!;

    public string? Sbutype { get; set; }

    public string? Sbucode { get; set; }

    public string? ShortCode { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? LogoUrl { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public long? UpdateUid { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime CreateDate { get; set; }

    public byte[]? ImageData { get; set; }

    public virtual ICollection<ItemStock> ItemStocks { get; set; } = new List<ItemStock>();
}
