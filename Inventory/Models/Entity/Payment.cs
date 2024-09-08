﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Payment
{
    public long PaymentId { get; set; }

    public string? PaymentNo { get; set; }

    public long? Poid { get; set; }

    public long? UnitId { get; set; }

    public long? AreaId { get; set; }

    public long? LocationId { get; set; }

    public long? CvId { get; set; }

    public decimal? PaidAmt { get; set; }

    public string? PayMode { get; set; }

    public DateTime? PaymentDate { get; set; }

    public DateTime? Dddate { get; set; }

    public string? Ddno { get; set; }

    public string? BankName { get; set; }

    public string? BankBranch { get; set; }

    public string? Ifsc { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
