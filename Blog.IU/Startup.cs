 using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.Hosting;
using Blog.Core.Infastructure;
using Blog.Core.Repository;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.IU.SettingClass;

namespace Blog.IU
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRazorPages()
      .AddRazorRuntimeCompilation();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".TanvirArjel.Session";
                options.IdleTimeout = TimeSpan.FromDays(1);


            });
            #region Dependencylerimizi enjekte etti?imiz sat?rlar  

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagsRepository, TagsRepository>();
            services.AddScoped<IPublicationRepository, PublicationRepository>();


            #endregion

            #region appsettings.json içindeki verileri okumak
            services.Configure<BaseUrlSettings>(_configuration.GetSection("BaseUrlSetting"));



            #endregion
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Publication}/{action=AllPublication}/{id?}");
            });



        }
        // This method gets called by the runtime. Use this method to add services to the container.

    }
}
