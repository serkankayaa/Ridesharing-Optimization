using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace RV_Graph
{
    class Distance
    {
        public double Distance_Measure(string origin,string destination)
        {
            double distanceValue = 0;
            Uri uriGeocode = Geocode.GetCoordinates(origin, destination);
            Geocode geo = new Geocode();
            using (WebClient webclient = new System.Net.WebClient())
            {
                WebClient n = new WebClient();
                var json = n.DownloadString(uriGeocode);
                string valueOriginal = Convert.ToString(json);
                JObject result = JObject.Parse(json);
                string distance = (string)result["rows"][0]["elements"][0]["distance"]["text"].ToString();
                distanceValue = geo.ClearDistance(distance);

            }
            return distanceValue;
        }
    }
}
