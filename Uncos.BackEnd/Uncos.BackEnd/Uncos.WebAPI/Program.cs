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
using Uncos.WebAPI.Services;

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
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Uncos API",
        Description = "Описание API"
    });

    // Настройка для использования токена авторизации
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Введите токен JWT с префиксом Bearer",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                new OpenApiSecurityScheme {
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});
var key = Encoding.ASCII.GetBytes(configuration["JWT:Secret"]);
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

services.AddScoped<IUserService, UserService>();


 



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
app.UseCors("AllowAll");
app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();


 
 