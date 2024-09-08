﻿using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class User
{
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Phone { get; set; }

    public DateTime? RegDate { get; set; }

    public bool? DigitalSign { get; set; }

    public byte[]? SignData { get; set; }

    public string? DigitalSignPath { get; set; }

    public string? SecurityQuestion1 { get; set; }

    public string? SecurityQuestion2 { get; set; }

    public string? SecurityAnswer1 { get; set; }

    public string? SecurityAnswer2 { get; set; }

    public string? Sbutype { get; set; }

    public bool? Inactive { get; set; }

    public bool? UserType { get; set; }

    public long? CompanyId { get; set; }

    public long? CreatedUid { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? LastOtp { get; set; }

    public DateTime? LastOtpDate { get; set; }

    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryDate { get; set; }

    public DateTime? RefreshTokenStartDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime CreateDate { get; set; }

    public int? Layer { get; set; }

    public long? UnitId { get; set; }

    public virtual ICollection<Grn> Grns { get; set; } = new List<Grn>();

    public virtual ICollection<MenuAccess> MenuAccesses { get; set; } = new List<MenuAccess>();
}
