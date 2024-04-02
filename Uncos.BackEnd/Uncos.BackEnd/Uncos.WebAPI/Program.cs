 using System.Reflection; 
using Uncos.Application.Common.Mappings;
using Uncos.Application.Interfaces;
using Uncos.Persistence;
using Uncos.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Uncos.WebAPI.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text; 

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
ConfigurationManager configuration = builder.Configuration;
 




// Here goes code from Startup.ConfigureServices 
services.AddDbContext<UncosDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<UncosDbContext>()
        .AddDefaultTokenProviders();

services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IUncosDbContext).Assembly));
});

services.AddApplication();
services.AddPersistence(configuration);
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


 

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Persons API", Description = "'IT Step' REST API example!", Version = "v1" });
    
});



var app = builder.Build();//After Adding everything we can use Build();
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
app.UseAuthentication();
app.UseAuthorization();
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


 
 