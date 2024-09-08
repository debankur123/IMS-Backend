﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class AssetType
{
    public byte AssetTypeId { get; set; }

    public string? AssetType1 { get; set; }

    public bool? Inactive { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }
}
