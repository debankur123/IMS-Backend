using System.Data;
using Inventory.Models.Request;
using Inventory.Models.Request.ItemMaster;
using Inventory.Models.Response;

namespace Inventory.Repository.IService;

public interface IMasterRepository
{
    DataSet GetUOMs();
    int InsertOrUpdateUOM(Ims_M_UOM uom);
    DataSet SearchUOM(string uomName);
    decimal InsertOrUpdateItem(Ims_M_Item_Request item);
    Task<List<Ims_M_UnitLocation>> GetUnitLocations(int id);
    Task<List<Ims_M_Area>> GetArea(int id);
    Task<List<Ims_M_BindGridViewItem>> BindGridViewItem();
    decimal InsertUpdateItemDetails(Ims_M_ItemDetailsRequest itemDetail);
}