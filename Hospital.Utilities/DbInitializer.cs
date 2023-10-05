using Hospital.Models;
using Hospital.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Utilities;
public class DbInitializer : IDbInitializer
{
    private UserManager<IdentityUser> _userManager;
    private RoleManager<IdentityRole> _roleManager;
    private ApplicationDbContext _applicationDbContext;

    public DbInitializer(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext applicationDbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _applicationDbContext = applicationDbContext;
    }

    public void Initialize()
    {
        try
        {
            if (_applicationDbContext.Database.GetPendingMigrations().Count() > 0)
            {
                _applicationDbContext.Database.Migrate();
            }
        }
        catch (Exception)
        {

            throw;
        }

        if (!_roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
        {
            _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Patient)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Aureo",
                Email = "aureo@bueno.com"
            }, "AureoBueno321").GetAwaiter().GetResult();

            ApplicationUser? AppUser = _applicationDbContext.Set<ApplicationUser>().FirstOrDefault(x => x.Email == "aureo@bueno.com");

            if (AppUser is not null)
            {
                _userManager.AddToRoleAsync(AppUser, WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult();
            }
        }
    }
}
