﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Grndetail
{
    public long GrndetailId { get; set; }

    public long? Grnid { get; set; }

    public long? ItemId { get; set; }

    public string? Description { get; set; }

    public decimal? OrderQty { get; set; }

    public decimal? Rate { get; set; }

    public decimal? Total { get; set; }

    public decimal? RemQty { get; set; }

    public decimal? RecQty { get; set; }

    public decimal? RecItemTotal { get; set; }

    public long? Uomid { get; set; }

    public DateTime? Qcdate { get; set; }

    public long? Qcby { get; set; }

    public string? Qcstatus { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? PdId { get; set; }

    public virtual Company? Company { get; set; }
}
