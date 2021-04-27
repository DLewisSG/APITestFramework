using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace API_App
{
    public class SinglePostcodeService
    {
        #region Properties
        //RestSharp object which handles communication with the API
        public RestClient Client;
        //Restsharp response
        public IRestResponse RestResponse { get; set; }

        //NewtonSoft object representing the JSON response
        public JObject ResponseContent { get; set; }

        
        public SinglePostcodeResponse ResponseObject { get; set; }

        //the postcode used in this API request
        public string PostcodeSelected { get; set; }
        #endregion

        // constructor - creates restClient object
        public SinglePostcodeService()
        {
            Client = new RestClient { BaseUrl = new Uri(AppConfigReader.BaseUrl) };
        }

        public async Task MakeRequestAsync(string postcode)
        {
            // set up request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            PostcodeSelected = postcode;

            //define request resource path, changing to lowercase and removing whitespace
            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

            //make request
           RestResponse = await Client.ExecuteAsync(request);

            // parse Json into a JObject
            ResponseContent = JObject.Parse(RestResponse.Content);

            // parse response body into an object tree
            ResponseObject = JsonConvert.DeserializeObject<SinglePostcodeResponse>(RestResponse.Content);
        }
    }
}
