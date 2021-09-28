using Blog.Data.Models;
using Blog.IU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Blog.IU.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Hosted web API REST Service base url
        string Baseurl = "https://localhost:44303/api/Category";


        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult Index()
        {
            List<Category> customers;
            //customers= SearchCustomers("");

            string html = string.Empty;
            string url =Baseurl;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }


            customers = JsonConvert.DeserializeObject<List<Category>>(html);
            return View(customers);
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            List<Category> customers = SearchCustomers(name);
            return View(customers);
        }

        private List<Category> SearchCustomers(string name)
        {
            //string apiUrl = "http://localhost:26404/api/CustomerAPI";
            var input = new
            {
                Name = name,
            };
            //string inputJson = (new JavaScriptSerializer()).Serialize(input);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string data = "Get";

            string json = client.UploadString(Baseurl,data);
            List<Category> customers = JsonConvert.DeserializeObject<List<Category>>(json);
            return customers;
        }
        //public async Task<ActionResult> Index()
        //{
        //    List<Category> CategInfo = new List<Category>();
        //    using (var client = new HttpClient())
        //    {
        //        //Passing service base url
        //        client.BaseAddress = new Uri(Baseurl);
        //        client.DefaultRequestHeaders.Clear();
        //        //Define request data format
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //Sending request to find web api REST service resource GetAllEmployees using HttpClient
        //        HttpResponseMessage Res = await client.GetAsync("api/Category");
        //        //Checking the response is successful or not which is sent using HttpClient
        //        if (Res.IsSuccessStatusCode)
        //        {
        //            //Storing the response details recieved from web api
        //            var EmpResponse = Res.Content.ReadAsStringAsync().Result;
        //            //Deserializing the response recieved from web api and storing into the Employee list
        //            CategInfo = JsonConvert.DeserializeObject<List<Category>>(EmpResponse);
        //        }
        //        //returning the employee list to view
        //        return View(CategInfo);
        //    }
        //}

    }
}
