using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TopStyle_Api.Data;
using TopStyle_Api.Domain.Identity;
using TopStyle_Api.Domain.Profiles;
using TopStyle_Api.Extentions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TopStyleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TopStyleDbContext")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<TopStyleDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(typeof(Profile));
builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen( // add authentication to swagger
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
    });
builder.Services.AddJwtExtension(builder.Configuration);

var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;  // Sätter Swagger på rot-url:en
});




app.UseEndpoints(endpoints =>{endpoints.MapControllers();});

app.Run();
