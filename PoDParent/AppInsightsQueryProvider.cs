using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace PoDParent
{
    class AppInsightsQueryProvider
    {
        private const string URL = "https://api.applicationinsights.io/beta/apps/{0}/{1}?{2}";

        public static string GetTelemetry(string appid, string apikey,
            string operation, string parameters)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-key", apikey);
            var req = string.Format(URL, appid, operation, parameters);
            HttpResponseMessage response = client.GetAsync(req).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return response.ReasonPhrase;
            }
        }

        public static string GetQueryResult(string appid, string apikey, string query)
        {
            return GetTelemetry(appid, apikey, "query", "query=" + query);
        }
    }

}