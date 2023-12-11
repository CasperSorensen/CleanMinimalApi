using Application.Abstractions;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public interface IDataAccessConfiguration
{
    void Configure(IServiceCollection services, IConfiguration configuration);
}
