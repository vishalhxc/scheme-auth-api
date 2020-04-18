using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchemeAuthApi.Data;
using SchemeAuthApi.Error;
using SchemeAuthApi.User.Entity;
using SchemeAuthApi.User.Repository;
using SchemeAuthApi.User.Service;

namespace SchemeAuthApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddLogging();
            services.AddDbContext<AuthDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("SchemeAuthConnectionString")));
            services.AddEntityFrameworkNpgsql();
            services.AddIdentity<UserEntity, UserRoleEntity>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context => { await ErrorHandler.HandleHttpExceptions(context); });
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}