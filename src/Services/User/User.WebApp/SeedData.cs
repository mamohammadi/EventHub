using System.Security.Claims;
using IdentityModel;
using User.WebApp.Data;
using User.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace User.WebApp;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app, string adminPassword)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var admin = userMgr.FindByNameAsync("admin").Result;
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin",
                    IsAdmin = true,
                    Email = "admin@email.com",
                    EmailConfirmed = true,
                };
                var result = userMgr.CreateAsync(admin, adminPassword).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(admin, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Admin"),
                            new Claim(JwtClaimTypes.GivenName, "Admin"),
                            new Claim(JwtClaimTypes.FamilyName, "Admin"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("admin created");
            }
        }
    }
}
