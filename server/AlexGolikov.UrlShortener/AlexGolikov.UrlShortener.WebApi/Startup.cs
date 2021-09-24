using System;
using System.Net;
using AlexGolikov.UrlShortener.Data.DB;
using AlexGolikov.UrlShortener.Data.Repositories;
using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;
using AlexGolikov.UrlShortener.Domain.Contracts.Services;
using AlexGolikov.UrlShortener.Services;
using AlexGolikov.UrlShortener.Services.Exceptions.Base;
using AlexGolikov.UrlShortener.WebApi.Configuration;
using AlexGolikov.UrlShortener.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AlexGolikov.UrlShortener.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddDbContext<UrlShortenerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUrlShortenerService, UrlShortenerService>();
            
            services.AddScoped(_ => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ShortUrlProfile());
                cfg.AddProfile(new OriginalUrlProfile());
            }).CreateMapper());

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "BrowserArticle API";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Alex Golikov",
                        Email = "alexgolikov5@mail.ru"
                    };
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                try
                {
                    throw exception;
                }
                catch (BaseException ex)
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = ex.HttpStatusCode;
                    var result = new ErrorDetails(ex.Message, ex.HttpStatusCode);
                    await context.Response.WriteAsJsonAsync(result);
                }
                catch (Exception)
                {
                    var result = new ErrorDetails(exception.Message, (int)HttpStatusCode.InternalServerError);
                    await context.Response.WriteAsJsonAsync(result);
                }
            }));

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
