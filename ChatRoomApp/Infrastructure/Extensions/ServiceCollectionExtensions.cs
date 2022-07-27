using ChatRoomApp.Business.Services;
using ChatRoomApp.Data;
using ChatRoomApp.Data.Models.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace ChatRoomApp.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ChatRoomAppDbContext>(opts =>
            {
                var connectionString = configuration.GetConnectionString("Default");
                var migrationsAssembly = typeof(ChatRoomAppDbContext).Assembly.GetName().Name;

                opts.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(migrationsAssembly);
                    sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(15), null);
                });
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IChatRoomService, ChatRoomService>();


            return services;
        }
    }
}
