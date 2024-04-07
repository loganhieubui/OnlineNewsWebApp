using Microsoft.EntityFrameworkCore;
using OnlineNewsWebApp.Core.IServices;
using OnlineNewsWebApp.Infrastructure.Database;
using OnlineNewsWebApp.Infrastructure.IRepos;
using OnlineNewsWebApp.Infrastructure.Mapper;
using OnlineNewsWebApp.Infrastructure.Repos;
using OnlineNewsWebApp.Infrastructure.Services;

namespace OnlineNews.MVCWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<OnlineNewsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineNewsConnection")));

            builder.Services.AddAutoMapper(config => config.AddProfile<MappingConfig>());
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}