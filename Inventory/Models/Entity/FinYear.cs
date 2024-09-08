﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class FinYear
{
    public long FinYearId { get; set; }

    public string? FinYearName { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }
}
