
using bacit_dotnet.MVC.DataAccess;
using bacit_dotnet.MVC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;

public class Program
{

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<ISqlConnector, SqlConnector>();
        
        builder.Services.AddDbContext<DataContext>(options => {
            options.UseMySql(builder.Configuration.GetConnectionString("MariaDb"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDb")));
        });
        //builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
        builder.Services.AddScoped<IUserRepository, EFUserRepository>();
        //builder.Services.AddSingleton<IUserRepository, SqlUserRepository>();
        //builder.Services.AddSingleton<IUserRepository, DapperUserRepository>();

        var app = builder.Build();
         
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        { 
            app.UseExceptionHandler("/Home/Error"); 
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        //app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapControllers();   


        app.Run();
    }
}