using FearAndGreed.Service.FearAndGreed;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Testing
{
    public class FearAndGreedServiceTest
    {
        private JObject result;

        [SetUp]
        public void Setup()
        {
            result = JObject.Parse("{\"name\":\"Fear and Greed Index\",\"data\":[{\"value\":\"0\",\"value_classification\":\"test\",\"timestamp\":\"0\",\"time_until_update\":\"0\"}],\"metadata\":{\"error\":null}}");
        }

        [Test]
        public void TestBuildFearAndGreedModelViewModelInfo()
        {
            var model = FearAndGreedService.BuildViewModelInfo(result);
            Assert.True(model.IndexClassification.Equals("test"));
            string date = model.IndexDate.Day.ToString() + "/" + model.IndexDate.Month.ToString() + "/" + model.IndexDate.Year.ToString();
            Assert.True(date.Equals("1/1/1970"));
            Assert.True(model.IndexNextUpdate.Hour.ToString().Equals("0"));
        }
    }
}