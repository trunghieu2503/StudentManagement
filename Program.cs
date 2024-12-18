using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CourseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CourseDbContext") ?? throw new InvalidOperationException("Connection string 'CourseDbContext' not found.")));

//automapper config
builder.Services.AddAutoMapper(typeof(Program));

//DI configuration
builder.Services.AddTransient<ICoursesService, CoursesService>();
builder.Services.AddTransient<IStudentService, StudentService>();

//File Storage
builder.Services.AddTransient<IStorageService, FileStorageService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    DbInitializer.Seed(services);
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
