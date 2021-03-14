using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Persistence.EF;
using SuperMarket.Persistence.EF.GoodCategories;
using SuperMarket.Persistence.EF.GoodEntries;
using SuperMarket.Persistence.EF.Goods;
using SuperMarket.Persistence.EF.SalesFactors;
using SuperMarket.Services.GoodCategories;
using SuperMarket.Services.GoodCategories.Contracts;
using SuperMarket.Services.GoodEntries;
using SuperMarket.Services.GoodEntries.Contracts;
using SuperMarket.Services.Goods;
using SuperMarket.Services.Goods.Contracts;
using SuperMarket.Services.SalesFactors;
using SuperMarket.Services.SalesFactors.Contracts;

namespace SuperMarket.RestApi
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
            services.AddControllers();
            services.AddScoped<EFDataContext>();
            services.AddScoped<UnitOfWork, EFUnitOfWork>();

            services.AddScoped<GoodService, GoodAppService>();
            services.AddScoped<GoodRepository, EFGoodRepository>();

            services.AddScoped<GoodCategoryService, GoodCategoryAppService>();
            services.AddScoped<GoodCategoryRepository, EFGoodCategoryRepository>();

            services.AddScoped<GoodEntryService, GoodEntryAppService>();
            services.AddScoped<GoodEntryRepository, EFGoodEntryRepository>();

            services.AddScoped<SaleFactorService, SaleFactorAppService>();
            services.AddScoped<SaleFactorRepository, EFSaleFactorRepository>();


            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
