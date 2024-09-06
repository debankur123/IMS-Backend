using Inventory.Models.Entity;
using Inventory.Repository.DBContext;
using Inventory.Repository.IService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System;
using Inventory.AppCode;
using Inventory.Extensions;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.Common;
using Dapper;
using System.Drawing;
using System.Runtime.InteropServices.JavaScript;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Inventory.Repository.Service
{
    public class CommonService
    {
        #region Declaration
        private readonly IDbConnection _dbConnection;
        private readonly ImsDbContext _dbContext;
        bool result = true;
        #endregion
        public CommonService(IConfiguration Configuration)
        {
            ConnectionHelper connectionHelper = new ConnectionHelper(Configuration);
            _dbConnection = connectionHelper.GetDbConnection();
            _dbContext = connectionHelper.GetDbContext();
        }
        #region Connection
        private void connectionOpen()
        {
            _dbConnection.Open();
            _dbConnection.BeginTransaction();
        }
        private void connectionClose()
        {
            _dbConnection.Dispose();
            _dbConnection.Close();
        }
        #endregion
        public async Task<string> AddUpdate()
        {
            string ReturnOutPut = string.Empty;
            try
            {
                connectionOpen();
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Column", "Data");
                ObjParm.Add("@ReturnOutPut", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                _ = await _dbConnection.ExecuteAsync("StoreProcedureName", ObjParm, commandType: CommandType.StoredProcedure);
                //Getting the out parameter value of stored procedure  
                ReturnOutPut = ObjParm.Get<string>("@ReturnOutPut");
            }
            catch (Exception)
            {
                connectionClose();
                result = false;
            }
            //Audit Helper
            if (result)
            {
                return ReturnOutPut;
            }
            else
            {
                return ReturnOutPut;
            }

        }
        public async Task<DataTable> GetTable(string TableName)
        {
            DataTable dt = new DataTable();
            try
            {
                connectionOpen();
                var ObjParm = new { TableName = TableName };
                dt.Load(await _dbConnection.ExecuteReaderAsync("storedProcedureName", ObjParm, commandType: CommandType.StoredProcedure));
            }
            catch (Exception)
            {
                connectionClose();
                result = false;
            }
            //Audit Helper
            if (result)
            {
                return dt;
            }
            else
            {
                return dt;
            }
        }
        
    }
}
