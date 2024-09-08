﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class ItemPrefix
{
    public long ItemPrefixId { get; set; }

    public long? ItemSubGroupId { get; set; }

    public long? ItemId { get; set; }

    public string? PrefixVlue { get; set; }

    public long? MaxValue { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreatedDate { get; set; }
}
