using System.Data;
using Inventory.Models.Requisition;
using Inventory.Models.Response.Requisition;
namespace Inventory.Repository.IService;
public interface IRequisitionRepository
{
    AreaList GetArea(long unitId, long companyId);
    long InsertUpdateArea(Ims_Requisition_AreaRequest _params);
    Task<DataSet> GetUnitAreaLocation(long unitId, long areaId);
    Task<DataSet> GetRemarks(long reqId);
    Task<DataSet> GetRequisitionSearchList(Ims_Requisition_ReqSearchList_Reponse _params);
    Task<long> InsertOrUpdateUnitLOcation(Ims_Requisition_UnitLocation_Request _params);

    #region Requisition List
    Task<DataSet> GetRequisitionAllItem(long reqId);
    Task<long> InsertOrUpdateRequisitionApproval(Ims_Requisition_ReqApproval _params);
    #endregion
}
