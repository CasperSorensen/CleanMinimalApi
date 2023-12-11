using Application.Abstractions;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public class SqlDataAccessConfiguration : IDataAccessConfiguration
{
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("Default");

        services.AddDbContext<SocialDbContext>(opt =>
        {
            opt.UseSqlServer(connString);
        });

        services.AddScoped<IStorage, SqlRespository>();
    }
}