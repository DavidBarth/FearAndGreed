using FearAndGreed.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FearAndGreed.Controllers
{
    public class FearAndGreedController : Controller
    {
        string Baseurl = "https://api.alternative.me/fng/";
        public async Task<ActionResult> Index()
        {
            List<FearAndGreedModel> modelInfo = new List<FearAndGreedModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Employee/GetAllEmployees");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    modelInfo = JsonConvert.DeserializeObject<List<FearAndGreedModel>>(response);

                }
                //returning the employee list to view  
                return View(modelInfo);
            }
        }
    }
}
