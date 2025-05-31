using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure authentication with cookie scheme
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";          // Redirect here if not authenticated
        options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect here if user lacks role/permission
    });

// Add authorization services
builder.Services.AddAuthorization();

// Add HttpClient factory for API calls
builder.Services.AddHttpClient();

// Add session support (needed for your token storage)
builder.Services.AddSession();

var app = builder.Build();

// Configure middleware pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Session middleware before authentication
app.UseSession();

// Enable authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Pick}/{id?}");

app.Run();
