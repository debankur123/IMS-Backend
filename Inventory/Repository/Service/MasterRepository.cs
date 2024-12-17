﻿// ReSharper disable All
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

        #region UOM
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
        #endregion

        #region Unit/SBU
        public int AddUpdateUnitDetails(UnitModel unit)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_UnitInsertUpdate", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@UnitID", unit.UnitID);
            cmd.Parameters.AddWithValue("@UnitName", unit.UnitName);
            cmd.Parameters.AddWithValue("@SBUcode", unit.SBUcode);
            cmd.Parameters.AddWithValue("@ShortCode", unit.ShortCode);
            cmd.Parameters.AddWithValue("@SBUType", unit.SBUType);
            cmd.Parameters.AddWithValue("@Address", unit.Address);
            cmd.Parameters.AddWithValue("@Phone", unit.Phone);
            cmd.Parameters.AddWithValue("@Email", unit.Email);
            cmd.Parameters.AddWithValue("@LogoUrl", unit.LogoUrl);
            cmd.Parameters.AddWithValue("@ImageData", unit.ImageData);
            cmd.Parameters.AddWithValue("@CompanyID", unit.CompanyID);
            cmd.Parameters.AddWithValue("@CreatedUID", unit.CreatedUID);
            var outputIdParam = new SqlParameter("@OutPutId", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outputIdParam);
            conn.Open();
            cmd.ExecuteNonQuery();
            var outputId = (long)outputIdParam.Value;
            return (int)outputId;
        }

        public DataSet GetUnitDetailsList()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridBindUnit", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        #endregion

        #region Area/Department
        public DataSet GetAreaDepartmentDetailsList()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridBindArea", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public int AddUpdateAreaDepartmentDetails(AreaDepartmentModel area)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_AreaInsertUpdate", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@AreaID", area.AreaID);
            cmd.Parameters.AddWithValue("@AreaName", area.AreaName);
            cmd.Parameters.AddWithValue("@AreaCode", area.AreaCode);
            cmd.Parameters.AddWithValue("@UnitID", area.UnitID);
            cmd.Parameters.AddWithValue("@CompanyID", area.CompanyID);
            cmd.Parameters.AddWithValue("@CreatedUID", area.CreatedUID);
            var outputIdParam = new SqlParameter("@OutPutId", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outputIdParam);
            conn.Open();
            cmd.ExecuteNonQuery();
            var outputId = (long)outputIdParam.Value;
            return (int)outputId;
        }
        #endregion

        #region Unit Location Section
        public DataSet GetUnitLocationDetailsList()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridBindLocation", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public int AddUpdateUnitLocationDetails(UnitLocationModel unitLocation)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_LocationInsertUpdate", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@LocationID", unitLocation.LocationID);
            cmd.Parameters.AddWithValue("@AreaID", unitLocation.AreaID);
            cmd.Parameters.AddWithValue("@LocationName", unitLocation.LocationName);
            cmd.Parameters.AddWithValue("@LocationCode", unitLocation.LocationCode);
            cmd.Parameters.AddWithValue("@UnitID", unitLocation.UnitID);
            cmd.Parameters.AddWithValue("@CompanyID", unitLocation.CompanyID);
            cmd.Parameters.AddWithValue("@CreatedUID", unitLocation.CreatedUID);
            var outputIdParam = new SqlParameter("@OutPutId", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outputIdParam);
            conn.Open();
            cmd.ExecuteNonQuery();
            var outputId = (long)outputIdParam.Value;
            return (int)outputId;
        }
        #endregion

        #region Job Type Section
        public DataSet GetJobTypeDetailsList()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridJobType", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public int AddUpdateJobTypeDetails(JobTypeModel jobType)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_JobTypeInsertUpdate", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@JobTypeID", jobType.JobTypeID);
            cmd.Parameters.AddWithValue("@JobTypeName", jobType.JobTypeName);
            cmd.Parameters.AddWithValue("@CompanyID", jobType.CompanyID);
            cmd.Parameters.AddWithValue("@CreatedUID", jobType.CreatedUID);
            var outputIdParam = new SqlParameter("@OutPutId", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outputIdParam);
            conn.Open();
            cmd.ExecuteNonQuery();
            var outputId = (long)outputIdParam.Value;
            return (int)outputId;
        }
        #endregion

        #region Job Section
        public DataSet GetJobDetailsList()
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

        public int AddUpdateJobDetails(JobModel job)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_JobInsertUpdate", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@JobTypeID", job.JobTypeID);
            cmd.Parameters.AddWithValue("@JobID", job.JobID);
            cmd.Parameters.AddWithValue("@JobName", job.JobName);
            cmd.Parameters.AddWithValue("@JobNmaedescr", job.JobNmaedescr);
            cmd.Parameters.AddWithValue("@CompanyID", job.CompanyID);
            cmd.Parameters.AddWithValue("@CreatedUID", job.CreatedUID);
            var outputIdParam = new SqlParameter("@OutPutId", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outputIdParam);
            conn.Open();
            cmd.ExecuteNonQuery();
            var outputId = (long)outputIdParam.Value;
            return (int)outputId;
        }
        #endregion

        #region Item Group Section
        public DataSet GetItemGroupDetailsList()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridItemGroup", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public int AddUpdateItemGroupDetails(ItemGroupModel itemGroup)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_ItemGroupInsertUpdate", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ItemGroupID", itemGroup.ItemGroupID);
            cmd.Parameters.AddWithValue("@ItemGroupName", itemGroup.ItemGroupName);
            cmd.Parameters.AddWithValue("@CompanyID", itemGroup.CompanyID);
            cmd.Parameters.AddWithValue("@CreatedUID", itemGroup.CreatedUID);
            var outputIdParam = new SqlParameter("@OutPutId", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outputIdParam);
            conn.Open();
            cmd.ExecuteNonQuery();
            var outputId = (long)outputIdParam.Value;
            return (int)outputId;
        }
        #endregion

        #region Item Sub Group Section
        public DataSet GetItemSubGroupDetailsList()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridItemSubGroup", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public int AddUpdateItemSubGroupDetails(ItemSubGroupModel itemSubGroup)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_ItemSubGroupInsertUpdate", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ItemGroupID", itemSubGroup.ItemGroupID);
            cmd.Parameters.AddWithValue("@ItemSubGroupID", itemSubGroup.ItemSubGroupID);
            cmd.Parameters.AddWithValue("@ItemSubGroupName", itemSubGroup.ItemSubGroupName);
            cmd.Parameters.AddWithValue("@SetSubGroupName", itemSubGroup.SetSubGroupName);
            cmd.Parameters.AddWithValue("@CompanyID", itemSubGroup.CompanyID);
            cmd.Parameters.AddWithValue("@CreatedUID", itemSubGroup.CreatedUID);
            var outputIdParam = new SqlParameter("@OutPutId", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outputIdParam);
            conn.Open();
            cmd.ExecuteNonQuery();
            var outputId = (long)outputIdParam.Value;
            return (int)outputId;
        }
        #endregion

        #region Bank Section
        public DataSet GetBankDetailsList()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridBindBank", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public int AddUpdateBankDetails(BankModel bank)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_BankInsertUpdate", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@BankID", bank.BankID);
            cmd.Parameters.AddWithValue("@BankName", bank.BankName);
            cmd.Parameters.AddWithValue("@BaranchName", bank.BaranchName);
            cmd.Parameters.AddWithValue("@Ifsc_Code", bank.Ifsc_Code);
            var outputIdParam = new SqlParameter("@OutPutId", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outputIdParam);
            conn.Open();
            cmd.ExecuteNonQuery();
            var outputId = (long)outputIdParam.Value;
            return (int)outputId;
        }
        #endregion

        #region Vendor Section
        public DataSet GetVendorDetailsList()
        {
            var ds = new DataSet();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("Usp_GridBindCustomerVendor", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
        #endregion
        
    }
}

