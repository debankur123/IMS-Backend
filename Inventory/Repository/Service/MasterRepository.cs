// ReSharper disable All
// ReSharper disable once StringLiteralTypo
using System.Data;
using System.Data.SqlClient;
using Inventory.Models.Request;
using Inventory.Models.Request.ItemMaster;
using Inventory.Models.Response;
using Inventory.Models.Response.ItemMaster;
using Inventory.Repository.DBContext;
using Inventory.Repository.IService;
using Microsoft.EntityFrameworkCore;


namespace InventoryAPI.Repository
{
    public class MasterRepository : IMasterRepository
    {
        private readonly string? _connectionString;
        private readonly Imsv2Context _context;

        public MasterRepository(IConfiguration configuration, Imsv2Context context)
        {
            _connectionString = configuration.GetConnectionString("ProjectConnection");
            _context = context;
        }
        public DataSet GetUOMs()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridBindUOM", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public int InsertOrUpdateUOM(Ims_M_UOM uom)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_UOMInsertUpdate", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@UOMID", uom.UOMID);
            cmd.Parameters.AddWithValue("@UOMtype", uom.UOMtype);
            cmd.Parameters.AddWithValue("@UOMname", uom.UOMname);
            cmd.Parameters.AddWithValue("@CompanyID", uom.CompanyID);
            cmd.Parameters.AddWithValue("@CreatedUID", uom.CreatedUID);

            var outputIdParam = new SqlParameter("@OutPutId", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputIdParam);
            conn.Open();
            cmd.ExecuteNonQuery();
            var outputId = (long)outputIdParam.Value;
            return (int)outputId;
        }

        public DataSet SearchUOM(string uomName)
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridBindUOMSearch", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@UOMname", uomName);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public decimal InsertOrUpdateItem(Ims_M_Item_Request item)
        {
            var arrParams = new List<SqlParameter>
            {
                new SqlParameter("@ItemSubGroupID", item.ItemSubGroupID ?? (object)DBNull.Value),
                new SqlParameter("@HiddenfildID", item.ItemID == 0 ? 0 : item.ItemID),
                new SqlParameter("@UnitID", item.UnitID ?? (object)DBNull.Value),
                new SqlParameter("@LocationID", item.LocationID ?? (object)DBNull.Value),
                new SqlParameter("@AreaID", item.AreaID ?? (object)DBNull.Value),
                new SqlParameter("@UOMID", item.UOMID ?? (object)DBNull.Value),
                new SqlParameter("@ROL", item.ROL ?? (object)DBNull.Value),
                new SqlParameter("@RQTY", item.RQTY ?? (object)DBNull.Value),
                new SqlParameter("@SOH", item.SOH ?? (object)DBNull.Value),
                new SqlParameter("@StoreUOMID", item.StoreUOMID ?? (object)DBNull.Value),
                new SqlParameter("@Rate", item.Rate ?? (object)DBNull.Value),
                new SqlParameter("@VAT", item.VAT ?? (object)DBNull.Value),
                new SqlParameter("@ItemName", item.ItemName ?? (object)DBNull.Value),
                new SqlParameter("@Exprement", item.Exprement ?? (object)DBNull.Value),
                new SqlParameter("@ItemType", item.ItemType?.ToString() ?? (object)DBNull.Value),
                new SqlParameter("@CompanyID", SqlDbType.BigInt) { Value = item.CompanyID },
                new SqlParameter("@CreatedUID", SqlDbType.BigInt) { Value = item.CreatedUID },
                new SqlParameter("@ItemDescHTML", item.ItemDescHTML ?? (object)DBNull.Value),
                new SqlParameter("@AssetTypeID", item.AssetTypeID ?? (object)DBNull.Value)
            };
            var outPutId = new SqlParameter("@OutPutId", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            arrParams.Add(outPutId);
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("Usp_ItemInsertUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(arrParams.ToArray());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return Convert.ToDecimal(outPutId.Value);
        }

        public async Task<List<Ims_M_UnitLocation>> GetUnitLocations(int id)
        {
            var locations = new List<Ims_M_UnitLocation>
            {
                new Ims_M_UnitLocation { LocationID = 0, LocationName = "--Select--" }
            };
            var unitLocations = await _context.UnitLocations
                .Where(x => x.LocationId == id)
                .Select(u => new Ims_M_UnitLocation
                {
                    LocationID = u.LocationId,
                    LocationName = u.LocationName
                })
                .ToListAsync();
            locations.AddRange(unitLocations);
            return locations;
        }

        public async Task<List<Ims_M_Area>> GetArea(int unitId)
        {
            var areas = new List<Ims_M_Area>
            {
                new() { AreaID = 0, AreaName = "--Select--" }
            };
            var areaList = await _context.Areas
                .Where(x => x.UnitId == unitId)
                .Select(a => new Ims_M_Area
                {
                    AreaID = a.AreaId,
                    AreaName = a.AreaName
                })
                .ToListAsync();
            areas.AddRange(areaList);
            return areas;
        }

        public async Task<List<Ims_M_BindGridViewItem>> BindGridViewItem()
        {
            var items = new List<Ims_M_BindGridViewItem>();
            const string storedProcedureName = "Usp_bindgridviewItem";
            await using var connection = new SqlConnection(_connectionString);
            await using var command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            await connection.OpenAsync();
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var item = new Ims_M_BindGridViewItem
                {
                    ItemID = reader.IsDBNull(reader.GetOrdinal("ItemID"))
                        ? (long?)null
                        : reader.GetInt64(reader.GetOrdinal("ItemID")),
                    ItemName = reader.IsDBNull(reader.GetOrdinal("ItemName"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("ItemName")),
                    AreaName = reader.IsDBNull(reader.GetOrdinal("AreaName"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("AreaName")),
                    UnitName = reader.IsDBNull(reader.GetOrdinal("UnitName"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("UnitName"))
                };
                items.Add(item);
            }

            return items;
        }

        public decimal InsertUpdateItemDetails(Ims_M_ItemDetailsRequest itemDetail)
        {
            var arrParams = new List<SqlParameter>
            {
                new SqlParameter("@HiddenfildID", SqlDbType.BigInt) { Value = itemDetail.HiddenfildID },
                new SqlParameter("@ItemID", SqlDbType.BigInt) { Value = (object)itemDetail.ItemID! ?? DBNull.Value },
                new SqlParameter("@Make", SqlDbType.NVarChar, 1000)
                    { Value = (object)itemDetail.Make! ?? DBNull.Value },
                new SqlParameter("@Model", SqlDbType.NVarChar, 1000)
                    { Value = (object)itemDetail.Model! ?? DBNull.Value },
                new SqlParameter("@Serial", SqlDbType.NVarChar, 1000)
                    { Value = (object)itemDetail.Serial! ?? DBNull.Value },
                new SqlParameter("@CompanyID", SqlDbType.BigInt) { Value = itemDetail.CompanyID },
                new SqlParameter("@CreatedUID", SqlDbType.BigInt) { Value = itemDetail.CreatedUID },
                new SqlParameter("@PurchaseDate", SqlDbType.DateTime)
                    { Value = (object)itemDetail.PurchaseDate! ?? DBNull.Value },
                new SqlParameter("@InstallationDate", SqlDbType.DateTime)
                    { Value = (object)itemDetail.InstallationDate! ?? DBNull.Value },
                new SqlParameter("@WarrantyTerm", SqlDbType.NVarChar, 1000)
                    { Value = (object)itemDetail.WarrantyTerm! ?? DBNull.Value },
                new SqlParameter("@WarrantyDetail", SqlDbType.NVarChar, 1000)
                    { Value = (object)itemDetail.WarrantyDetail! ?? DBNull.Value },
                new SqlParameter("@LogBookSerial", SqlDbType.NVarChar, 1000)
                    { Value = (object)itemDetail.LogBookSerial! ?? DBNull.Value }
            };

            var outPutId = new SqlParameter("@OutPutId", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            arrParams.Add(outPutId);

            using (var conn = new SqlConnection(_connectionString))
            {
                using var cmd = new SqlCommand("Usp_ItemInsertUpdatedetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(arrParams.ToArray());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return Convert.ToDecimal(outPutId.Value);
        }

        public decimal InsertUpdateItemMaintain(Ims_M_ItemMaintain_Request obj)
        {
            using SqlConnection conn = new(_connectionString);
            using SqlCommand cmd = new("Usp_ItemInsertUpdateMain", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemDetailID", obj.ItemDetailID);
            cmd.Parameters.AddWithValue("@AmcProviderID", obj.AmcProviderID);
            cmd.Parameters.AddWithValue("@AmcType", obj.AmcType);
            cmd.Parameters.AddWithValue("@AmcValue", obj.AmcValue);
            cmd.Parameters.AddWithValue("@AmcStartDate", obj.AmcStartDate);
            cmd.Parameters.AddWithValue("@AmcRenewDate", obj.AmcRenewDate);
            cmd.Parameters.AddWithValue("@Status", obj.Status);
            cmd.Parameters.AddWithValue("@SupplierID", obj.SupplierID);
            cmd.Parameters.AddWithValue("@SupplierContactNo", obj.SupplierContactNo);
            SqlParameter outputId = new("@OutPutId", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputId);
            SqlParameter @ErrorMessage = new("@ErrorMessage", SqlDbType.NVarChar, 4000)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(ErrorMessage);
            conn.Open();
            cmd.ExecuteNonQuery();
            decimal result = Convert.ToDecimal(outputId.Value);
            return result;
        }

        public DataSet BindGridService()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_bindgridviewService", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public DataSet BindGridAMCMain()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_bindgridviewAmcmain", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetDataMaintain(long itemDetailId)
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("[dbo].[Usp_GetDataItemAmcMain]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ItemDetailsId", itemDetailId);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetDataService(long itemDetailId)
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("[dbo].[Usp_GetDataItemService]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ItemDetailsId", itemDetailId);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public DataSet SetDataItem(long itemId)
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("[dbo].[Usp_GetDataItem]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ItemId", itemId);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet SearchGridBind(Ims_M_SearchGridBind obj)
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("[dbo].[Usp_BindGridviewItemForSearch]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ItemGroupID", obj.ItemGroupID);
            cmd.Parameters.AddWithValue("@ItemSubGroupID", obj.ItemSubGroupID);
            cmd.Parameters.AddWithValue("@ItemName", obj.ItemName);
            //cmd.Parameters.AddWithValue("@ItemGroupID", obj.CompanyID);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet SearchGridBindMain(long itemId, long companyId)
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("[dbo].[Usp_BindGridviewItemForSearchMain]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ItemId", itemId);
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        #region Area/Department
        public DataSet BindGridArea()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("[dbo].[Usp_GridBindArea]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public DataSet gridbindAreaSearch(string areaName)
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridBindAreaSearch", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@AreaName", areaName);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public decimal InsertUpdateArea(Ims_M_Area_Request obj)
        {
            using SqlConnection conn = new(_connectionString);
            using SqlCommand cmd = new("Usp_AreaInsertUpdate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AreaID", obj.AreaID);
            cmd.Parameters.AddWithValue("@AreaName", obj.AreaName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@AreaCode", obj.AreaCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@UnitID", obj.UnitID ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CompanyID", obj.CompanyID ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedUID", obj.CreatedUID ?? (object)DBNull.Value);
            SqlParameter outputId = new("@OutPutId", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputId);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                decimal result = Convert.ToDecimal(outputId.Value);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting/updating the area.", ex);
            }
        }
        #endregion

        #region Unit Location/Lab
        public DataSet BindgridLocation()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("[dbo].[Usp_GridBindLocation]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public DataSet gridbindLocationSearch(string locationName)
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("[dbo].[Usp_GridBindLocationSearch]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@LocationName", locationName);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public decimal InsertUpdateLocation(Ims_M_Location_Request request)
        {
            using SqlConnection conn = new(_connectionString);
            using SqlCommand cmd = new("Usp_LocationInsertUpdate", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@LocationID", request.LocationID);
            cmd.Parameters.AddWithValue("@AreaID", request.AreaID);
            cmd.Parameters.AddWithValue("@LocationName", request.LocationName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@LocationCode", request.LocationCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@UnitID", request.UnitID ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CompanyID", request.CompanyID);
            cmd.Parameters.AddWithValue("@CreatedUID", request.CreatedUID);
            SqlParameter outputId = new("@OutPutId", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputId);
            conn.Open();
            cmd.ExecuteNonQuery();
            decimal result = Convert.ToDecimal(outputId.Value);
            return result;
        }
        #endregion
        #region Jobtype/Job
        public DataSet GridBindJob()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridBindJob", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public DataSet GetJob(long jobId)
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GetDataJob", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@JobID", jobId);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public DataSet GridBindJobSearch(string? jobName = null, long companyId = 0)
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GetDataJobSearch", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@JobName", jobName);
            cmd.Parameters.AddWithValue("@CompanyID", companyId);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public long InsertUpdateJob(Ims_M_Job_Request request)
        {
            using SqlConnection conn = new(_connectionString);
            using SqlCommand cmd = new("[dbo].[Usp_JobInsertUpdate]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@JobTypeID", request.JobTypeId);
            cmd.Parameters.AddWithValue("@JobID", request.JobId);
            cmd.Parameters.AddWithValue("@JobName", request.JobName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@JobNmaedescr", request.JobNameDesc ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CompanyID", request.CompanyId);
            cmd.Parameters.AddWithValue("@CreatedUID", request.CreatedUID);
            SqlParameter outputId = new("@OutPutId", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputId);
            conn.Open();
            cmd.ExecuteNonQuery();
            long result = Convert.ToInt64(outputId.Value);
            return result;
        }
        #endregion

        #region ItemGroup
        public DataSet GridBindItemGroup()
        {
            var ds = new DataSet();
            var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("[dbo].[Usp_GridItemGroup]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        public DataSet GridBindItemGroupNameSearch(string itemGroupName)
        {
            var ds = new DataSet();
            var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("[dbo].[Usp_GetDataItemGroupSearch]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ItemGroupName", itemGroupName);
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public long InsertUpdateItemGroup(Ims_M_ItemGroup_Request obj)
        {
            var connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new("[dbo].[Usp_ItemGroupInsertUpdate]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ItemGroupID", obj.ItemGroupId));
                cmd.Parameters.Add(new SqlParameter("@ItemGroupName",
                    obj.ItemGroupName != null ? obj.ItemGroupName : DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@SetGroupName",
                    obj.SetGroupName != null ? obj.SetGroupName : DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@CompanyID",
                    obj.CompanyId.HasValue ? obj.CompanyId.Value : DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@CreatedUID",
                    obj.CreatedUId.HasValue ? obj.CreatedUId.Value : DBNull.Value));
                SqlParameter OutPutId = new("@OutPutId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(OutPutId);
                connection.Open();
                cmd.ExecuteNonQuery();
                long result = Convert.ToInt64(OutPutId.Value);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting/updating the item group.", ex);
            }
        }
        #endregion

        #region ItemSubGroup
        public DataSet GridBindItemSubGroup()
        {
            try
            {
                var ds = new DataSet();
                var conn = new SqlConnection(_connectionString);
                var cmd = new SqlCommand("[dbo].[Usp_GridItemSubGroup]", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public DataSet GridBindItemSubGroupNameSearch(string itemSubGroupName)
        {
            try
            {
                var ds = new DataSet();
                var conn = new SqlConnection(_connectionString);
                var cmd = new SqlCommand("[dbo].[Usp_GetDataItemSubGroupSearch]", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ItemSubGroupName", itemSubGroupName);
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long InsertUpdateItemSubGroup(Ims_M_ItemSubGroup_Request obj)
        {
            var connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new("[dbo].[Usp_ItemSubGroupInsertUpdate]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ItemGroupID", obj.ItemGroupId));
                cmd.Parameters.Add(new SqlParameter("@ItemSubGroupID", obj.ItemSubGroupId));
                cmd.Parameters.Add(new SqlParameter("@ItemSubGroupName",
                    obj.ItemSubGroupName != null ? obj.ItemSubGroupName : DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@SetSubGroupName",
                    obj.SetSubGroupName != null ? obj.SetSubGroupName : DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@CompanyID",
                    obj.CompanyId.HasValue ? obj.CompanyId.Value : DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@CreatedUID",
                    obj.CreatedUId.HasValue ? obj.CreatedUId.Value : DBNull.Value));
                SqlParameter OutPutId = new("@OutPutId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(OutPutId);
                connection.Open();
                cmd.ExecuteNonQuery();
                long result = Convert.ToInt64(OutPutId.Value);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting/updating the item sub group.", ex);
            }
        }
        #endregion

        #region Bank
        public DataSet GridBindBank()
        {
            try
            {
                var ds = new DataSet();
                var conn = new SqlConnection(_connectionString);
                var cmd = new SqlCommand("[dbo].[Usp_GridBindBank]", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public DataSet GetBank(long bankId){
            try
            {
                var ds = new DataSet();
                var conn = new SqlConnection(_connectionString);
                var cmd = new SqlCommand("[dbo].[Usp_GetDatabank]", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BankID",bankId);
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public DataSet GridBindBankSearch(string bankName)
        {
            try
            {
                var ds = new DataSet();
                var conn = new SqlConnection(_connectionString);
                var cmd = new SqlCommand("[dbo].[Usp_GetDatabankSearch]", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BankName", bankName);
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public long InsertOrUpdateBank(Ims_M_Bank_Request obj){
            var connection = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new("[dbo].[Usp_BankInsertUpdate]", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@BankID", obj.BankId));
                cmd.Parameters.Add(new SqlParameter("@BankName",
                    obj.BankName != null ? obj.BankName : DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@BaranchName",
                    obj.BranchName != null ? obj.BranchName : DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Address",
                    obj.Address != null ? obj.Address : DBNull.Value));
                cmd.Parameters.Add(new SqlParameter("@Ifsc_Code",
                    obj.IFSCCode != null ? obj.IFSCCode : DBNull.Value));
                SqlParameter OutPutId = new("@OutPutId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(OutPutId);
                connection.Open();
                cmd.ExecuteNonQuery();
                long result = Convert.ToInt64(OutPutId.Value);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting/updating bank details.", ex);
            }
        }
        
        #endregion
    }
}

