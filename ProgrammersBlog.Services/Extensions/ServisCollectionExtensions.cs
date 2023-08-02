using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Extensions
{
    public static class ServisCollectionExtensions
    {
        public static IServiceCollection LoadMyServices (this IServiceCollection seviceCollection,string connectionString)
        {
            seviceCollection.AddDbContext<ProgrammersBlogContext>(options=>options.UseSqlServer(connectionString));
            seviceCollection.AddIdentity<User, Role>(options =>
            {
                //User Password Options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase=false;
                // User Username and Email Options
                options.User.AllowedUserNameCharacters= "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ProgrammersBlogContext>();
            seviceCollection.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(15);
            });
            seviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            seviceCollection.AddScoped<ICategoryService, CategoryManager>();
            seviceCollection.AddScoped<IArticleService, ArticleManager>();
            seviceCollection.AddScoped<ICommentService, CommentManager>();
           

            return seviceCollection;
        }
    }
}
