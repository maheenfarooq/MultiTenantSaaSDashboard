using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.API.Data;

namespace MultiTenant.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // SQLite DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=multitenant.db"));

            // IdentityServer
            services.AddIdentityServer()
                    .AddInMemoryClients(Config.Clients)
                    .AddInMemoryApiScopes(Config.ApiScopes)
                    .AddDeveloperSigningCredential();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseIdentityServer();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
