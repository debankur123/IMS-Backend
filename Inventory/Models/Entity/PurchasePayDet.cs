﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class PurchasePayDet
{
    public long PayDetId { get; set; }

    public long PaymentId { get; set; }

    public long? BillId { get; set; }

    public long? Poid { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? GrossAmt { get; set; }

    public decimal? Discount { get; set; }

    public decimal? ServTax { get; set; }

    public decimal? Vat { get; set; }

    public decimal? Cst { get; set; }

    public decimal? NetAmt { get; set; }

    public long? UnitId { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public decimal? DueAmt { get; set; }

    public long? Bdid { get; set; }

    public virtual PurchasePayment Payment { get; set; } = null!;
}
