using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Domain.Models;

namespace DataAccess;

public class SocialDbContext : DbContext
{
  public SocialDbContext(DbContextOptions opt) : base(opt)
  {

  }

  public DbSet<Post> Posts { get; set; }

}
