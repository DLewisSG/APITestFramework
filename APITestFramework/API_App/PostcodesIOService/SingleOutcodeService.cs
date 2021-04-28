using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using API_App.PostcodesIOService;

namespace API_App.PostcodeIOService
{
    public class SingleOutcodeService
    {
        #region Properties
        public CallManager CallManager { get; }
        //NewtonSoft object representing the JSON response
        public JObject ResponseContentOC { get; set; }
        public SingleOutcodeDTO SingleOutcodeDTO { get; set; }

        //the postcode used in this API request
        public string OutcodeSelected { get; set; }

        public string OutcodeResponse { get; set; }
        #endregion

        // constructor - creates restClient object
        public SingleOutcodeService()
        {
            CallManager = new CallManager();
            SingleOutcodeDTO = new SingleOutcodeDTO();
        }

        public async Task MakeRequestAsync(string postcode)
        {
            OutcodeSelected = postcode;

            //make request
            OutcodeResponse = await CallManager.MakeSingleOutcodeRequest(postcode);

            // parse Json into a JObject
            ResponseContentOC = JObject.Parse(OutcodeResponse);

            // parse response body into an object tree
            SingleOutcodeDTO.DeserializeResponse(OutcodeResponse);
        }
    }
}
