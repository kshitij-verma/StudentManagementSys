using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Repositories.DbModels;
using Services.BusinessLogic;
using Microsoft.Extensions.Configuration;
using Repositories.DbModels;
using Repositories.Interfaces;
using Repositories.RepositoryBase;
using Services.BusinessLogic;
//using Microsoft.Graph.Models;



public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure services
        builder.Services.AddDbContext<SMSContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseRouting();
        app.MapControllers();
        app.Run();
    }
}
