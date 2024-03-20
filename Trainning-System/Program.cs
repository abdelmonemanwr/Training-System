using Microsoft.EntityFrameworkCore;
using Trainning_System.Models;
using Trainning_System.Repository;

namespace Trainning_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Built in Services not registered
            builder.Services.AddDbContext<TrainningSystemContext>(options =>
            {   
                // same line in OnConfiguring function in program.cs
                //options.UseSqlServer("Data Source=.;Initial Catalog=TrainningSystemContext;Integrated Security=True;Encrypt=False;");
                options.UseSqlServer(builder.Configuration.GetConnectionString("trainning_system"));
            });


            // Add services to the IOC container.
            builder.Services.AddControllersWithViews();
			builder.Services.AddSession(options => {  // // session services
				options.IdleTimeout = TimeSpan.FromMinutes(30); // options
			});

            // custom services : not in framework neither registered 
            // don't create but inject (ask)
            builder.Services.AddScoped<ICourseResultRepository, CourseResultRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();

			var app = builder.Build();

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
			app.UseSession(); // session mw
			app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
