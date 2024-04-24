using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerAPI.Repositories;
using ServerAPI.Repositories.Interfaces;

namespace ServerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<IPurchaseRepository, PurchaseRepository>();
            //builder.Services.AddSingleton<IAdsRepository, AdsRepository>();
            builder.Services.AddSingleton<ILoginRepository, LoginRepository>();
            builder.Services.AddSingleton<IMyprofileRepository, MyprofileRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("policy",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                      policy.AllowAnyMethod();
                                      policy.AllowAnyHeader();
                                  });
            });

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("policy");


            app.MapControllers();

            app.Run();


        }

        
    }
}