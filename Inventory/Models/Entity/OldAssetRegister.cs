﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class OldAssetRegister
{
    public long OldRegisterId { get; set; }

    public long? ItemId { get; set; }

    public string? ItemSpecification { get; set; }

    public long? VendorId { get; set; }

    public DateTime? BillDate { get; set; }

    public string? BillNo { get; set; }

    public decimal? Qty { get; set; }

    public decimal? Amount { get; set; }

    public string? IsAmcasset { get; set; }

    public DateTime? AmcstartDate { get; set; }

    public DateTime? AmcendDate { get; set; }

    public long CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
