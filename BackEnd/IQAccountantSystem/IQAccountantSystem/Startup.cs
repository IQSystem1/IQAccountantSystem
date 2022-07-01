using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Model;
using IQ.Accountant.System.Repositories.IRepository;
using IQ.Accountant.System.Repositories.Repository;
using IQ.Accountant.System.Services.IServices;
using IQ.Accountant.System.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IQAccountantSystem
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    ); 
            services.AddCors(options =>
            {
                options.AddPolicy(
                  name: "IQPolicy",
                  builder => {
                      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                  });
            });
            services.AddDbContext<IQAccountantSystemContext>(option => option.UseSqlServer(Configuration.GetConnectionString("IQAccountantSystem")));
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<ImageVideo>, Repository<ImageVideo>>();
            services.AddScoped<IRepository<ProductImageVideo>, Repository<ProductImageVideo>>();
            services.AddScoped<IRepository<Sale>, Repository<Sale>>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IImageVideoRepository, ImageVideoRepository>();
            services.AddScoped<IProductImageVideoRepository, ProductImageVideoRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleService, SaleService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("IQPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
