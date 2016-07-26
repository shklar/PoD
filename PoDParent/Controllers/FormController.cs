using Microsoft.ApplicationInsights;
using PoDParent.Models;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoDParent.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Reward(RewardModel modelData)
        {
            TelemetryClient client = new TelemetryClient();
            client.InstrumentationKey = "15029e3b-b0b2-4b53-88a2-4c4f7f6a6b0c";
            client.TrackMetric("Distance", modelData.RewardValueIntData);
        }

        // GET: Form
        public int Balance()
        {            
            string appid = ConfigurationManager.AppSettings["appid_1"];
            string apikey = ConfigurationManager.AppSettings["apikey_1"];

            int balance = AppInsightsDAL.GetDailyDistanceBalance(appid, apikey);
            return balance;
             
        }

        // GET: Form
        public void ShutDown()
        {
         

        }
    }
}