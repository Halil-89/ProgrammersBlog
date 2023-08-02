using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.AutoMapper.Profiles;
using ProgrammersBlog.Mvc.Filters;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Mvc.Helpers.Concrete;
using ProgrammersBlog.Services.AutoMapper.Profiles;
using ProgrammersBlog.Services.Extensions;
using System.Configuration;
using System.Text.Json.Serialization;

//var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();//.GetCurrentClassLogger();
//logger.Debug("init main");
var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
logger.Debug("init main");


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

//builder.Services.AddTransient<MvcExceptionFilter>();


//var builder = WebApplication.CreateBuilder(args);



var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new CategoryProfile());
    cfg.AddProfile(new ArticleProfile());
    cfg.AddProfile(new UserProfile());
    cfg.AddProfile(new ViewModelsProfile());
    cfg.AddProfile(new CommentProfile());

});



builder.Services.AddControllersWithViews(options =>
{
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value=>"bu alan boþ geçilmemelidir.");
    options.Filters.Add<MvcExceptionFilter>();
}).AddRazorRuntimeCompilation().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
builder.Services.AddSession();

var mapper = config.CreateMapper();

IConfiguration configuration = builder.Configuration;

builder.Services.Configure<AboutUsPageInfo>(configuration.GetSection("AboutUsPageInfo"));
builder.Services.Configure<WebsiteInfo>(configuration.GetSection("WebsiteInfo"));
var connectionString = configuration.GetConnectionString("LocalDB");


builder.Services.AddSingleton(mapper);
builder.Services.LoadMyServices(connectionString);
builder.Services.AddScoped<IImageHelper, ImageHelper>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Admin/Auth/Login");
    options.LogoutPath = new PathString("/Admin/Auth/Logout");
    options.Cookie = new CookieBuilder
    {
        Name = "ProgrammersBlog",
        HttpOnly=true,
        SameSite=SameSiteMode.Strict,
        SecurePolicy=CookieSecurePolicy.SameAsRequest//herzaman Always olmalý
    };
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
    options.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
});

//builder.Services.AddControllersWithViews(opt => opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddNToastNotifyToastr();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
}).AddNToastNotifyToastr(); 
builder.Services.AddControllers(opt => opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
     .AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseNToastNotify();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
       name: "Admin",
       areaName: "Admin",
       pattern: "Admin/{controller=Home}/{action=Index}/{id?}");


    endpoints.MapDefaultControllerRoute();
});


//app.MapRazorPages();

app.Run();


