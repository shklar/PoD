using Microsoft.ApplicationInsights;
using PoDParent.Models;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Microsoft.Azure.Devices;

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
            client.InstrumentationKey = ConfigurationManager.AppSettings["ikey"];
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
            SendMessageToDevice("shutdown");

        }

        // Post: Form
        public void SendMessageToDevice(string message)
        {
            string connectionString = ConfigurationManager.AppSettings["iothub"];
            var serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
            var commandMessage = new Message(Encoding.ASCII.GetBytes(message));
            serviceClient.SendAsync("myFirstDevice", commandMessage).Wait();

        }


    }
}