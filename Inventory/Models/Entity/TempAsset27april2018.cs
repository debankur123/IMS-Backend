﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class TempAsset27april2018
{
    public long AssetId { get; set; }

    public string? AssetCode { get; set; }

    public long ItemId { get; set; }

    public string? ItemCode { get; set; }

    public long? Grnid { get; set; }

    public decimal? Year { get; set; }

    public decimal? PurchasePrice { get; set; }

    public decimal? BookValueOpBal { get; set; }

    public string? DepreciationMethod { get; set; }

    public decimal? DepreciationAmt { get; set; }

    public decimal? BookValue { get; set; }

    public bool? Sflag { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public long? ToValue { get; set; }
}
