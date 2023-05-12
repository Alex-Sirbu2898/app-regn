using MediatR;
using Microsoft.EntityFrameworkCore;
using Regnology.Data;
using System.Reflection;

namespace Regnology
{
    public class Startup
    {
        private static readonly Assembly _currentAssembly = typeof(Startup).Assembly;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(@"Server=localhost;Database=Regnology;Trusted_Connection=True;Encrypt=False;")); 
            services.AddAutoMapper(_currentAssembly);
            services.AddAuthentication();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(typeof(Startup));
            services.AddTransient<IQueryService<Employee>, EmployeeQueryService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
