using System.Data;
using Inventory.Models.Requisition;
using Inventory.Models.Response.Requisition;
using Inventory.Repository.DBContext;
using Inventory.Repository.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Inventory.Repository.Service;
public class RequisitionRepository : IRequisitionRepository
{
    private readonly string? _connectionString;
    private readonly Imsv2Context _context;
    public RequisitionRepository(IConfiguration configuration, Imsv2Context context)
    {
        _connectionString = configuration.GetConnectionString("ProjectConnection");
        _context = context;
    }
    public AreaList GetArea(long unitId, long companyId)
    {
        AreaList response = new()
        {
            Areas = []
        };
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                using SqlCommand cmd = new("[dbo].[Usp_getAria]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UnitID", unitId);
                cmd.Parameters.AddWithValue("@companyID", companyId);
                SqlDataAdapter adapter = new(cmd);
                DataSet dataSet = new();
                connection.Open();
                adapter.Fill(dataSet);
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        response.Areas.Add(new Ims_Requisition_GetArea
                        {
                            AreaName = row["AreaName"].ToString(),
                            AreaID = Convert.ToInt64(row["AreaID"]),
                            AreaCode = row["AreaCode"].ToString()
                        });
                    }
                }
                if (dataSet.Tables.Count > 1 && dataSet.Tables[1].Rows.Count > 0)
                {
                    DataRow row = dataSet.Tables[1].Rows[0];
                    response.UnitInfo = new UnitInfo
                    {
                        SBUType = row["SBUType"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching data.", ex);
            }
        }
        return response;
    }

    public async Task<DataSet> GetRemarks(long reqId)
    {
        var ds = new DataSet();
        using var conn = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("[dbo].[Usp_GetRemarks]", conn)
        {
            CommandType = CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@ReqID", reqId);
        var adapter = new SqlDataAdapter(cmd);
        await conn.OpenAsync();
        await Task.Run(() => adapter.Fill(ds));
        return ds;
    }

    public async Task<DataSet> GetRequisitionSearchList([FromBody] Ims_Requisition_ReqSearchList_Reponse _params)
    {
        var ds = new DataSet();
        try
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("[dbo].[Usp_ReqSearchListReq]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = _params.StartDate });
            cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = _params.EndDate });
            cmd.Parameters.AddWithValue("@UnitID", _params.UnitId);
            cmd.Parameters.AddWithValue("@ApprovalStatus", _params.ApprovalStatus);
            cmd.Parameters.AddWithValue("@ReqNo", _params.ReqNo);
            cmd.Parameters.AddWithValue("@CompanyID", _params.CompanyId);
            cmd.Parameters.Add(new SqlParameter("@RequisitionType", SqlDbType.VarChar) { Value = _params.ReqType });
            cmd.Parameters.AddWithValue("@SearchStat", _params.SearchStat);
            cmd.Parameters.AddWithValue("@ReqID", _params.ReqId);
            cmd.Parameters.AddWithValue("@SbuType", _params.SBUType);
            cmd.Parameters.AddWithValue("@Layer", _params.Layer);
            var adapter = new SqlDataAdapter(cmd);
            await conn.OpenAsync();
            await Task.Run(() => adapter.Fill(ds));
        }
        catch (SqlException sqlEx)
        {
            throw new Exception("SQL error occurred while fetching the requisition search list.", sqlEx);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while fetching the requisition search list.", ex);
        }
        return ds;
    }

    public async Task<DataSet> GetUnitAreaLocation(long unitId, long areaId)
    {
        var ds = new DataSet();
        using var conn = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("[dbo].[Usp_GetUnitAreaLocation]", conn)
        {
            CommandType = CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@UnitID", unitId);
        cmd.Parameters.AddWithValue("@AreaID", areaId);
        var adapter = new SqlDataAdapter(cmd);
        await conn.OpenAsync();
        await Task.Run(() => adapter.Fill(ds));
        return ds;
    }

    public async Task<long> InsertOrUpdateUnitLOcation(Ims_Requisition_UnitLocation_Request _params)
    {
        long result = 0;
        try
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("Usp_UnitLocationInsUpd", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LocationID", _params.LocationId);
            cmd.Parameters.AddWithValue("@LocationName", _params.LocationName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@AreaID", _params.AreaId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@UnitID", _params.UnitId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CompanyID", _params.CompanyId ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedUID", _params.CreatedUid ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@entrypoint", _params.EntryPoint ?? (object)DBNull.Value);
            await conn.OpenAsync();
            result = Convert.ToInt64(await cmd.ExecuteScalarAsync());
        }
        catch (SqlException sqlEx)
        {
            throw new Exception("An SQL error occurred while inserting or updating the unit location.", sqlEx);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while inserting or updating the unit location.", ex);
        }
        return result;
    }

    public long InsertUpdateArea(Ims_Requisition_AreaRequest _params)
    {
        long result = -1;
        var connection = new SqlConnection(_connectionString);
        try
        {
            using SqlCommand cmd = new("[dbo].[Usp_AreaInsupd]", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AreaID", _params.AreaId);
            cmd.Parameters.AddWithValue("@AreaName", _params.AreaName);
            cmd.Parameters.AddWithValue("@UnitId", _params.UnitId);
            cmd.Parameters.AddWithValue("@CompanyID", _params.CompanyId);
            cmd.Parameters.AddWithValue("@CreatedUID", _params.CreatedUid);
            cmd.Parameters.AddWithValue("@entrypoint", _params.EntryPoint);
            connection.Open();
            object returnValue = cmd.ExecuteScalar();
            if (returnValue != null)
            {
                result = Convert.ToInt64(returnValue);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while inserting/updating the area.", ex);
        }
        return result;
    }
    #region Requisition List
    public async Task<DataSet> GetRequisitionAllItem(long reqId)
    {
        var ds = new DataSet();
        using var conn = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("[dbo].[USP_GETREQUISITIONITEMDTLS]", conn)
        {
            CommandType = CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@ReqID", reqId);
        var adapter = new SqlDataAdapter(cmd);
        await conn.OpenAsync();
        await Task.Run(() => adapter.Fill(ds));
        return ds;
    }
    public async Task<long> InsertOrUpdateRequisitionApproval(Ims_Requisition_ReqApproval _params)
    {
        long result = -1;
        using (var connection = new SqlConnection(_connectionString))
        {
            try
            {
                using SqlCommand cmd = new("[dbo].[Usp_RequisitionApproved]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReqId", _params.ReqId);
                cmd.Parameters.AddWithValue("@STA", _params.STA);
                cmd.Parameters.AddWithValue("@uid", _params.Uid);
                await connection.OpenAsync();
                object returnValue = cmd.ExecuteScalarAsync();
                if (returnValue != null)
                {
                    result = Convert.ToInt64(returnValue);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting/updating the area.", ex);
            }
        }
        return result;
    }
    #endregion
}
