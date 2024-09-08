﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class Company
{
    public long CompanyId { get; set; }

    public string CompanyCode { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public long? CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public string? IsActive { get; set; }

    public virtual ICollection<Grndetail> Grndetails { get; set; } = new List<Grndetail>();

    public virtual ICollection<Grn> Grns { get; set; } = new List<Grn>();

    public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();

    public virtual ICollection<ReqDetail> ReqDetails { get; set; } = new List<ReqDetail>();
}
