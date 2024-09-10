using System.Data;
using Common_Helper.CommonHelper;
using Inventory.AppCode;
using Inventory.Models.Request;
using Inventory.Models.Request.ItemMaster;
using Inventory.Models.Response;
using Inventory.Models.Response.ItemMaster;
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
    
    [HttpPost("SaveItem")]
    public IActionResult SaveItem([FromBody] Ims_M_Item_Request item)
    {
        var result = _masterRepository.InsertOrUpdateItem(item);
        switch (result)
        {
            case > 0:
                Console.WriteLine("Item saved successfully with ID: " + result);
                return Ok("Item saved successfully.");
            case -7:
                Console.WriteLine("Item already exists.");
                return Conflict("Item already exists.");
            default:
                Console.WriteLine("Failed to save item. Error Code: " + result);
                return BadRequest("Failed to save item.");
        }
    }
    
    [HttpGet]
    [Route("GetUnitLocations")]
    public async Task<ActionResult<List<Ims_M_UnitLocation>>> GetUnitLocations(int id)
    {
        try
        {
            var locations = await _masterRepository.GetUnitLocations(id);
            return Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request." + ex.Message);
        }
    }
    
    [HttpGet]
    [Route("GetAreas")]
    public async Task<ActionResult<List<Ims_M_UnitLocation>>> GetAreas(int id)
    {
        try
        {
            var areas = await _masterRepository.GetArea(id);
            return Ok(areas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request." + ex.Message);
        }
    }
    [HttpGet]
    [Route("BindGridViewItem")]
    public async Task<ActionResult<List<Ims_M_BindGridViewItem>>> BindGridViewItem()
    {
        try
        {
            var items = await _masterRepository.BindGridViewItem();
            return Ok(items);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request." + ex.Message);
        }
    }
    
    [HttpPost]
    [Route("InsertUpdateItemDetail")]
    public ActionResult InsertUpdateItemDetail([FromBody] Ims_M_ItemDetailsRequest itemDetail)
    {
        if (itemDetail is null)
        {
            return BadRequest("Invalid Item Details");
        }
        try
        {
            var output =  _masterRepository.InsertUpdateItemDetails(itemDetail);
            return Ok(new
            {
                StatusMsg = "1",
                HasError = "No",
                Message = "Request processed successfully!",
                Output = output
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error" + ex.Message);
        }
    }
    
}