using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppFilm.Data;
using Microsoft.AspNetCore.Identity;
using FilmWed.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Azure;
using Album.Mail;
using AutoMapper;
using AppFilm.Net.Handler;
using AppFilm.Net.FileUpLoadService;
using AppFilm.Net.Controllers;
using AppFilm.Net.Data.Repos;
using AppFilm.Net.Areas.Identity.Data;
using AppFilm.Net.Data.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(AutoMapperHandler).Assembly);

// var autoMapper = new MapperConfiguration(item =>item.AddProfile(new AutoMapperHandler())); 
// IMapper mapper= autoMapper.CreateMapper();
// builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IFileUpLoadServices,LoaclFileUpLoadService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IPeopleService, PeopleService>();




var configuration = builder.Configuration;
builder.Services.AddAuthentication().AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
     
    });
builder.Services.AddDbContext<MvcMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Manager", policy => policy.RequireClaim("Manager"));
    options.AddPolicy("Employee", policy => policy.RequireClaim("Employee"));
    options.AddPolicy("User", policy => policy.RequireClaim("User"));
});
builder.Services.AddRazorPages();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;//có hữ số
    options.Password.RequireLowercase = false;//có chữ thường
    options.Password.RequireNonAlphanumeric = false;//ký tự đặc biệt 
    options.Password.RequireUppercase = false;//chữ in
    options.Password.RequiredLength = 6;//số ký tự tối thiểu
    options.Password.RequiredUniqueChars = 1;//số ký tự riêng biệt

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);//khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5;// lần nhập sai
    options.Lockout.AllowedForNewUsers = true;//

    // User settings.
    options.User.AllowedUserNameCharacters =//các ký tự đặc trên user
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true; // email là duy nhất
    options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false; 
    options.SignIn.RequireConfirmedAccount = false;
});

// builder.Services.ConfigureApplicationCookie(options =>
// {
//     // Cookie settings
//     options.Cookie.HttpOnly = true;
//     options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

//     options.LoginPath = "/Identity/Account/Login";
//     options.AccessDeniedPath = "/Identity/Account/AccessDenied";
//     options.SlidingExpiration = true;
// });
builder.Services.AddControllersWithViews();

builder.Services.AddOptions();
var mailsettings = builder.Configuration.GetSection("MailSettings");  // đọc config
builder.Services.Configure<MailSettings> (mailsettings); 
builder.Services.AddSingleton<IEmailSender, SendMailService>();

//builder.Services.AddAutoMapper();
var app = builder.Build();
app.UseCookiePolicy(new CookiePolicyOptions
    {
        MinimumSameSitePolicy = SameSiteMode.None,
        Secure = CookieSecurePolicy.Always,
    });
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Home}/{id?}");
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Movies}/{action=Home}/{id?}");
app.Run();
