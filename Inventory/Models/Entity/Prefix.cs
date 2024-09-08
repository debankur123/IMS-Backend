﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Prefix
{
    public long PrefixId { get; set; }

    public string? PrefixType { get; set; }

    public string? PrefixValue { get; set; }

    public long? SessionId { get; set; }

    public long? MaxValue { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }
}
