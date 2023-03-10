using BL;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BarterServerCheck
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.Configure<FormOptions>(o =>
            { 
                o.ValueLengthLimit = int.MaxValue; 
                o.MultipartBodyLengthLimit = int.MaxValue; 
                o.MemoryBufferThreshold = int.MaxValue;
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BarterServerCheck", Version = "v1" });
            });


            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IUserDAL, UserDAL>();
            services.AddScoped<IMessageBL, MessageBL>();
            services.AddScoped<IMessagesDAL, MessagesDAL>();
            services.AddScoped<IStarBL, StarBL>();
            services.AddScoped<IStarDAL, StarDAL>();
            services.AddScoped<IPublicationBL, PublicationBL>();
            services.AddScoped<IPublicationDAL, PublicationDAL>();
            services.AddScoped<IOpinionDAL, OpinionDAL>();
            services.AddScoped<IOpinionBL, OpinionBL>();
            services.AddScoped<ICategoryBL, CategoryBL>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<ICategoryUserBL, CategoryUserBL>();
            services.AddScoped<ICategoryUserDAL, CategoryUserDAL>();
            services.AddScoped<ICustomerInquiryBL, CustomerInquiryBL>();
            services.AddScoped<ICustomerInquiryDAL, CustomerInquiryDAL>();
            services.AddScoped<ICityBL, CityBL>();
            services.AddScoped<ICityDAL, CityDAL>();


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BarterServerCheck v1"));
            }
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:4200")
                       .WithMethods("GET", "POST","PUT","DELETE")
                       .WithHeaders("Content-Type");
            });

            app.UseStaticFiles(); 
            app.UseStaticFiles(new StaticFileOptions() 
            { 
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources") });



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyAllowSpecificOrigins");


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
