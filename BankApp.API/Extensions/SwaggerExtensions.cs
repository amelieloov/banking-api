﻿using Microsoft.OpenApi.Models;

namespace BankApp.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerExtended(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Bank API",
                    Version = "v1"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Enter Bearer (JWT token)"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerExtended(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Bank API");
                options.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
