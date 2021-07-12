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
            DbInitializer.Initialize(_context);
        }
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource  
                HttpResponseMessage Res = await client.GetAsync(string.Empty);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api
                    JObject result = JObject.Parse(response);

                    FearAndGreedModel model = FearAndGreedService.BuildViewModelInfo(result);

                    //NEXT STEP FACTOR THIS OUT
                    _context.Add(model);
                    _context.SaveChanges();

                    return View(model);
                }
                return new ViewResult();
            }
        }
    }
}
