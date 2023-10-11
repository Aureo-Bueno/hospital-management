using Hospital.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Hospital.Utilities;
using Hospital.Repositories.Interface;
using Hospital.Repositories.Implementation;
using Microsoft.AspNetCore.Identity.UI.Services;
using Hospital.Services;
using Hospital.Services.Interfaces;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefautConnection")));

    builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

    builder.Services.AddScoped<IDbInitializer, DbInitializer>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IEmailSender, EmailSender>();
    builder.Services.AddTransient<IHospitalInfo, HospitalInfoService>();
    builder.Services.AddScoped<IContactService, ContactService>();
    builder.Services.AddTransient<IRoomService, RoomService>();

    builder.Services.AddRazorPages();
}

WebApplication? app = builder.Build();
app.UseAuthentication();;
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }
    app.UseHttpsRedirection();
    DataSedding();
    app.UseStaticFiles();

    app.UseRouting();
    app.MapRazorPages();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{Area=admin}/{controller=Hospital}/{action=Index}/{id?}");

    app.Run();
}

void DataSedding()
{
    using(var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        db.Initialize();
    }
}