using System.Data;
using Inventory.Models.Response;

namespace Inventory.Repository.IService;

public interface IMasterRepository
{
    DataSet GetUOMs();
    int InsertOrUpdateUOM(Ims_M_UOM uom);
    DataSet SearchUOM(string uomName);
}