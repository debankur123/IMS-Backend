﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class StudentPortalPaymentAccess
{
    public int PaymentAccessId { get; set; }

    public int? FeesTypeId { get; set; }

    public int? StreamId { get; set; }

    public int? SemesterId { get; set; }
}
