﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Stcdetail
{
    public long StcdetailId { get; set; }

    public long? Stcid { get; set; }

    public long? ItemId { get; set; }

    public decimal? Qty { get; set; }

    public decimal? Rate { get; set; }

    public long? Uomid { get; set; }

    public string? Remarks { get; set; }

    public long? CollegeId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual Stc? Stc { get; set; }
}
