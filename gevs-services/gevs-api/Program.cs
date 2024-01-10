using gevs_api.Core;
using gevs_api.Data;
using gevs_api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gevs_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<GevsDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add services to the container.
            
            builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
            builder.Services.AddScoped<IPartyRepository, PartyRepository>();
            builder.Services.AddScoped<IConstituencyRepository, ConstituencyRepository>();
            
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();
            
            // migrate database if it doesnt exist
            try
            {
                DbInitializer.InitDb(app);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            app.Run();
        }
    }
}
