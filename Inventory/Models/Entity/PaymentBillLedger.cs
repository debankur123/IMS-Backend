﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class PaymentBillLedger
{
    public long PaymentBillLedgerId { get; set; }

    public long? PobillId { get; set; }

    public long? UnitId { get; set; }

    public long? VendorId { get; set; }

    public long? Poid { get; set; }

    public string? Pono { get; set; }

    public string? TrnsType { get; set; }

    public string? BillNo { get; set; }

    public DateTime? BillDate { get; set; }

    public decimal? DrAmt { get; set; }

    public decimal? CrAmt { get; set; }

    public string? RcptNo { get; set; }

    public DateTime? RcptDate { get; set; }

    public string? PayType { get; set; }

    public string? DrLedger { get; set; }

    public string? BankName { get; set; }

    public string? ChqNo { get; set; }

    public DateTime? ChqDate { get; set; }

    public string? FileName { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? Layer { get; set; }
}
