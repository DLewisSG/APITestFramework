using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace API_App
{
    public class SingleOutcodeService
    {
        #region Properties
        //RestSharp object which handles communication with the API
        public RestClient RestClientOC;
        //Restsharp response
        public IRestResponse RestResponseOC { get; set; }

        //NewtonSoft object representing the JSON response
        public JObject ResponseContentOC { get; set; }


        public SingleOutcodeResponse ResponseObjectOC { get; set; }

        public string OutcodeSelected { get; set; }
        #endregion

        // constructor - creates restClient object
        public SingleOutcodeService()
        {
            RestClientOC = new RestClient { BaseUrl = new Uri(AppConfigReader.BaseUrl) };
        }

        public async Task MakeRequestAsync(string outcode)
        {
            // set up request
            var requestOC = new RestRequest();
            requestOC.AddHeader("Content-Type", "application/json");
            OutcodeSelected = outcode;

            //define request resource path, changing to lowercase and removing whitespace
            requestOC.Resource = $"outcodes/{outcode.ToLower().Replace(" ", "")}";

            //make request
            RestResponseOC = await RestClientOC.ExecuteAsync(requestOC);

            // parse Json into a JObject
            ResponseContentOC = JObject.Parse(RestResponseOC.Content);

            // parse response body into an object tree
            ResponseObjectOC = JsonConvert.DeserializeObject<SingleOutcodeResponse>(RestResponseOC.Content);
        }
    }
}
