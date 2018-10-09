using Extensao.Infra.Data.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Extensao.Services.Api.Configurations;
using Extensao.Shared;

namespace Extensao.Services.Api
{
    public class Startup
    {
        private IHostingEnvironment _env;
        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddResponseCompression();

            // Registrar todos os DI
            services.AddDIConfiguration();

            // Configurações do Swagger
            services.AddSwaggerConfig();

            if (_env.IsProduction())
            {
                //Microsoft SQL Server
                Settings.ConnectionString = Configuration.GetConnectionString("Production");

                //MongoDB
                Settings.MongoDBConnectionString = Configuration.GetSection("MongoDBConnectionStrings")
                    .GetSection("Production").GetSection("ConnectionString").Value;
                Settings.MongoDBDataBase = Configuration.GetSection("MongoDBConnectionStrings")
                    .GetSection("Production").GetSection("DataBase").Value;
            }
            else
            {
                //Microsoft SQL Server
                Settings.ConnectionString = Configuration.GetConnectionString("Develop");

                //MongoDB
                Settings.MongoDBConnectionString = Configuration.GetSection("MongoDBConnectionStrings")
                    .GetSection("Develop").GetSection("ConnectionString").Value;
                Settings.MongoDBDataBase = Configuration.GetSection("MongoDBConnectionStrings")
                    .GetSection("Develop").GetSection("DataBase").Value;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            #region Configurações MVC

            //app.UseCors(c => c.WithOrigins(Configuration.GetSection("AllowedHosts").ToString()).AllowAnyHeader().AllowAnyMethod());
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();

            #endregion

            app.UseResponseCompression();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Extensão - V1");
            });
        }
    }
}
