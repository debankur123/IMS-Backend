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
    decimal InsertUpdateItemMaintain(Ims_M_ItemMaintain_Request itemMaintain);
    DataSet BindGridService();
    DataSet BindGridAMCMain();
    DataSet GetDataMaintain(long itemDetailId);
    DataSet GetDataService(long itemDetailId);
    DataSet SetDataItem(long itemId);
    DataSet SearchGridBind(Ims_M_SearchGridBind obj);
    DataSet SearchGridBindMain(long itemId, long companyId);

    #region Area/Department
    DataSet BindGridArea();
    DataSet gridbindAreaSearch(string areaName);
    decimal InsertUpdateArea(Ims_M_Area_Request obj);
    #endregion

    #region Unit Location/Lab
    DataSet BindgridLocation();
    DataSet gridbindLocationSearch(string locationName);
    decimal InsertUpdateLocation(Ims_M_Location_Request obj);
    #endregion

    #region JobType/Job
    DataSet GridBindJob();
    DataSet GetJob(long jobId);
    DataSet GridBindJobSearch(string jobName,long companyId);
    long InsertUpdateJob(Ims_M_Job_Request obj);
    #endregion

    #region ItemGroup
    DataSet GridBindItemGroup();
    DataSet GridBindItemGroupNameSearch(string itemGroupName);
    long InsertUpdateItemGroup(Ims_M_ItemGroup_Request obj);
    #endregion

    #region ItemSubGroup
    DataSet GridBindItemSubGroup();
    DataSet GridBindItemSubGroupNameSearch(string itemSubGroupName);
    long InsertUpdateItemSubGroup(Ims_M_ItemSubGroup_Request obj);
    #endregion

    #region Bank
    DataSet GridBindBank();
    DataSet GetBank(long bankId);
    DataSet GridBindBankSearch(string bankName);
    long InsertOrUpdateBank(Ims_M_Bank_Request request);
    #endregion
}
