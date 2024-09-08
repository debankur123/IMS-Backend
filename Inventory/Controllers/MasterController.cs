using Common_Helper.CommonHelper;
using Inventory.AppCode;
using Inventory.Repository.IService;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers;


[Route("api/[controller]")]
[ApiController]
public class MasterController : ControllerBase
{
    
    #region Declaration
    private readonly IConfiguration _configuration;
    private readonly IMasterRepository _masterRepo;
    private readonly ITokenService _tokenService;
    private readonly ISessionHelper _sessionHelper;
    AuditLogHelper _auditLogHelper = new AuditLogHelper();
    AuditLog.BeLogLevel _errorlevel = AuditLog.BeLogLevel.Information;
    AuditLog.BeLogType _errortype = AuditLog.BeLogType.Success;
    string? METHODNAME = "";
    string? TableID = "";
    bool result = true;
    string ExceptionMsg = "";
    public MasterController(IMasterRepository masterRepo, ITokenService tokenService, ISessionHelper sessionHelper, IConfiguration configuration)
    {
        _configuration = configuration;
        _masterRepo = masterRepo ?? throw new ArgumentNullException(nameof(masterRepo));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
    }
    private void InitialCall()
    {
        _sessionHelper.GetSessionClaim();
        _auditLogHelper.ClientIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        _auditLogHelper.ClientEmail = _sessionHelper.Email;
    }
    #endregion
}