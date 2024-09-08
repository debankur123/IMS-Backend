﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Uom
{
    public long Uomid { get; set; }

    public string? Uomname { get; set; }

    public string? Uomtype { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }
}
