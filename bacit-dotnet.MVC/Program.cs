using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using bacit_dotnet.MVC.Models.ServiceForm;
using bacit_dotnet.MVC.Repositories;
using MySqlConnector;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using bacit_dotnet.MVC;

namespace bacit_dotnet.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.ConfigureKestrel(x => x.AddServerHeader = false);
        
            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            
            // Configure the database connection.
            builder.Services.AddScoped<IDbConnection>(_ =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                return new MySqlConnection(connectionString);
            });
            
            // Register your repository here.
            builder.Services.AddTransient<ServiceFormRepository>();

            builder.Services.AddTransient<CheckListRepository>();
            
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();
            
            app.MapControllerRoute(name: "default", pattern: "{controller=Login}/{action=Index}/{id?}");
            app.MapControllers();
            
            app.Run();

            builder.Services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });
            
            WebHost.CreateDefaultBuilder(args)
                .ConfigureKestrel(c => c.AddServerHeader = false)
                .UseStartup<Startup>()
                .Build();
        }
    }
}