﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class PobillItemDetail
{
    public long PobillItemDetailId { get; set; }

    public long? PobilllDetailId { get; set; }

    public long? Grnid { get; set; }

    public long? ItemId { get; set; }

    public decimal? Qty { get; set; }

    public long? Uomid { get; set; }

    public long? UnitId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual PobillDetail? PobilllDetail { get; set; }
}
