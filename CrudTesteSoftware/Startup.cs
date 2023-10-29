using CrudTesteSoftware.Domain.Interfaces.Repositories;
using CrudTesteSoftware.Domain.Interfaces.Services;
using CrudTesteSoftware.Domain.Services.Address;
using CrudTesteSoftware.Infrastructure.Data.Mysql.Repositories;

namespace CrudTesteSoftware.Api
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
            services.AddCors(option =>
            {
                option.AddPolicy(name: "_myOrigins",
                                   policy =>
                                   {
                                       policy.WithOrigins("*");
                                   });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "People",
                    Version = "v1"
                });
            });
            services.AddControllers();

            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddSingleton<IAddressService, AddressService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "People v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("_myOrigins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
