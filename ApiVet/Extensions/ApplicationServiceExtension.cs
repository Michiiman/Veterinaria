using Application.UnitOfWork;
using Domain.Interfaces;
using ApiVet.Helpers;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;



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
    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            //Para una versión 
            //options.ApiVersionReader = new QueryStringApiVersionReader("ver");

            //Para ambas versiones
            options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("ver"),
                new HeaderApiVersionReader ("X-Version")
            );
        });
    }
}
