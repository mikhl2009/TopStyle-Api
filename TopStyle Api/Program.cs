using Microsoft.EntityFrameworkCore;
using TopStyle_Api.Data;
using TopStyle_Api.Domain.Profiles;
using TopStyle_Api.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TopStyleDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TopStyleDbContext")));

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>{endpoints.MapControllers();});

app.UseSwagger();
app.UseSwaggerUI();


app.Run();
