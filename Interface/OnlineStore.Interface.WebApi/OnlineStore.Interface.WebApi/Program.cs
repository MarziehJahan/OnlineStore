using System.Net.NetworkInformation;
using FluentValidation.AspNetCore;
using Framework.Cache;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineStore.Application.Contract.Products;
using OnlineStore.Application.Products;
using OnlineStore.Config;
using OnlineStore.Domain.Products;
using OnlineStore.Domain.Services;
using OnlineStore.Infrastructure.Persistence.EF;
using OnlineStore.Infrastructure.Persistence.EF.Products;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;

var builder = WebApplication.CreateBuilder(args);
var onlineStoreConfig = builder.Configuration.GetSection("OnlineStoreConfig").Get<OnlineStoreConfig>();
// Add services to the container.

builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
    options.UseSqlServer(onlineStoreConfig.ConnectionString));
builder.Services.AddSingleton<CacheHelper<Product>>();
builder.Services.AddEntityFrameworkSqlServer();
builder.Services.AddScoped<DbContext>(x => x.GetService<OnlineStoreDbContext>());
builder.Services.Scan(scan => scan.FromAssemblyOf<ProductRepository>().AddClasses().AsMatchingInterface());
builder.Services.Scan(scan => scan.FromAssemblyOf<ProductCommandHandler>().AddClasses().AsMatchingInterface());
builder.Services.Scan(scan => scan.FromAssemblyOf<ProductQueryHandler>().AddClasses().AsMatchingInterface());
builder.Services.Scan(scan => scan.FromAssemblyOf<PurchaseDomainService>().AddClasses().AsMatchingInterface());
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ProductCommandHandler).Assembly));
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineStore Gateways RestApi", Version = "v1" });
    c.AddEnumsWithValuesFixFilters();
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseRouting();
app.UseSwagger();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineStore Gateways RestApi v1"));
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();

