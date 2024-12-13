namespace Inventory.Models.Requisition;
public class Ims_Requisition_ReqSearchList_Reponse
{
        private DateTime? _startDate;
        private DateTime? _endDate;
        public DateTime? StartDate
        {
            get => _startDate;
            set => _startDate = string.IsNullOrWhiteSpace(value?.ToString()) ? null : value;
        }
        public DateTime? EndDate
        {
            get => _endDate;
            set => _endDate = string.IsNullOrWhiteSpace(value?.ToString()) ? null : value;
        }
    public long? UnitId { get; set; } = 0;
    public string? ApprovalStatus { get; set; } = "";
    public string? ReqNo { get; set; } = "";
    public long? CompanyId { get; set; } = 0;
    public string? ReqType { get; set; } = "";
    public string? SearchStat { get; set; } = "";
    public long? ReqId { get; set; } = 0;
    public string? SBUType { get; set; } = "";
    public int? Layer { get; set; } = 0;
}
