using Music.Contracts;
using Music.Entity;
using Music.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Music.EntityFramework.Repository;

namespace Music.HttpApi.Extensions;
public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        //添加跨域服务
        services.AddCors(Options =>
        {
            Options.AddPolicy(name: "AnyPolicy", //添加跨域策略
                configurePolicy: builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
    public static void ConfigureSQLiteContext(this IServiceCollection services)
    {
        services.AddDbContext<MusicContext>(
            builder => builder.UseSqlite("Filename=DbCourceContext.db"));
    }
    //加入对数据库后端的操作
    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}
 