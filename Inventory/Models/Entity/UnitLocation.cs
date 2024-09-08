﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class UnitLocation
{
    public long LocationId { get; set; }

    public string? LocationName { get; set; }

    public string? LocationCode { get; set; }

    public long? AreaId { get; set; }

    public long? UnitId { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
