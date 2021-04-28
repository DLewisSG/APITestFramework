using API_App.PostcodeIOService;
using Newtonsoft.Json;

namespace API_App.PostcodesIOService
{
    public class SingleOutcodeDTO
    {
        public SingleOutcodeResponse SingleOutcodeResponse { get; set; }
        public void DeserializeResponse(string singleOutcodeResponse)
        {
            SingleOutcodeResponse = JsonConvert.DeserializeObject<SingleOutcodeResponse>(singleOutcodeResponse);
        }
    }
}
