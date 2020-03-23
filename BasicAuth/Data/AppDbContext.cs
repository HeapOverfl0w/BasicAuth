using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BasicAuth.Model;

namespace BasicAuth.Data
{
  public class AppDbContext : IdentityDbContext<User>
  {
    public AppDbContext(
            DbContextOptions options) : base(options)
    {
    }
  }
}
