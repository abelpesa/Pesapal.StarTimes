using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StarTimes.BLL.Implementation;
using StarTimes.BLL.Interfaces;
using StarTimes.DAL.Database;
using StarTimes.DAL.Interfaces;
using StarTimes.DAL.Repositories;

namespace Pesapal.StarTimes
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
            services.AddDbContext<StarTimesContext>(s => s.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificationDetailService, NotificationDetailService>();
            services.AddScoped<ISubscriberPaymentInfoService, SubscriberPaymentInfoService>();
            services.AddScoped<ISubscriberTransactionDetailService, SubscriberTransactionDetailService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                                   name: "default",
                                   pattern: "api/{controller=Home}/{action=Index}/{id?}"
                                   );
            });
        }
    }
}
