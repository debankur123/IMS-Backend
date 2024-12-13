using Common_Helper.CommonHelper;
using Inventory.AppCode;
using Inventory.Models.Request;
using Inventory.Models.Request.ItemMaster;
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
    private readonly ITokenService _tokenService = null!;
    private readonly ISessionHelper _sessionHelper = null!;
    AuditLogHelper _auditLogHelper = new AuditLogHelper();
    private readonly GeneralUtilityService service = new();
#pragma warning disable IDE0290 // Use primary constructor
    public MasterController(IMasterRepository masterRepository, ITokenService tokenService, ISessionHelper sessionHelper, IConfiguration configuration)
#pragma warning restore IDE0290 // Use primary constructor
    {
        _configuration = configuration;
        _masterRepository = masterRepository;
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        _sessionHelper = sessionHelper ?? throw new ArgumentNullException(nameof(sessionHelper));
    }
    #endregion
    private void InitialCall()
    {
        _sessionHelper.GetSessionClaim();
        _auditLogHelper.ClientIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        _auditLogHelper.ClientEmail = _sessionHelper.Email;
    }
    private readonly IMasterRepository _masterRepository;

    [HttpGet("GetUOMs")]
    public IActionResult GetUOMs()
    {
        var ds = _masterRepository.GetUOMs();
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
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
        var uomData = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
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
    public async Task<ActionResult<List<Ims_M_Area>>> GetAreas(int id)
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
            var output = _masterRepository.InsertUpdateItemDetails(itemDetail);
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

    [HttpPost]
    [Route("InsertUpdateItemMaintain")]
    public ActionResult InsertUpdateItemMaintain([FromBody] Ims_M_ItemMaintain_Request obj)
    {
        try
        {
            var result = _masterRepository.InsertUpdateItemMaintain(obj);
            if (result == -1)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
            return Ok(new
            {
                StatusMsg = "1",
                HasError = "No",
                Message = "Request processed successfully!",
                Output = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpGet]
    [Route("BindGridService")]
    public ActionResult BindGridService()
    {
        var ds = _masterRepository.BindGridService();
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("BindGridAMCMain")]
    public ActionResult BindGridAMCMain()
    {
        var ds = _masterRepository.BindGridAMCMain();
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("GetDataMaintain")]
    public ActionResult GetDataMaintain(long itemDetailId)
    {
        var ds = _masterRepository.GetDataMaintain(itemDetailId);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("GetDataService")]
    public ActionResult GetDataService(long itemDetailId)
    {
        var ds = _masterRepository.GetDataService(itemDetailId);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("SetDataItem")]
    public ActionResult SetDataItem(long itemId)
    {
        var ds = _masterRepository.SetDataItem(itemId);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpPost]
    [Route("SearchGridBind")]
    public ActionResult SearchGridBind(Ims_M_SearchGridBind obj)
    {
        var ds = _masterRepository.SearchGridBind(obj);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpPost]
    [Route("SearchGridBindMain")]
    public ActionResult SearchGridBindMain(long itemId, long companyId)
    {
        var ds = _masterRepository.SearchGridBindMain(itemId, companyId);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("GridBindAreaSearch")]
    public ActionResult GridBindAreaSearch(string? areaName = null)
    {
        var ds = _masterRepository.gridbindAreaSearch(areaName!);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpPost("InsertUpdateArea")]
    public IActionResult InsertUpdateArea([FromBody] Ims_M_Area_Request model)
    {
        if (model == null)
            return BadRequest("Invalid data.");
        try
        {
            var result = _masterRepository.InsertUpdateArea(model);
            return result switch
            {
                -7 => Conflict("Area with the same name already exists."),
                -1 => StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while processing the request."),
                _ => Ok(new
                {
                    StatusMsg = "1", HasError = "No", Message = "Request processed successfully!", Output = result
                })
            };
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet]
    [Route("BindGridLocation")]
    public ActionResult BindGridLocation()
    {
        var ds = _masterRepository.BindgridLocation();
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("GridBindLocationSearch")]
    public ActionResult GridBindLocationSearch(string? locationName = null)
    {
        var ds = _masterRepository.gridbindLocationSearch(locationName!);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpPost("InsertUpdateLocation")]
    public IActionResult InsertUpdateLocation([FromBody] Ims_M_Location_Request request)
    {
        try
        {
            var result = _masterRepository.InsertUpdateLocation(request);
            return result switch
            {
                -1 => StatusCode(500, "An error occurred during the transaction."),
                -7 => Conflict("Duplicate Location found for the given Area."),
                _ => Ok(new
                {
                    StatusMsg = "1", HasError = "No", Message = "Request processed successfully!", Output = result
                })
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #region JobType/Job
    [HttpGet]
    [Route("GridBindJob")]
    public ActionResult GridBindJob()
    {
        var ds = _masterRepository.GridBindJob();
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("GetJob")]
    public ActionResult GetJob(long jobId)
    {
        var ds = _masterRepository.GetJob(jobId);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("GridBindJobSearch")]
    public ActionResult GridBindJobSearch(string? jobName=null,long companyId=0)
    {
        var ds = _masterRepository.GridBindJobSearch(jobName!,companyId);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpPost("InsertUpdateJob")]
    public IActionResult InsertUpdateJob([FromBody] Ims_M_Job_Request request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _masterRepository.InsertUpdateJob(request);
        if (result == -1)
        {
            return StatusCode(500, "An error occurred during the transaction.");
        }
        else if (result == -7)
        {
            return Conflict("A job with the same name already exists.");
        } 
        return Ok(new { StatusMsg = "1", HasError = "No", Message = "Request processed successfully!", Output = result });
    }
    #endregion

    #region ItemGroup
    [HttpGet]
    [Route("GridBindItemGroup")]
    public ActionResult GridBindItemGroup()
    {
        var ds = _masterRepository.GridBindItemGroup();
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("GridBindItemGroupNameSearch")]
    public ActionResult GridBindItemGroupNameSearch(string search)
    {
        var ds = _masterRepository.GridBindItemGroupNameSearch(search);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpPost("InsertUpdateItemGroup")]
    public IActionResult InsertUpdateItemGroup([FromBody] Ims_M_ItemGroup_Request request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _masterRepository.InsertUpdateItemGroup(request);
        if (result == -1)
        {
            return StatusCode(500, "An error occurred during the transaction.");
        }
        else if (result == -7)
        {
            return Conflict("An item group with the same name already exists.");
        } 
        return Ok(new { StatusMsg = "1", HasError = "No", Message = "Request processed successfully!", Output = result });
    }
    #endregion
    #region ItemSubGroup
    [HttpGet]
    [Route("GridBindItemSubGroup")]
    public ActionResult GridBindItemSubGroup()
    {
        var ds = _masterRepository.GridBindItemSubGroup();
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("GridBindItemSubGroupNameSearch")]
    public ActionResult GridBindItemSubGroupNameSearch(string itemSubGroupName)
    {
        var ds = _masterRepository.GridBindItemSubGroupNameSearch(itemSubGroupName);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpPost("InsertUpdateItemSubGroup")]
    public IActionResult InsertUpdateItemSubGroup([FromBody] Ims_M_ItemSubGroup_Request request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _masterRepository.InsertUpdateItemSubGroup(request);
        if (result == -1)
        {
            return StatusCode(500, "An error occurred during the transaction.");
        }
        else if (result == -7)
        {
            return Conflict("An item sub group with the same name already exists.");
        } 
        return Ok(new { StatusMsg = "1", HasError = "No", Message = "Request processed successfully!", Output = result });
    }
    #endregion
    #region Bank
    [HttpGet]
    [Route("GridBindBank")]
    public ActionResult GridBindBank()
    {
        var ds = _masterRepository.GridBindBank();
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("GetBank")]
    public ActionResult GetBank(long bankId)
    {
        var ds = _masterRepository.GetBank(bankId);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpGet]
    [Route("GridBindBankSearch")]
    public ActionResult GridBindBankSearch(string? bankName=null)
    {
        var ds = _masterRepository.GridBindBankSearch(bankName!);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            return Ok(new { message = "No records found.", data = new List<Dictionary<string, object>>() });
        }
        var output = GeneralUtilityService.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpPost("InsertUpdateBank")]
    public IActionResult InsertUpdateBank([FromBody] Ims_M_Bank_Request request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _masterRepository.InsertOrUpdateBank(request);
        return result switch
        {
            -1 => StatusCode(500, "An error occurred during the transaction."),
            -7 => Conflict("bank with the same name already exists."),
            _ => Ok(new
            {
                StatusMsg = "1", HasError = "No", Message = "Request processed successfully!", Output = result
            })
        };
    }
    #endregion
}
