var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

// Add logic data access components
#if ACCOUNT_ON
builder.Services.AddTransient<QTDemoDefaultViews.Logic.IDataAccess<QTDemoDefaultViews.Logic.Entities.Account.Role>, QTDemoDefaultViews.Logic.Controllers.Account.RolesController>();
#endif

builder.Services.AddTransient<QTDemoDefaultViews.Logic.IDataAccess<QTDemoDefaultViews.Logic.Entities.Person>, QTDemoDefaultViews.Logic.Controllers.PersonsController>();

// Add session cookie
builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
    options.Cookie.Name = $".{nameof(QTDemoDefaultViews)}.Session";
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
