using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Logic;
using BlazorBootstrap;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductManagementDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IProductLogic, ProductLogic>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddBlazorBootstrap();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
