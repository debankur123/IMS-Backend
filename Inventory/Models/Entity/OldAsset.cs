﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class OldAsset
{
    public long OldId { get; set; }

    public long? AssetRegId { get; set; }

    public string? AssetCode { get; set; }

    public long? ItemId { get; set; }

    public long? UnitId { get; set; }

    public long? AutoNo { get; set; }

    public long CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AssetType { get; set; }

    public long? Grnid { get; set; }
}
