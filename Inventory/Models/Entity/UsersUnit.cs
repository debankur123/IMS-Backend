﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class UsersUnit
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long? UnitId { get; set; }

    public long? MenuId { get; set; }

    public bool? AddPer { get; set; }

    public bool? EditPer { get; set; }

    public bool? ViewPer { get; set; }
}
