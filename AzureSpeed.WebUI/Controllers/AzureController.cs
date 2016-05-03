namespace AzureSpeed.WebUI
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public class AzureController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Latency()
        {
            return View();
        }


        public ActionResult TrafficManager()
        {
            WebClient client = new WebClient();
            string ip = client.DownloadString("http://www.azurespeed.com/api/ip").Replace("\"", "").Trim();
            if (!string.IsNullOrEmpty(ip))
            {
                ViewBag.Ip = ip;
                var controller = new AzureApiController();
                ViewBag.Region = controller.GetRegionNameByIpOrUrl(ip);
            }
            return View();
        }

        public ActionResult Reference()
        {
            return View();
        }
    }

    public class SasUrl
    {
        public string Storage { get; set; }
        public string Url { get; set; }
    }

    public class AwsIpRangeData
    {
        public string syncToken { get; set; }
        public string createDate { get; set; }

        public List<prefix> prefixes { get; set; }
    }

    public class prefix
    {
        public string ip_prefix { get; set; }
        public string region { get; set; }
        public string service { get; set; }
    }
}