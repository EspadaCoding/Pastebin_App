 using System.Reflection; 
using Uncos.Application.Common.Mappings;
using Uncos.Application.Interfaces;
using Uncos.Persistence;
using Uncos.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Uncos.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var services = builder.Services;

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<UncosDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {

    }
}




// Here goes code from Startup.ConfigureServices 
services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IUncosDbContext).Assembly));
});

services.AddApplication();
services.AddPersistence(builder.Configuration);
services.AddControllers();

services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

services.AddDbContext<UncosDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
}); 

services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Persons API", Description = "'IT Step' REST API example!", Version = "v1" });
    
});





// Here goes code from Startup.Configure
 
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//Add swagger
app.UseSwagger();

app.UseSwaggerUI(option => {
    option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    option.RoutePrefix = string.Empty;
});

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
    endpoints.MapControllers();
});
        

app.Run();


 
 