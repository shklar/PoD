using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace PoDParent
{
    public class AppInsightsDAL
    {
        //const string DailyDistanceSumQuery = "metrics | where timestamp+3h > bin(now(), 1d) and name=='Distance' | summarize sum(value) ";
        const string DailyDistanceSumQuery = "metrics | where name==\"Distance\" |  where timestamp > startofday(now()) | summarize sum(value)";
        public static int GetDailyDistanceBalance (string appid, string apikey)
        {
            var json = AppInsightsQueryProvider.GetQueryResult(appid, apikey, DailyDistanceSumQuery);
            dynamic x = JObject.Parse(json);
            var t = x.Tables[0].Rows[0];

            var vardouble= double.Parse(Convert.ToString(t.First.Value));
            return (int)vardouble;


        }
    }
}