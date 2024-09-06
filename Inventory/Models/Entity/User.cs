using System;
using System.Collections.Generic;

namespace Inventory.Models.Entity;

public partial class User
{
    public Guid UserId { get; set; }

    public Guid? BusinessId { get; set; }

    public Guid? UserTypeId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenStartDate { get; set; }

    public DateTime? RefreshTokenExpiryDate { get; set; }

    public int? StatusId { get; set; }
}
