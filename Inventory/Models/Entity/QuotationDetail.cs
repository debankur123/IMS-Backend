﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class QuotationDetail
{
    public long QuotationDetailId { get; set; }

    public long? QuotationId { get; set; }

    public string? Description { get; set; }

    public long? ItemId { get; set; }

    public decimal? Qty { get; set; }

    public decimal? Rate { get; set; }

    public long? Uomid { get; set; }

    public decimal? GrossAmount { get; set; }

    public decimal? Vat { get; set; }

    public decimal? ServiceTax { get; set; }

    public decimal? Igst { get; set; }

    public decimal? NetAmount { get; set; }

    public long? UnitId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }
}
