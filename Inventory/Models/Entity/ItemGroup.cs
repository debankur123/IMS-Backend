﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class ItemGroup
{
    public long ItemGroupId { get; set; }

    public string? ItemGroupName { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual ICollection<ItemSubGroup> ItemSubGroups { get; set; } = new List<ItemSubGroup>();
}
