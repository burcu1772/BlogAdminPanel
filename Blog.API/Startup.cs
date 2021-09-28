using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blog.Core.Infastructure;
using Blog.Core.Repository;
using System;
using Blog.Core.AutoMapperMapping;

namespace Blog.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Startup(IConfiguration _configuration, IWebHostEnvironment env)
        {
            Configuration = _configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


            Configuration = builder.Build();


        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen();
            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

            #region AutomapperConfig

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }
           );
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);


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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c=> { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"); }
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
