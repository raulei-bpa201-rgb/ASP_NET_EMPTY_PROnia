using Microsoft.EntityFrameworkCore;
using WebApplicationTASK14.DAL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplicationTASK14
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(ops =>
                ops.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
            );
            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute
            (
                name:"default",
                pattern:"{controller=Home}/{action=Index}"
            );

            app.Run();
        }
    }
}
