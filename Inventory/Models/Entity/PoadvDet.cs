﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class PoadvDet
{
    public long PoadvDetId { get; set; }

    public long PoadvId { get; set; }

    public long Poid { get; set; }

    public string? PayMode { get; set; }

    public DateTime? Dddate { get; set; }

    public string? Ddno { get; set; }

    public string? BankName { get; set; }

    public string? BankBranch { get; set; }

    public decimal? GrossAmount { get; set; }

    public decimal? NetAmount { get; set; }

    public decimal? DueAmount { get; set; }

    public decimal? PayableAmt { get; set; }

    public DateTime? AdvDate { get; set; }
}
