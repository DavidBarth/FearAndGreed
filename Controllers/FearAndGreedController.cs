using FearAndGreed.Data;
using FearAndGreed.Models;
using FearAndGreed.Service.FearAndGreed;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FearAndGreed.Controllers
{
    public class FearAndGreedController : Controller
    {
        string Baseurl = "https://api.alternative.me/fng/";
        private FearAndGreedContext _context;

        public FearAndGreedController(FearAndGreedContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                //Passing service base url  
                httpClient.BaseAddress = new Uri(Baseurl);

                httpClient.DefaultRequestHeaders.Clear();
                //Define request data format  
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource  
                HttpResponseMessage Res = await httpClient.GetAsync(string.Empty);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api
                    JObject result = JObject.Parse(response);

                    FearAndGreedModel model = FearAndGreedService.BuildViewModelInfo(result);
                    FearAndGreedService.SaveModel(model, _context);
                    var listOfModels = FearAndGreedService.GetAllModels(_context);
                    return View(listOfModels);
                }
                return new ViewResult();
            }
        }

        [HttpPost]
        public IActionResult Index(string daysToCountAverageFor)
        {
            //param maps to name attribute in view
            return new ViewResult();
        }
    }
}
