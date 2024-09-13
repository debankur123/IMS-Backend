﻿using Common_Helper.CommonHelper;
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
        var output = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
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
        var output = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
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
        var output = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
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
        var output = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
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
        var output = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
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
        var output = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
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
        var output = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
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
        var output = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
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
        var output = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpPost("InsertUpdateArea")]
    public IActionResult InsertUpdateArea([FromBody] Ims_M_Area_Request model)
    {
        if (model == null)
            return BadRequest("Invalid data.");
        try
        {
            decimal result = _masterRepository.InsertUpdateArea(model);
            if (result == -7)
                return Conflict("Area with the same name already exists.");
            else if (result == -1)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            else
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
        var output = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
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
        var output = service.ConvertDataTableToDictionaryList(ds.Tables[0]);
        return Ok(output);
    }
    [HttpPost("InsertUpdateLocation")]
    public IActionResult InsertUpdateLocation([FromBody] Ims_M_Location_Request request)
    {
        try
        {
            decimal result = _masterRepository.InsertUpdateLocation(request);
            if (result == -1)
            {
                return StatusCode(500, "An error occurred during the transaction.");
            }
            if (result == -7)
            {
                return Conflict("Duplicate Location found for the given Area.");
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
            throw new Exception(ex.Message);
        }
    }
}
