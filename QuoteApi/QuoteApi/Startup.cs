using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quote.DataAccess;
using Quote.DataAccess.DbLayers;
using QuoteApi.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace QuoteApi
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
            services.AddCors(options => {
                options.AddDefaultPolicy(builder => {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Quote API", Version = "v1" });

            });
            services.AddMvcCore().AddApiExplorer();
            var connectionString = Configuration.GetConnectionString("DBConnection");
            services.AddDbContext<QuoteDbContext>(item => item.UseSqlServer(connectionString));
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddTransient<IDbInitializer, DbInitializer>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IDbInitializer databaseInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddFile("Logs/QuoteAPI-{Date}.txt");
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger(c =>
            {
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Quote API");
            });

            try
            {
                // Comment out for Migrations to work
                databaseInitializer.SeedAsync().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
