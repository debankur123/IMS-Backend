﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Poadv
{
    public long PoadvId { get; set; }

    public long? Poid { get; set; }

    public DateTime? AdvDate { get; set; }

    public decimal? TotalAdvance { get; set; }

    public long? UnitId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? UpdatedUid { get; set; }

    public string? Remarks { get; set; }

    public virtual Po? Po { get; set; }
}
