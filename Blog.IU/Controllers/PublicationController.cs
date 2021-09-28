using Blog.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Blog.IU.Controllers
{
    public class PublicationController : Controller
    {
        string Baseurl = "https://localhost:44303/api/Publication/";




        public IActionResult AllPublication()
        {
            List<Publication> publication;
            string html = string.Empty;
            string url = Baseurl;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }


            publication = JsonConvert.DeserializeObject<List<Publication>>(html);
            return View(publication);

        }



    }
}
