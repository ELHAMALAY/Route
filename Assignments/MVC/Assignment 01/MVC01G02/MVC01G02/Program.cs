using MVC01G02.Middleware;

namespace MVC01G02
{
    public class Program
    {
        // Entry Point
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.


            // Used To Add Built-in MVC Services Inside The Containers

            // DI Container
            builder.Services.AddControllersWithViews();

            // Used To Add Built-in Web Apis Servies Inside The Containers
            //builder.Services.AddControllers();


            // Used To Add Built-in Razor Pages Servies Inside The Containers
            //builder.Services.AddRazorPages();




            var app = builder.Build();

            // Add Middlewares


            // Custom Middlewares

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Hello"); 
            //    await next.Invoke(context);
            //    Console.WriteLine("Bye Bye");
            //});

            app.UseMiddleware<RequestTimeMiddleware>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.MapStaticAssets();


            //app.MapControllerRoute(
            //    name: "Default2",
            //    pattern:"shop/{controller}/{action}"
            //    );

            // Convention Routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id:int:range(10,20)?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
