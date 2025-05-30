using FMS_Front_End.Controllers;

namespace FMS_Front_End
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            builder.Services.AddSession(); // Add this line
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient<UserController>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:7187") // Your front-end port
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors("AllowFrontend");

            app.UseSession(); 
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
