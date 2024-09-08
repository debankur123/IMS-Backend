﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Layer
{
    public long LayerId { get; set; }

    public long LayerNo { get; set; }

    public string? Description { get; set; }

    public string? InitialPage { get; set; }

    public long CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
