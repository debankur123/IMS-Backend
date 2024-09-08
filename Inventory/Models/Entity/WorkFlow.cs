﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class WorkFlow
{
    public long WorkFlowId { get; set; }

    public string? WorkFlowName { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }
}
