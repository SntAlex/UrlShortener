using AlexGolikov.UrlShortener.Data.DB;
using AlexGolikov.UrlShortener.Data.Repositories;
using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;
using AlexGolikov.UrlShortener.Domain.Contracts.Services;
using AlexGolikov.UrlShortener.Services;
using AlexGolikov.UrlShortener.Services.Exceptions.Base;
using AlexGolikov.UrlShortener.WebApi.Configuration;
using AlexGolikov.UrlShortener.WebApi.Filters;
using AlexGolikov.UrlShortener.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Net;

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
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidateModelAttribute));
            });

            services.AddDbContext<UrlShortenerContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUrlShortenerService, UrlShortenerService>();

            services.AddCors();

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

            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
                    var result = new ErrorDetails(ex.Message, ex.HttpStatusCode);
                    await context.Response.WriteAsJsonAsync(result);
                }
                catch (Exception ex)
                {
                    var logger = LogManager.GetCurrentClassLogger();
                    logger.Error(ex, ex.Message);
                    var result = new ErrorDetails(exception.Message, (int)HttpStatusCode.InternalServerError);
                    await context.Response.WriteAsJsonAsync(result);
                }
            }));

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(
                options =>
                    options.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
