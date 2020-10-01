using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TBoard.Entities;
using TBoard.Entities.Auth;
using TBoard.Infrastructure.Middlewares;
using TBoard.WebApi.Extensions;
using TBoard.WebApi.Repositories.Implementation;
using TBoard.WebApi.Repositories.Interfaces;
using TBoard.WebApi.Services.Implementation;
using TBoard.WebApi.Services.Interfaces;

namespace TBoard.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("fully permissive", configurePolicy => configurePolicy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200").AllowCredentials()); //localhost:4200 is the default port an angular runs in dev mode with ng serve
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<TournamentContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });

            services.AddIdentity<Player, Role>(options =>
            {
                options.Password.RequiredLength = 5;
            })
           .AddUserManager<UserManager<Player>>()
           .AddEntityFrameworkStores<TournamentContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
            })
           .AddGoogle("Google", options =>
           {
               options.CallbackPath = new PathString("/signin-google");
               options.ClientId = "435504687783-jmg1heitefdgadc0r9svk92itrgi4581.apps.googleusercontent.com";
               options.ClientSecret = "FrShXIuIIIutXB0x2tloU4Lf";
               options.Events = new OAuthEvents
               {
                   OnRemoteFailure = (RemoteFailureContext context) =>
                   {
                       context.Response.Redirect("/account/denied");
                       context.HandleResponse();
                       return Task.CompletedTask;
                   }
               };
           });
            var authOptions = services.ConfigureAuthOptions(Configuration);
            services.AddJwtAuthentication(authOptions);
            services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter());
                options.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters();

            //policy based role authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                     policy => policy.RequireRole("admin"));
                options.AddPolicy("RequireUserRole",
                   policy => policy.RequireRole("user"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ITournamentRepository), typeof(TournamentRepository));
            services.AddScoped(typeof(IPlayerRepository), typeof(PlayerRepository));
            services.AddTransient<ITournamentService, TournamentService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("TournamentOpenAPISpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "TournamentApi",
                        Version = "1"
                    });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware<ErrorHandlingMiddleware>();
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseRouting();

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("fully permissive");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
