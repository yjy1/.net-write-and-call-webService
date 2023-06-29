using net__调用_webService_服务引用和动态代理_.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net__调用_webService_服务引用和动态代理_
{
    class Program
    {

        #region 用于测试调用webservice（服务引用方式）
        public static void Execute1()
        {
            ServiceReference1.WebService1SoapClient testServer = new ServiceReference1.WebService1SoapClient();
            string str1 = testServer.HelloWorld();
            string str2 = testServer.GetAge("b101");
            Console.Write(str1 + "," + str2);
        }
        #endregion

        #region 用于测试调用webservice（动态代理方式）
        public static void Execute2()
        {
            string str1 = WSHelper.InvokeWebService(url: "http://localhost:4116/WebService1.asmx", classname: "WebService1", methodname: "HelloWorld").ToString();
            Console.Write(str1);
            string str2 = WSHelper.InvokeWebService(url: "http://localhost:4116/WebService1.asmx", classname: "WebService1", methodname: "GetAge", args: new string[] { "b101" }).ToString();
            Console.Write(str2);
        }
        #endregion
        static void Main(string[] args)
        {
            Execute1();
            Execute2();
        }
    }
}
