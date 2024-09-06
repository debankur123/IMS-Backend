using Azure;
using Common_Helper.CommonHelper;
using Dapper;
using Inventory.AppCode;
using Inventory.Extensions;
using Inventory.Models.Entity;
using Inventory.Models.Request;
using Inventory.Models.Response;
using Inventory.Repository.DBContext;
using Inventory.Repository.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Inventory.Repository.Service
{
    public class AuthService : IAuthService
    {
        #region Declaration
        private readonly IDbConnection _dbConnection;
        private readonly ImsDbContext _dbContext;
        bool result = true;
        AuditLog.BeLogLevel _errorlevel = AuditLog.BeLogLevel.Information;
        AuditLog.BeLogType _errortype = AuditLog.BeLogType.Success;
        string? ExceptionMsg = "";
        string? METHODNAME = "";
        string? TableID = "";
        public AuthService(IConfiguration Configuration)
        {
            ConnectionHelper connectionHelper = new ConnectionHelper(Configuration);
            _dbConnection = connectionHelper.GetDbConnection();
            _dbContext = connectionHelper.GetDbContext();
        }
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
        public async Task<LoginResponse?> GetLoginDetails(LoginRequest user, AuditLogHelper _auditLogHelper)
        {
            LoginResponse? LoginResponse = new LoginResponse();
            METHODNAME = "GetLoginDetails";
            TableID = user.UserName;
            ExceptionMsg = "Successful To Get Login Details";
            try
            {
                string SqlQuery = LoginSql();
                var parameters = new { UserName = user.UserName, Password = user.Password };
                LoginResponse = await _dbConnection.QuerySingleOrDefaultAsync<LoginResponse>(SqlQuery, parameters);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                ExceptionMsg = "Faild To Get Login Details : - " + ex.Message;
                _errorlevel = AuditLog.BeLogLevel.Error;
                _errortype = AuditLog.BeLogType.SQL;
            }
            //Audit Helper
            AuditLog.CallLog(_auditLogHelper, _errorlevel, _errortype, METHODNAME, TableID, ExceptionMsg);
            if (result)
            {
                return LoginResponse;
            }
            else
            {
                throw new ArgumentNullException(nameof(ExceptionMsg));
            }
        }
        public static string LoginSql()
        {
            string query = " SELECT ISNULL(Email,'')AS Email, ISNULL(CONVERT(VARCHAR(50),UserId),'')AS UserId " +
                            " FROM [User] Where UserName = @UserName AND Password = @Password ";
            return query;
        }
        public async Task<bool> UpdateRefreshToken(TokenResponse tokenResponse, Guid? UserId, AuditLogHelper _auditLogHelper)
        {
            METHODNAME = "UpdateRefreshToken";
            TableID = UserId.ToString();
            ExceptionMsg = "Successfull To Update Refresh Token";
            try
            {
                var user = await _dbContext.Users.Where(u => u.UserId == UserId).FirstAsync();
                user.RefreshToken = tokenResponse.RefreshToken;
                user.RefreshTokenExpiryDate = DateTime.Now.AddDays(7);
                user.RefreshTokenStartDate = DateTime.Now;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                ExceptionMsg = "Faild To Update Refresh Token : - " + ex.Message;
                _errorlevel = AuditLog.BeLogLevel.Error;
                _errortype = AuditLog.BeLogType.SQL;
            }
            //Audit Helper
            AuditLog.CallLog(_auditLogHelper, _errorlevel, _errortype, METHODNAME, TableID, ExceptionMsg);
            if (result)
            {
                return result;
            }
            else
            {
                throw new ArgumentNullException(nameof(ExceptionMsg));
            }
        }
        public async Task<Guid?> GetValidToken(string? UserName, string? refreshToken, AuditLogHelper _auditLogHelper)
        {
            METHODNAME = "GetValidToken";
            TableID = UserName;
            ExceptionMsg = "Successfull To Get Valid Token";
            Guid? UserId = null;
            try
            {
                string SqlQuery = ValidTokenSql();
                var parameters = new { UserName = UserName };
                var user = await _dbConnection.QuerySingleOrDefaultAsync(SqlQuery, parameters);
                if (user is not null || user?.RefreshToken != refreshToken || user?.RefreshTokenExpiryTime <= DateTime.Now)
                {
                    UserId = user?.UserId;
                    result = true;
                }
                else
                {
                    result = false;
                    ExceptionMsg = "Faild To Get Valid Token";
                }
            }
            catch (Exception ex)
            {
                result = false;
                ExceptionMsg = "Faild To Get Valid Token : - " + ex.Message;
                _errorlevel = AuditLog.BeLogLevel.Error;
                _errortype = AuditLog.BeLogType.SQL;
            }
            //Audit Helper
            AuditLog.CallLog(_auditLogHelper, _errorlevel, _errortype, METHODNAME, TableID, ExceptionMsg);
            if (result)
            {
                return UserId;
            }
            else
            {
                throw new ArgumentNullException(nameof(ExceptionMsg));
            }
        }
        public static string ValidTokenSql()
        {
            string query = "";
            query = " SELECT UserId, ISNULL(RefreshToken,'')AS RefreshToken, RefreshTokenExpiryDate FROM [User] Where Email = @UserName ";
            return query;
        }
        public async Task<bool> RevokeToken(string? username, AuditLogHelper _auditLogHelper)
        {
            METHODNAME = "RevokeToken";
            TableID = username;
            ExceptionMsg = "Successfull To Revoke Token";
            try
            {
                var user = await _dbContext.Users.Where(u => u.Email == username).FirstAsync();
                user.RefreshToken = null;
                _dbContext.Update(user);
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                ExceptionMsg = "Faild To Revoke Token : - " + ex.Message;
                _errorlevel = AuditLog.BeLogLevel.Error;
                _errortype = AuditLog.BeLogType.SQL;
            }
            //Audit Helper
            AuditLog.CallLog(_auditLogHelper, _errorlevel, _errortype, METHODNAME, TableID, ExceptionMsg);
            if (result)
            {
                return result;
            }
            else
            {
                throw new ArgumentNullException(nameof(ExceptionMsg));
            }
        }
    }
}
