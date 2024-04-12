using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtExtention(builder.Configuration);

var app = builder.Build();

app.UseJwtExtention();

app.UseRouting();
app.UseEndpoints(endpoints =>{endpoints.MapControllers();});

app.UseSwagger();
app.UseSwaggerUI();


app.Run();
