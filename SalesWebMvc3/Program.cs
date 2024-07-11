using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc3.Data;
using SalesWebMvc3.Services;
using System.Globalization;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<SalesWebMvc3Context>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("SalesWebMvc3Context") ?? throw new InvalidOperationException("Connection string 'SalesWebMvc3Context' not found.")));

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<SellerService>();
        builder.Services.AddScoped<DepartmentService>();
        builder.Services.AddScoped<SalesRecordService>();

        var enUS = new CultureInfo("en-US");
        var localizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(enUS),
            SupportedCultures = new List<CultureInfo> { enUS },
            SupportedUICultures = new List<CultureInfo> { enUS }
        };
        var app = builder.Build();
        app.UseRequestLocalization(localizationOptions);
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}