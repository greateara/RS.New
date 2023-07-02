using Application.Core;
using Application.AppAgama;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameWorkCore.UseSqlLite;
using Persistence;
using Infrastructure.Security;
using Application.Interfaces;

namespace API.Extensions
{
    public static class AppServiceExtenstions
    {
        public static IServiceCollection AddAppServiceExtensions(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            // services.AddDbContext<AppDbContext>(opt =>
            // {
            //     opt.UseSqlLite(GetConnectionString("DefaultConnection"));
            //     // opt.UseSqlServer(config.GetConnectionString("DefaultConnection2"));
            // });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });

            services.AddMediatR(typeof(List.Handler));
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<Create>();
            services.AddHttpContextAccessor();
            services.AddScoped<IUserAccessor, UserAccessor>();
            return services;
        }
    }
}