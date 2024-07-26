using Core.Interfaces;
using Data.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Core.Entities;


namespace Data
{

    public static class ServiceCollectionExtensions
        {
            public static void AddServices(this IServiceCollection services)
            {
           
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddDbContext<MyContext>(options =>
             options.UseSqlite("Data Source=Youtube.db", b => b.MigrationsAssembly("Data"))); // SQLite'de veritabanı yolu belirtilmelidir.


         

        }

        }
 }