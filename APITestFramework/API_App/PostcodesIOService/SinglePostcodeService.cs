using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace API_App.PostcodesIOService
{
    public class SinglePostcodeService
    {
        #region Properties
        public CallManager CallManager { get; }
        //NewtonSoft object representing the JSON response
        public JObject ResponseContent { get; set; }
        public SinglePostcodeDTO SinglePostcodeDTO { get; set; }

        //the postcode used in this API request
        public string PostcodeSelected { get; set; }

        public string PostcodeResponse { get; set; }
        #endregion

        // constructor - creates restClient object
        public SinglePostcodeService()
        {
            CallManager = new CallManager();
            SinglePostcodeDTO = new SinglePostcodeDTO();
        }

        public async Task MakeRequestAsync(string postcode)
        {
            PostcodeSelected = postcode;

            //make request
           PostcodeResponse = await CallManager.MakeSinglePostcodeRequest(postcode);

            // parse Json into a JObject
            ResponseContent = JObject.Parse(PostcodeResponse);

            // parse response body into an object tree
            SinglePostcodeDTO.DeserializeResponse(PostcodeResponse);
        }

        public int CodesCount()
        {
            return ResponseContent["result"]["codes"].Count();
        }
    }
}
