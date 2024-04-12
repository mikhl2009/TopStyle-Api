﻿using TopStyle_Api.Core.Interfaces;
using TopStyle_Api.Core.Services;
using TopStyle_Api.Data.Interfaces;
using TopStyle_Api.Data.Repos;

namespace TopStyle_Api.Extentions
{
    public static class ServicesExtentions 
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            //services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ITokenService, TokenService>();
            //services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
                // Other logging providers as needed
            });

        }
    }
}
