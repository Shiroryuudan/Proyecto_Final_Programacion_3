using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MJL_Ecommerce.Areas.Identity.Data;

namespace MJL_Ecommerce.Areas.Identity.Data;

public class LoginMJL_EcommerceContext : IdentityDbContext<Usuario>
{
    public LoginMJL_EcommerceContext(DbContextOptions<LoginMJL_EcommerceContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
