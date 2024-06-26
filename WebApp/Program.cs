using Microsoft.EntityFrameworkCore;
using OnlineNewsWebApp.Core.IServices;
using OnlineNewsWebApp.Infrastructure.Database;
using OnlineNewsWebApp.Infrastructure.IRepos;
using OnlineNewsWebApp.Infrastructure.Mapper;
using OnlineNewsWebApp.Infrastructure.Repos;
using OnlineNewsWebApp.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using NLog;
using NLog.Web;
using OnlineNewsWebApp.Core.Entities;

namespace OnlineNews.MVCWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("init main of program");
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddControllersWithViews();

                builder.Services.AddDbContext<OnlineNewsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineNewsConnection")));

                builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<OnlineNewsContext>()
                    .AddDefaultTokenProviders();


                builder.Services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequiredUniqueChars = 1;

                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = true;

                    options.SignIn.RequireConfirmedEmail = true;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                });

                builder.Services.ConfigureApplicationCookie(options =>
                {
                    // options.Cookie.HttpOnly = true;  
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.LoginPath = $"/admin/auth/login/";
                    options.LogoutPath = $"/admin/auth/logout/";
                    options.AccessDeniedPath = $"/admin/auth/AccessDenied";
                });

                builder.Services.AddAuthentication();

                builder.Services.AddAuthorization(config =>
                {
                    config.AddPolicy("Get", policy => policy.RequireRole("Admin", "Reader", "Writer"));
                    config.AddPolicy("Create Or Edit", policy => policy.RequireRole("Admin", "Writer"));
                    config.AddPolicy("Delete", policy => policy.RequireRole("Admin", "Writer"));
                });

                builder.Services.AddAutoMapper(config => config.AddProfile<MappingConfig>());

                builder.Logging.ClearProviders();
                builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                builder.Host.UseNLog();

                builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
                builder.Services.AddScoped<IPostService, PostService>();
                builder.Services.AddScoped<ITagService, TagService>();
                builder.Services.AddScoped<ICategoryService, CategoryService>();
                builder.Services.AddScoped<ICommentService, CommentService>();
                builder.Services.AddScoped<IRoleService, RoleService>();
                builder.Services.AddScoped<IUserService, UserService>();

                var app = builder.Build();

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

                app.UseAuthentication();

                app.UseStatusCodePages((context) =>
                {
                    Console.WriteLine(context.HttpContext.Response.StatusCode);
                    return Task.CompletedTask;
                });

                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                });

                app.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }

        }
    }
}