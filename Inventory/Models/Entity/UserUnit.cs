﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class UserUnit
{
    public long UserUnitId { get; set; }

    public long? UnitId { get; set; }

    public long? UserId { get; set; }

    public string? UserName { get; set; }

    public string? UnitName { get; set; }

    public string? Sbutype { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
