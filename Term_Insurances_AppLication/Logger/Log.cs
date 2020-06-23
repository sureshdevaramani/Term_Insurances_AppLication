using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Term_Insurances_AppLication.Logger
{
    public class Log: ActionFilterAttribute, IExceptionFilter
    {
      
        public void OnException(ExceptionContext Ex)
            {
                string message = "\n" + Ex.RouteData.Values["controller"].ToString() + " -->" + Ex.RouteData.Values["action"].ToString() + "-->"
                    + Ex.Exception.Message + "\t - " + DateTime.Now.ToString() + "\n";
                logexeceptions(message);
                logexeceptions("------------------------");
            }

            public void logexeceptions(string mes)
            {
                File.AppendAllText(HttpContext.Current.Server.MapPath("~/File/File.txt"), mes);
            }

        }

    }
