﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Job
{
    public long JobId { get; set; }

    public long? JobTypeId { get; set; }

    public string? JobName { get; set; }

    public string? JobHtmlDesc { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual JobType? JobType { get; set; }
}
