using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kulinarna.Repository;
using Kulinarna.Repository.Interfaces;
using Kulinarna.Repository.Repositories;
using Kulinarna.Services.Interfaces;
using Kulinarna.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Kulinarna.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(); 
            services.AddDbContext<DataContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RecipeDataBase;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("Kulinarna.Repository")));
            services.AddMvc();
            services.AddAutoMapper();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeRatingRepository, RecipeRatingRepository>();
            services.AddScoped<IRecipeRatingService, RecipeRatingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());

            app.UseMvc();

       

        }
    }
}
