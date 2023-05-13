using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Test_Invoice.Data;
using Test_Invoice.Helpers;
using Test_Invoice.Services;

var builder = WebApplication.CreateBuilder(args);
string EnableCORS = "EnableCORS";

// Add services to the container.
builder.Services.AddControllersWithViews();
int timeoutInHours = 0;
try
{
    timeoutInHours = int.Parse(builder.Configuration.GetSection("SessionTimeout:InHours").Value);
}
catch (Exception) { }

builder.Services.AddCors(options =>
{
    options.AddPolicy(EnableCORS, builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromHours(timeoutInHours));

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbString")));

builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddSingleton<DataProtectionPurposeStrings>();

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=CustomerList}/{id?}");

app.UseCors(EnableCORS);

app.Run();
