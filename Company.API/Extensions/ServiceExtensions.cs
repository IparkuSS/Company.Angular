using Company.BLL.Services;
using Company.BLL.Services.Contracts;
using Company.DAL.RepositoryModels;
using Company.DAL.RepositoryModels.Contracts;

namespace Company.API.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });


        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();
          //  services.AddTransient<IRepositoryBase<>, RepositoryBase<>>();


        }



        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ICompanyServices, CompanyServices>();

           // services.AddAutoMapper();
        }
    }
}
