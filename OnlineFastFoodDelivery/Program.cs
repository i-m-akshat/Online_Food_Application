using Microsoft.EntityFrameworkCore;
using OnlineFastFoodDelivery;
using Stripe;
using Models;
using BLL.Interfaces;
using BLL.Implementation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//registering the context accessor 
//email Configuration
var emailConfig = builder.Configuration.GetSection("MailSettings").Get<MailSettings>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<SendMailDAO, SendMailDao>();
builder.Services.AddScoped<OrderStatusDAO,OrderStatusDao>();
builder.Services.AddScoped<CartDAO, CartDao>();
builder.Services.AddScoped<CheckoutDAO, CheckoutDao>();
builder.Services.AddScoped<IBotAPIService, BotAPIService>();
builder.Services.AddScoped<IADProductService, ADProductService>();
//DBCONtext
var provider = builder.Services.BuildServiceProvider();
var config=provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<Online_Food_ApplicationContext>(item => item.UseSqlServer(config.GetConnectionString("con")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
