using System;
using Hotel_Reservation_MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Hotel_Reservation_MVC.Areas.Identity.IdentityHostingStartup))]
namespace Hotel_Reservation_MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Hotel_Reservation_MVCIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Hotel_Reservation_MVCIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Hotel_Reservation_MVCIdentityContext>();
            });
        }
    }
}