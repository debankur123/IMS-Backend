using System.Data;
using Common_Helper.CommonHelper;
using Inventory.AppCode;
using Inventory.Models.Response;
using Inventory.Repository.IService;
using Inventory.Repository.Service;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers;


[Route("api/[controller]")]
[ApiController]
public class MasterController : ControllerBase
{
    #region Declaration
    private readonly IConfiguration _configuration = null!;
    private readonly IMasterRepository _masterRepo = null!;
    private readonly ITokenService _tokenService = null!;
    private readonly ISessionHelper _sessionHelper = null!;
    AuditLogHelper _auditLogHelper = new AuditLogHelper();
    AuditLog.BeLogLevel _errorlevel = AuditLog.BeLogLevel.Information;
    AuditLog.BeLogType _errortype = AuditLog.BeLogType.Success;
    string? METHODNAME = "";
    string? TableID = "";
    bool result = true;
    string ExceptionMsg = "";
    private GeneralUtilityService service = new();
    public MasterController(IMasterRepository masterRepository, ITokenService tokenService, ISessionHelper sessionHelper, IConfiguration configuration)
    {
        _configuration = configuration;
        _masterRepository = masterRepository;
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
    
    private readonly IMasterRepository _masterRepository;
    
    [HttpGet("GetUOMs")]
    public IActionResult GetUOMs()
    {
        var ds = _masterRepository.GetUOMs();
        if (ds.Tables[0].Rows.Count <= 0) return NotFound("No UOM records found.");
        var uomData = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(uomData);
    }

    
    [HttpPost("SaveUOM")]
    public IActionResult SaveUOM([FromBody] Ims_M_UOM uom)
    {
        var result = _masterRepository.InsertOrUpdateUOM(uom);
        return result switch
        {
            > 0 => Ok("UOM saved successfully."),  
            -7 => Conflict("UOM already exists."), 
            _ => BadRequest("Failed to save UOM.") 
        };
    }
    
    [HttpGet("SearchUOM")]
    public IActionResult SearchUOM(string uomName)
    {
        var ds = _masterRepository.SearchUOM(uomName);
        if (ds.Tables[0].Rows.Count <= 0) return NotFound("No matching UOM records found.");
        var uomData = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(uomData);
    }
}