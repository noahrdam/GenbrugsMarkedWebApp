using ServerAPI.Repositories.Interfaces;
using ServerAPI.Repositories;

namespace ServerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<IPurchaseRepository, PurchaseRepository>();
            builder.Services.AddSingleton<IAdsRepository, AdsRepository>();
            builder.Services.AddSingleton<ILoginRepository, LoginRepository>();
            builder.Services.AddSingleton<IMyprofileRepository, MyprofileRepository>();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}