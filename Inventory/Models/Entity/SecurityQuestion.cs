﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class SecurityQuestion
{
    public long SecurityId { get; set; }

    public string? ForSecurity { get; set; }

    public string? SecurityQuestion1 { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? UpdateUid { get; set; }

    public DateTime? UpdateDate { get; set; }
}
