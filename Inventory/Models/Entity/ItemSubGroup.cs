﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class ItemSubGroup
{
    public long ItemSubGroupId { get; set; }

    public string? ItemSubGroupName { get; set; }

    public long ItemGroupId { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual ItemGroup ItemGroup { get; set; } = null!;
}
