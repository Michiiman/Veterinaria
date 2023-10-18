using System.Text;
using Application.UnitOfWork;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;


namespace ApiVet.Extensions;

    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()    //WithOrigins("https://domain.com")
                        .AllowAnyMethod()       //WithMethods("GET","POST)
                        .AllowAnyHeader());     //WithHeaders("accept","content-type")
            });

    public static void AddAplicacionServices(this IServiceCollection services)
    {
        //services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<User>>();
        //services.AddScoped<IUserService,UserService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    
    }
    }
