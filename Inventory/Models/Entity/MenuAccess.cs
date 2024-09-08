﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class MenuAccess
{
    public long MenuAccessId { get; set; }

    public long? MenuId { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UserId { get; set; }

    public bool? AddPermission { get; set; }

    public bool? EditPermission { get; set; }

    public bool? DeletePermission { get; set; }

    public virtual User CreatedU { get; set; } = null!;
}
