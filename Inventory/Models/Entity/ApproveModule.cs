﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class ApproveModule
{
    public long ApproveModuleId { get; set; }

    public string? ApproveModuleItype { get; set; }

    public byte? ApproverLevel { get; set; }

    public string? ModuleName { get; set; }

    public long? UserId { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }
}
