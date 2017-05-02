using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;

namespace AspNetCoreWebApi
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Dornheck41.Server.Daemon.Startup"/> class.
        /// </summary>
        /// <param name="env">Env.</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Asp.Net Core Web Api Lib Test!",
                    Description = "Try to find the correct lib in the lib hell!",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Andreas Klapperich",
                        Email = "andreas@klapperich.de",
                        Url = "http://klapperich.de"
                    },
                    License = new License
                    {
                        Name = "License Name",
                        Url = "License Url"
                    }
                });
                var xmlPath = Path.ChangeExtension(Environment.GetCommandLineArgs()[0], ".xml");
                options.IncludeXmlComments(xmlPath);

            });
            // Add framework services.
            services.AddMvc();
        }

        /// <summary>
        /// Configure the specified app, env and loggerFactory.
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <returns>The configure.</returns>
        /// <param name="app">App.</param>
        /// <param name="env">Env.</param>
        /// <param name="loggerFactory">Logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseSwagger();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSwaggerUi();
        }
    }
}

