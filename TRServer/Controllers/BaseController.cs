using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Web.Http;
using NLog;
using System.Web.Http.Description;

namespace TRServer.Controllers
{
    public class BaseController : ApiController
    {
        private string _adminMsg = "An error has occured the administrator has been notified";
        public static Logger logger = LogManager.GetCurrentClassLogger();
        public string GetAdminMsg
        {
            get { return _adminMsg; }
        }
        public string GetLanguageCode()
        {
            var languageCode = "EN";
            var paramList = Request.Headers.AcceptLanguage.ToList();
            paramList.ForEach(param =>
            {
                if (param.Value.ToUpper() == "EN-US")
                {
                    languageCode = "EN";
                }             
            });
            return languageCode;
        }
        public DateTime? ConvertToDateTime (string fromDate)
        {
            DateTime? fromdtFinal;
            DateTime fromdt;
            if (!DateTime.TryParse(fromDate, out fromdt))
            {
                fromdtFinal = null;
            }
            else
            {
                fromdtFinal = fromdt;
            }
            return fromdtFinal;

        }
    }
}