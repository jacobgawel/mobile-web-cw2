using gevs_api.Data;
using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Core;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        var retry = 10;

        while (retry > 0)
        {
            try
            {
                using var scope = app.Services.CreateScope();
                var dbContext = scope.ServiceProvider.GetService<GevsDbContext>();
                dbContext?.Database.Migrate();
                dbContext?.Database.EnsureCreated();
                break;
            }
            catch (Npgsql.NpgsqlException e)
            {
                retry -= 1;
                Console.WriteLine("Postgres is not ready. Attempting to connect in 5 secs. Retries left: " + retry);
                Thread.Sleep(5000);
            }
        }
    }
}