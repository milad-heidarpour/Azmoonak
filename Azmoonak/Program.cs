using Azmoonak.Core.Interface;
using Azmoonak.Core.Services;
using Azmoonak.Database.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddMvc();
builder.Services.AddScoped<DatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IGroup,GroupService>();
builder.Services.AddScoped<IQuestion,QuestionService>();
builder.Services.AddScoped<IAccount,AccountService>();
builder.Services.AddScoped<IProfile,ProfileService>();


const string scheme = "Azmoonak";
builder.Services.AddAuthentication(scheme).AddCookie(scheme, option =>
{
    option.LoginPath = "/Account/Login";
    option.AccessDeniedPath = "/Account/Login";
    option.ExpireTimeSpan = TimeSpan.FromDays(30);//machin keyباید روی هاست ساخته شود 
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Panel}/{action=Index}/{id?}");


    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=home}/{action=index}/{id?}");

});



app.Run();
