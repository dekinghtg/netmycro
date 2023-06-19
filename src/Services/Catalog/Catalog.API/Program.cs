using Catalog.API.Data;
using Catalog.API.Repositories;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });
            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line

        });

        builder.Services.AddScoped<ICatalogContext, CatalogContext>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
         
        var app = builder.Build();
       // app.UseDeveloperExceptionPage();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            

        }

        //app.UseHttpsRedirection();

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}