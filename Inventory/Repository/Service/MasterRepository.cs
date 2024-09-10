// ReSharper disable All
// ReSharper disable once StringLiteralTypo
using System.Data;
using System.Data.SqlClient;
using Inventory.Models.Request;
using Inventory.Models.Request.ItemMaster;
using Inventory.Models.Response;
using Inventory.Repository.DBContext;
using Inventory.Repository.IService;
using Inventory.Repository.Service;
using Microsoft.EntityFrameworkCore;


namespace InventoryAPI.Repository
{
    public class MasterRepository : IMasterRepository
    {
        private readonly string? _connectionString;
        private GeneralUtilityService service = new();
        private readonly Imsv2Context _context;

        public MasterRepository(IConfiguration configuration,Imsv2Context context)
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
                new Ims_M_Area { AreaID = 0, AreaName = "--Select--" }
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
                    ItemID = reader.IsDBNull(reader.GetOrdinal("ItemID")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("ItemID")),
                    ItemName = reader.IsDBNull(reader.GetOrdinal("ItemName")) ? null : reader.GetString(reader.GetOrdinal("ItemName")),
                    AreaName = reader.IsDBNull(reader.GetOrdinal("AreaName")) ? null : reader.GetString(reader.GetOrdinal("AreaName")),
                    UnitName = reader.IsDBNull(reader.GetOrdinal("UnitName")) ? null : reader.GetString(reader.GetOrdinal("UnitName"))
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
                new SqlParameter("@Make", SqlDbType.NVarChar, 1000) { Value = (object)itemDetail.Make! ?? DBNull.Value },
                new SqlParameter("@Model", SqlDbType.NVarChar, 1000) { Value = (object)itemDetail.Model! ?? DBNull.Value },
                new SqlParameter("@Serial", SqlDbType.NVarChar, 1000) { Value = (object)itemDetail.Serial! ?? DBNull.Value },
                new SqlParameter("@CompanyID", SqlDbType.BigInt) { Value = itemDetail.CompanyID },
                new SqlParameter("@CreatedUID", SqlDbType.BigInt) { Value = itemDetail.CreatedUID },
                new SqlParameter("@PurchaseDate", SqlDbType.DateTime) { Value = (object)itemDetail.PurchaseDate! ?? DBNull.Value },
                new SqlParameter("@InstallationDate", SqlDbType.DateTime) { Value = (object)itemDetail.InstallationDate! ?? DBNull.Value },
                new SqlParameter("@WarrantyTerm", SqlDbType.NVarChar, 1000) { Value = (object)itemDetail.WarrantyTerm! ?? DBNull.Value },
                new SqlParameter("@WarrantyDetail", SqlDbType.NVarChar, 1000) { Value = (object)itemDetail.WarrantyDetail! ?? DBNull.Value },
                new SqlParameter("@LogBookSerial", SqlDbType.NVarChar, 1000) { Value = (object)itemDetail.LogBookSerial! ?? DBNull.Value }
            };

            var outPutId = new SqlParameter("@OutPutId", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            arrParams.Add(outPutId);

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("Usp_ItemInsertUpdatedetails", conn))
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
    }
}
