using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDownLoadSystem.Core.Utility
{
    public class WebResponseContent
    {
        // 2xx 属于正确请求 204 请求正确但是没有返回值;202 请求正确，但是服务器中没有做任何数据的变化；203 没有权限
        // 3xx 地址迁移，是错误的，一般不包含返回值
        public bool Status { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static WebResponseContent Instance => new WebResponseContent();

        public WebResponseContent()
        {

        }

        public WebResponseContent(bool status)
        {
            this.Status = status;
        }

        public WebResponseContent OK()
        {
            this.Status = true;
            return this;
        }

        public WebResponseContent OK(ResponseType responseType)
        {
            return Set(responseType, true);
        }

        public WebResponseContent OK(string msg = null, object data = null)
        {
            this.Status = true;
            this.Message = msg;
            this.Data = data;
            return this;
        }

        public WebResponseContent Error(string msg = null)
        {
            this.Status = false;
            this.Message = msg;
            return this;
        }

        public WebResponseContent Error(ResponseType responseType)
        {
            return Set(responseType, false);
        }

        public WebResponseContent Set(ResponseType responseType, bool? status)
        {
            return this.Set(responseType, null, status);
        }

        public WebResponseContent Set(ResponseType responseType, string msg, bool? status)
        {
            if (status != null)
            {
                this.Status = (bool)status;
            }

            this.Code = ((int)responseType).ToString();

            if (!string.IsNullOrEmpty(msg))
            {
                Message = msg;
                return this;
            }

            return this;
        }
    }

    public enum ResponseType
    {
        ServerError = 1,
        LoginExpiration = 302,
        ParametersLack = 303,
        TokenExpiration,
        PINError,
        NoPermissions,
        NoRolePermissions,
        LoginError,
        AccountLocked,
        LoginSuccess,
        SaveSuccess,
        AuditSuccess,
        OperateSuccess,
        RegisterSuccess,
        ModifyPwdSuccess,
        EditSuccess,
        DelSuccess,
        NoKey,
        NoKeyDel,
        KeyError,
        Other
    }
}