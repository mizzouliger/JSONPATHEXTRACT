using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonPath
{
    public class GetCityForState
    {
       public static void Main(string[] args)
        {
            if (args.Length == 0) {
                Console.WriteLine("Please enter at least one argument");
                Environment.Exit(1);
            }
            else { 
            Task T = new Task(() => ApiCall(args));
            
            T.Start();
            Console.ReadLine();
            Environment.Exit(0);
                T.Dispose();
            }
        }
        public static async void ApiCall(string[] input)
        {

            using (var client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync("http://services.groupkt.com/state/get/USA/all");

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseBody);

                dynamic dynJson = JsonConvert.DeserializeObject<dynamic>(responseBody);

                foreach (var x in dynJson)
                {
                    var key = ((JProperty)(x)).Name;
                    var jvalue = ((JProperty)(x)).Value;
                    foreach (var value in jvalue)
                    {
                        if (value.ToString().Contains("result"))
                        {
                            //string[] resultArray = new string[] { };
                            var resultArrays = value.ToList();
                            foreach (var resultValue in resultArrays[0])
                            {
                                if (resultValue["name"].ToString() == input[0]) {
                                    Console.WriteLine("The capital of the state is " + resultValue["capital"]);
                                }
                                
                            }
                        }
                    }
                }

                
            }
        }
            
            public class ObjectList
            {
                public string country { get; set; }
                public string name { get; set; }
                public string area { get; set; }
                public string largest_city { get; set; }
            }

            public class RootObj
            {
                 public string objectType { get; set; }
                 public List<ObjectList> objectList { get; set; }
            }
        }
    }
