using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Repositories.DbModels;
using Repositories.RepositoryBase;
using Repositories.RepositoryImplementations;
//using Services.BusinessLogic;
using Services.ServiceImplementation;
using Services.ServicesBase;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext to use MySQL (Pomelo)
builder.Services.AddDbContext<SMSContext>(options =>
options.UseMySql(
builder.Configuration.GetConnectionString("DefaultConnection"),
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Register services
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>(); // Assuming CourseRepository implements ICourseRepository


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
