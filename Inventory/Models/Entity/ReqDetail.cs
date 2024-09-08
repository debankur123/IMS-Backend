﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class ReqDetail
{
    public long ReqDetailId { get; set; }

    public long? ReqId { get; set; }

    public long? ItemId { get; set; }

    public string? ReqType { get; set; }

    public decimal? Qty { get; set; }

    public decimal? Rate { get; set; }

    public decimal? GrossAmount { get; set; }

    public long? Uomid { get; set; }

    public long? AssetId { get; set; }

    public long? UnitId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Description { get; set; }

    public virtual Company? Company { get; set; }
}
