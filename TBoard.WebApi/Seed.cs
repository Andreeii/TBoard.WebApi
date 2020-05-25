using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBoard.Entities;
using TBoard.Entities.Auth;

namespace TBoard.WebApi
{
    public class Seed
    {
        public static async Task SeedRoles(TournamentContext context)
        {
            if (!context.Roles.Any())
            {
                var admin = new Role()
                {
                    Name = "admin",
                    NormalizedName = "ADMIN"
                };
                var user = new Role()
                {
                    Name = "user",
                    NormalizedName = "USER"
                };
                context.Roles.Add(admin);
                context.Roles.Add(user);
                await context.SaveChangesAsync();
            }
        }

    }
}
