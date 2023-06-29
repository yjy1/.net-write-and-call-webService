using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebserviceDemo
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
     [System.Web.Script.Services.ScriptService]
     

    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string GetAge(string id)
        {
            return "ID为:" + id + "的年龄为:" + new Random().Next(10, 41);
        }

        /// <summary>
        /// 用于前端跨越调用（jsonp）
        /// </summary>
        /// <param name="name"></param>
        [WebMethod]
        public void HelloWorld1(string name)
        {
            HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
            string jsonCallBackFunName = string.Empty;
            jsonCallBackFunName = HttpContext.Current.Request.Params["jsoncallback"].ToString();
            HttpContext.Current.Response.Write(jsonCallBackFunName + "({ \"Result\": \"Helloword2" + name + "\" })");
        }

        /// <summary>
        /// 用于前端跨域调用（在system.webServer下增加可跨域访问配置）
        /// </summary>
        /// <param name="name"></param>
        [WebMethod]
        public string HelloWorld2(string name)
        {
            return "{data:你好：" + name + "}";
        }
    }
}
