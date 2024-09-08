﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class PobillDetail
{
    public long PobillDetailId { get; set; }

    public long? PoDetId { get; set; }

    public long? PobillId { get; set; }

    public long? Grnid { get; set; }

    public decimal? GrossAmount { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Vat { get; set; }

    public decimal? ServiceTax { get; set; }

    public decimal? Cst { get; set; }

    public decimal? NetAmount { get; set; }

    public long? UnitId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? ItemId { get; set; }

    public decimal? Qty { get; set; }

    public long? Uomid { get; set; }

    public decimal? GrnrecQty { get; set; }

    public decimal? Grnrate { get; set; }

    public virtual ICollection<PobillItemDetail> PobillItemDetails { get; set; } = new List<PobillItemDetail>();
}
