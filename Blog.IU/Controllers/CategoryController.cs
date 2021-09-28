using AutoMapper;
using Blog.Core.AutoMapper_DTO;
using Blog.Core.AutoMapperMapping;
using Blog.Core.Infastructure;
using Blog.Data.Models;
using Blog.IU.SettingClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blog.IU.Controllers
{
    public class CategoryController : Controller
    {
        //string Baseurl = "https://localhost:44303/api/Category/";
        private readonly ICategoryRepository _categoryRepository;
        //private readonly IMapper _mapper;
        private readonly IOptions<BaseUrlSettings> _baseUrlSettings;
        private readonly ReadBaseUrlSettings readbaseUrlSettings;
        string urlCategory;
        
        public CategoryController(
           IOptions<BaseUrlSettings> baseUrlSettings,
            ICategoryRepository categoryRepository
            //IMapper mapper
        )
        {
            _categoryRepository = categoryRepository;
            _baseUrlSettings = baseUrlSettings;
            readbaseUrlSettings = new ReadBaseUrlSettings(_baseUrlSettings);
            //_mapper = mapper;
             urlCategory = _baseUrlSettings.Value.ApiUrl + "Category";
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categoryList = new List<Category>();
           
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(urlCategory))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categoryList = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                }
            }
            return View(categoryList);
        }
        public  async Task<IActionResult> AllCategories()
        {
        
            List<Category> categoryList = new List<Category>();
            var url = _baseUrlSettings.Value.ApiUrl;
            var urlCategory = url + "Category";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(urlCategory))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categoryList = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                }
            }
            return View(categoryList);
        }
        public async Task<IActionResult> GetCategory(int Id)
        {

            Category category;
            var url = _baseUrlSettings.Value.ApiUrl;
            var urlCategory = url + "Category/"+Id;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(urlCategory))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<Category>(apiResponse);
                }
            }
            return View(category);
        }
        
        [HttpPost]
        public IActionResult CategoryCreate(Category category)
        {
            //Category category=categoryDTO.ToEntity(_mapper);
            using (var client =new HttpClient())
            {
                client.BaseAddress = new Uri(urlCategory);
                var postJob = client.PostAsJsonAsync<Category>("category", category);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllCategories", "Category");
                }

            }
            ModelState.AddModelError(string.Empty, "Server occured error .Please check with Admin");
            return View("AllCategories","Category");

        }
        [HttpPost]
        public IActionResult  UpdateCategory(Category category)
        {
            //Category category=categoryDTO.ToEntity(_mapper);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlCategory);
                var putJob = client.PutAsJsonAsync<Category>("category", category);
                putJob.Wait();

                var putResult = putJob.Result;
                if (putResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllCategories", "Category");
                }

            }
            ModelState.AddModelError(string.Empty, "Server occured error .Please check with Admin");
            return View("AllCategories", "Category");

        }



        public IActionResult Delete(int id)
        {

            using (var client = new HttpClient())
            {
                urlCategory = urlCategory + "/" + id;

                var deleteJob = client.DeleteAsync(urlCategory);
                deleteJob.Wait();

                var postResult = deleteJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllCategories", "Category");
                }

            }
            ModelState.AddModelError(string.Empty, "Server occured error .Please check with Admin");
            return View("AllCategories", "Category");

        }
    }
}
