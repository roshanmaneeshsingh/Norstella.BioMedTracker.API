using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using BioMedTracker.Api.Models;
using BioMedTracker.Service.Interfaces;
using BioMedTracker.Repository;
using BioMedTracker.Repository.Interfaces;
using BioMedTracker.Services;
using BioMedTracker.Shared.Models;
using BioMedTracker.Repository;

namespace BioMedTracker.Api
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
            services.AddOptions();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                        builder
                            .WithOrigins(Configuration.GetSection("appsettings:origins").Get<string[]>())
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                );
            });

            services.AddControllers();

            /*
            services.AddControllers().AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });*/

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton(Configuration);

            services.AddDbContext<BioMedTrackerDbContext>(options => options.UseSqlServer(Configuration["appsettings:connection:BiomedTrackerDbContext"]));
            services.AddHealthChecks().AddDbContextCheck<BioMedTrackerDbContext>();
            services.AddScoped<IBioMedTrackerRepository, BioMedTrackerRepository>();
            services.AddScoped<IBioMedTrackerService, BioMedTrackerService>();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BioMed Service Api",
                    Description = "Biomed Api",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "support admin",
                        Url = new Uri("https://example.com/license"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License Agreement",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new string[] { }
                    }
                });
                swagger.MapType(typeof(IFormFile), () => new OpenApiSchema() { Type = "file", Format = "binary" });
            });


            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDeveloperExceptionPage();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/Health", new HealthCheckOptions()
                {
                    ResponseWriter = async (context, report) =>
                    {
                        context.Response.ContentType = "application/json";
                        var response = new HealthCheckResponse()
                        {
                            Status = report.Status.ToString(),
                            Checks = report.Entries.Select(x => new HealthCheck()
                            {
                                Component = x.Key,
                                Status = x.Value.Status.ToString(),
                                Description = x.Value.Description
                            }),
                            Duration = report.TotalDuration
                        };
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    }
                }).WithMetadata(new AllowAnonymousAttribute());
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Client Configuration API v1");
            });
        }
    }
}
