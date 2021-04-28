using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace API_App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var restClient = new RestClient("https://api.postcodes.io/");
            var restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Timeout = -1;

            var postcode = "ML2 7BF";
            restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

            var restResponse = await restClient.ExecuteAsync(restRequest);
            Console.WriteLine("Response content (string):");
            Console.WriteLine(restResponse.Content);

            var jsonResponse = JObject.Parse(restResponse.Content);
            Console.WriteLine("\nResponse content as a JObject");
            Console.WriteLine(jsonResponse);

            var adminDistrict = jsonResponse["result"]["admin_district"];
            Console.WriteLine($"Admin district: {adminDistrict}");

            var adminWard = jsonResponse["result"]["admin_ward"];
            Console.WriteLine($"Admin ward: {adminWard}");

            var parishCode = jsonResponse["result"]["parish"];
            Console.WriteLine($"Parish code: {parishCode}");

            var singlePostCode = JsonConvert.DeserializeObject<SinglePostcodeResponse>(restResponse.Content);

            //var client = new RestClient("https://api.postcodes.io/postcodes/EC2Y5AS");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Cookie", "__cfduid=df554b2eae91562c0f2497ed9f43587741619432189");
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            var client = new RestClient("https://api.postcodes.io/postcodes/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "__cfduid=df554b2eae91562c0f2497ed9f43587741619432189");
            request.AddParameter("application/json", "{\r\n    \"postcodes\" : [\"OX49 5NU\", \"M32 0JG\", \"NE30 1DP\"]\r\n}\r\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            var bulkJsonResponse = JObject.Parse(response.Content);

            var bulkPostcodeResponse = JsonConvert.DeserializeObject<BulkPostcodeResponse>(response.Content);

            var adminDistrictFromBPR = bulkPostcodeResponse.result[1].result.admin_district;
            Console.WriteLine($"Admin district of the second postcode: {adminDistrictFromBPR}");

            var parishFromBPR = bulkPostcodeResponse.result[2].result.parish;
            Console.WriteLine($"Parish of the second postcode: {parishFromBPR}");

            var postcodeFromBPR = bulkPostcodeResponse.result[0].result.postcode;
            Console.WriteLine($"Postcode of the first object: {postcodeFromBPR}");



            var restClientOC = new RestClient("https://api.postcodes.io/outcodes/");
            var restRequestOC = new RestRequest();
            restRequestOC.Method = Method.GET;
            restRequestOC.AddHeader("Content-Type", "application/json");
            restRequestOC.Timeout = -1;

            var outcode = "EC2Y";
            restRequestOC.Resource = $"outcodes/{outcode}";

            var restResponseOC = await restClientOC.ExecuteAsync(restRequestOC);
            Console.WriteLine("Response content (string):");
            Console.WriteLine(restResponseOC.Content);

            var jsonResponseOC = JObject.Parse(restResponseOC.Content);
            Console.WriteLine("\nResponse content as a JObject");
            Console.WriteLine(jsonResponseOC);

            var longitude = jsonResponseOC["result"]["longitude"];
            Console.WriteLine($"Longitude: {longitude}");

            var country = jsonResponseOC["result"]["country"];
            Console.WriteLine($"Country: {country}");

            var singleOutCode = JsonConvert.DeserializeObject<SingleOutcodeResponse>(restResponseOC.Content);
        }
    }
}
