﻿using System.Security.Claims;

namespace Inventory.Repository.IService
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string? token);
        
    }
}
