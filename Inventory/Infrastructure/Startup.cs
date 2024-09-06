using Inventory.AppCode;
using Inventory.Infrastructure.ServicesInstaller;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;
using System;
using Inventory.Infrastructure.Options;
using Common_Helper.CommonHelper;
using Inventory.Repository.DBContext;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Inventory.Extensions;
using Microsoft.AspNetCore.Builder;

namespace Inventory.Infrastructure
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly ISwaggerProviderOptions? swaggerOptions;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AuditLog.Configuration = Configuration;
            this.swaggerOptions = this.Configuration.GetSection("SwaggerOptions").Get<SwaggerProviderOptions>();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface
                && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installers.ForEach(installer => installer.InstallerServices(services, Configuration));

            _ = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:secretKey"]!))
                };
            });

            services.AddMvc();

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = swaggerOptions?.Title, Version = swaggerOptions?.Version });
                //Next 2 lines will show user parameter value in swagger 
                //var filePath = Path.Combine(System.AppContext.BaseDirectory, "example.xml");
                //c.IncludeXmlComments(filePath);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                          },
                          Array.Empty<string>()
                    }
                });


            });
            services.AddDbContext<ImsDbContext>(opt => { opt.EnableSensitiveDataLogging(); });
            //services.AddAndConfigSwagger();
            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.AddControllers();
            services.AddEndpointsApiExplorer();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            UseExceptionHandler(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            // Setting up the Services for ConnectionHelper Class

            AppServicesHelper.Services = app.ApplicationServices;

            SetupSwagger(app);

            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();


        }
        private static void UseExceptionHandler(IApplicationBuilder app)
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = Text.Plain;
                    await context.Response.WriteAsync("An exception was thrown.");
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                    {
                        await context.Response.WriteAsync("The file was not found.");
                    }
                    if (exceptionHandlerPathFeature?.Path == "/")
                    {
                        await context.Response.WriteAsync("Page: Home.");
                    }
                });
            });
        }
        private void SetupSwagger(IApplicationBuilder app)
        {
            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerOptions?.JsonRoute;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerOptions?.UIEndpoint, swaggerOptions?.Description);
            });
        }
    }
}
