using gevs_api.Core;
using gevs_api.Data;
using gevs_api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            builder.Services.AddScoped<IElectionResultRepository, ElectionResultRepository>();
            builder.Services.AddScoped<IElectionRepository, ElectionRepository>();
            builder.Services.AddScoped<IVoteHistoryRepository, VoteHistoryRepository>();

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = builder.Configuration["IdentityServiceUrl"];
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters.ValidateAudience = false;
                    options.TokenValidationParameters.NameClaimType = "username";
                });

            var app = builder.Build();

            app.UseCors(cors =>
            {
                cors.AllowAnyOrigin();
                cors.AllowAnyHeader();
                cors.AllowAnyMethod();
            });

            // Configure the HTTP request pipeline.

            app.UseAuthentication();

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
