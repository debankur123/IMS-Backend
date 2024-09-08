﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class JobType
{
    public long JobTypeId { get; set; }

    public string? JobTypeName { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
