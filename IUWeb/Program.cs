using BusinessLayer.Ioc;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.MyService();


// Giriş Yapılacak Olan Controller Hangisi ?
// Çıkış Yapılacak Olan Sayfa Hangisi ?
// Kullanıcı Sisteme Giriş Yaptğında ne kadar giriş yapılı olarak kalacağını ?

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
    {
        x.LoginPath = "/admin/Giris";
        x.LogoutPath = "/admin/Cikis";
        x.AccessDeniedPath = "/YetkisizGiris";
    });

// Bütün Sayfalara Yasak Koyma
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc.Authorization;
builder.Services.AddControllersWithViews(x=>
{
    var Dogrulama = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    x.Filters.Add(new AuthorizeFilter(Dogrulama));

});



var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(x =>
{
    x.MapDefaultControllerRoute();
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
