﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace QuoteService
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup{
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services){
            
            services.AddDbContext<QuoteContext>(
                options => options.UseSqlServer(
                    Configuration["ConnectionString"]));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, QuoteContext context){
            context.Database.EnsureCreated();

            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}