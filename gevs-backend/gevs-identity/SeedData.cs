using gevs_identity.Data;
using gevs_identity.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Claims;

namespace gevs_identity
{
    public class SeedData
    {
        public static void EnsureSeedData(WebApplication app)
        {
            using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            // gets the asp net usermgr service, this helps to add users to the database
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // if there are any users in the database, exit the function
            if (userMgr.Users.Any()) return;

            // checks to see if the admin exists
            var admin = userMgr.FindByNameAsync("admin").Result;

            // potentially seeded users should have:
            // VoterId*
            // DoB* 
            // Full Name*
            // Password*
            // Contituency*
            // Unique Voter Code (UVC)*

            // create the admin user
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "election@shangrila.gov.sr",
                };
                var result = userMgr.CreateAsync(admin, "shangrila2024$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(admin, new Claim[]{
                                new Claim(JwtClaimTypes.Name, "Admin"),
                                new Claim(JwtClaimTypes.Role, "admin"),
                                new Claim(JwtClaimTypes.BirthDate, "2000-10-13"),
                                new Claim("UVC", "admin"),
                                new Claim("Constituency", "admin")
                            }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("admin created");
            }
            else
            {
                Log.Debug("admin already exists");
            }
        }
            
    }
}
