using Microsoft.EntityFrameworkCore;
using Razor_Pages_CRUD__ef_core_class_first_.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.RootDirectory = "/Pages/CRUD";
    options.Conventions.AddPageRoute("/Pages/CRUD/Index", "CRUD");
});


string connection = @"Data Source=DESKTOP-EE1ACSQ;User ID=sa; Password=admin1234;Initial Catalog=Worker_Db;Integrated Security=True";

builder.Services.AddDbContext<WorkerDbContext>(options => options.UseSqlServer(connection));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
