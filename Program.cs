using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;


namespace NetWx
{
    class Program
    {
        static void Main(string[] args)
        {
            string id;
            try
            {
                id = args[0].ToLower();
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Enter a station ID. (e.g. 'kiad')");
                id = Console.ReadLine().ToLower();
            }

            var currentWeather = GetWeather(id);

            Console.WriteLine("The current conditons at " + id.ToUpper() + " are " + currentWeather.Conditions + ".");
            Console.WriteLine("The temperature is " + currentWeather.TempC.ToString("#.0") + " C, " + currentWeather.getDegreesF().ToString("#.0") + " F.");

        }

        /// <summary>
        /// Gets the current weather from the NWS API.
        /// </summary>
        /// <param name="id">The NWS station ID.</param>
        /// <returns>Current weather at id.</returns>
        private static WeatherInfo GetWeather(string id)
        {
            var uri = "https://api.weather.gov/stations/" + id + "/observations/current";

            // setup http request
            WebRequest request = WebRequest.Create(uri);
            ((HttpWebRequest)request).UserAgent = ".NET Core Client";
            WebResponse response;
            
            // make the http request
            try
            {
                response = request.GetResponse();
            }
            catch(WebException)
            {
                // if request is invalid, exit
                response = null;
                Console.WriteLine("Invalid station ID");
                Environment.Exit(1);
            }
            
            // read the response
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            var rawResponse = reader.ReadToEnd();

            //cleanup 
            reader.Close();
            dataStream.Close();

            // parse the response using Newtonsoft JSON
            JObject o = JObject.Parse(rawResponse);
            var currentCond = (string)o["properties"]["textDescription"];
            var currentTempC = (double)o["properties"]["temperature"]["value"];

            WeatherInfo currentWeather = new WeatherInfo { Conditions = currentCond, TempC = currentTempC };

            return currentWeather;            
        }
    }
}
