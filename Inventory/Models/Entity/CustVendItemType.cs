﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class CustVendItemType
{
    public int CvItemTypeId { get; set; }

    public long CvId { get; set; }

    public int? ItemTypeId { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public string? DescripTion { get; set; }

    public virtual CustomerVendor Cv { get; set; } = null!;
}
