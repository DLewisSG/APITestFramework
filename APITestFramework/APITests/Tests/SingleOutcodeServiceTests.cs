using NUnit.Framework;
using System.Threading.Tasks;
using API_App.PostcodeIOService;

namespace APITests.Tests
{
    public class WhenTheSingleOutcodeServiceIsCalledWithValidOutcode
    {
        SingleOutcodeService _singleOutcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _singleOutcodeService = new SingleOutcodeService();
            await _singleOutcodeService.MakeRequestAsync("EC2Y");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_singleOutcodeService.ResponseContentOC["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_singleOutcodeService.SingleOutcodeDTO.SingleOutcodeResponse.status, Is.EqualTo(200));
        }

        [Test]
        public void LatitudeIs_Correct()
        {
            Assert.That(_singleOutcodeService.SingleOutcodeDTO.SingleOutcodeResponse.result.latitude, Is.EqualTo(51.5194158924731));
        }

        [Test]
        public void NorthingsAre_Correct()
        {
            Assert.That(_singleOutcodeService.SingleOutcodeDTO.SingleOutcodeResponse.result.northings, Is.EqualTo(181778));
        }


        [Test]
        public void Country_IsEngland()
        {
            Assert.That(_singleOutcodeService.SingleOutcodeDTO.SingleOutcodeResponse.result.country, Does.Contain("England"));
        }

        [Test]
        public void CorrectOutcodeIsReturned()
        {
            var result = _singleOutcodeService.ResponseContentOC["result"]["outcode"].ToString();
            Assert.That(result, Is.EqualTo("EC2Y"));
        }
    }
}
