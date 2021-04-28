//using System;
//using Newtonsoft.Json.Linq;
//using RestSharp;
//using Newtonsoft.Json;
//using System.Threading.Tasks;

//namespace API_App
//{
//    public class OutcodeProgram
//    {
//        static async Task Main(string[] args)
//        {
//            var restClient = new RestClient("https://api.postcodes.io/outcodes/");
//            var restRequest = new RestRequest();
//            restRequest.Method = Method.GET;
//            restRequest.AddHeader("Content-Type", "application/json");
//            restRequest.Timeout = -1;

//            var outcode = "ML2";
//            restRequest.Resource = $"outcodes/{outcode.ToLower().Replace(" ", "")}";

//            var restResponse = await restClient.ExecuteAsync(restRequest);
//            Console.WriteLine("Response content (string):");
//            Console.WriteLine(restResponse.Content);

//            var jsonResponse = JObject.Parse(restResponse.Content);
//            Console.WriteLine("\nResponse content as a JObject");
//            Console.WriteLine(jsonResponse);

//            var longitude = jsonResponse["result"]["longitude"];
//            Console.WriteLine($"Longitude: {longitude}");

//            var country = jsonResponse["result"]["country"];
//            Console.WriteLine($"Country: {country}");

//            var singleOutCode = JsonConvert.DeserializeObject<SingleOutcodeResponse>(restResponse.Content);

//        }
//    }
//}