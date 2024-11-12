using ST10045251_CLDV6212_POE.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

string connectionString = builder.Configuration.GetConnectionString("AzureSqlDb");

builder.Services.AddSingleton(new DatabaseService(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{action=Index}/{id?}",
        defaults: new { controller = "Storage" }
    );
});

app.Run();
