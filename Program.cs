using Datamatiker2SemExam.Models;
using Datamatiker2SemExam.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Datamatiker2SemExam.Interfaces;

namespace Datamatiker2SemExam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<ITreatmentRepository, TreatmentRepository>();
            builder.Services.AddSingleton<IOpeningHourRepository, OpeningHourRepository>();
            builder.Services.AddSingleton<IBookingRepository, BookingRepository>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddDbContext<MassageDBContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); // Aktiv�r cookie-baseret Authentication
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
