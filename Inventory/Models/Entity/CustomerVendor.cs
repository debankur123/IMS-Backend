﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class CustomerVendor
{
    public long CvId { get; set; }

    public string CvTag { get; set; } = null!;

    public string? DealsIn { get; set; }

    public string CvCode { get; set; } = null!;

    public string CvName { get; set; } = null!;

    public string? ContactPerson { get; set; }

    public string? RegNumber { get; set; }

    public DateTime? RegDate { get; set; }

    public string? ServiceTaxNumber { get; set; }

    public string? CvAddress { get; set; }

    public string? Cvdistrict { get; set; }

    public string? CvPinCode { get; set; }

    public long? CvState { get; set; }

    public string? CvPhone { get; set; }

    public string? CvMobile { get; set; }

    public string? CvEmail { get; set; }

    public string? CvWebsite { get; set; }

    public string? CvPancardNo { get; set; }

    public string? CvTan { get; set; }

    public string? CvWbstNo { get; set; }

    public string? CvCstNo { get; set; }

    public long? BankCode { get; set; }

    public string? Bankbranch { get; set; }

    public string? Vat { get; set; }

    public string? Ifsccode { get; set; }

    public string? AccountNumber { get; set; }

    public string? AccType { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public long? UnitId { get; set; }

    public string? VendoreFile { get; set; }

    public string? Status { get; set; }

    public long CompanyId { get; set; }

    public long CreatedUid { get; set; }

    public DateTime CreateDate { get; set; }

    public long? UpdatedUid { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<CustVendItemType> CustVendItemTypes { get; set; } = new List<CustVendItemType>();

    public virtual ICollection<CustVendJobType> CustVendJobTypes { get; set; } = new List<CustVendJobType>();

    public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();
}
