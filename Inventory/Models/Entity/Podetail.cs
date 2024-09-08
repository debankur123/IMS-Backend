﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Podetail
{
    public long PodetailId { get; set; }

    public long? Poid { get; set; }

    public string? Description { get; set; }

    public long? ItemId { get; set; }

    public decimal? Qty { get; set; }

    public decimal? RemQty { get; set; }

    public decimal? Rate { get; set; }

    public long? Uomid { get; set; }

    public decimal? GrossAmount { get; set; }

    public decimal? Vat { get; set; }

    public decimal? ServiceTax { get; set; }

    public decimal? DiscountPer { get; set; }

    public decimal? DiscountRs { get; set; }

    public decimal? Cst { get; set; }

    public decimal? NetAmount { get; set; }

    public long? UnitId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }
}
