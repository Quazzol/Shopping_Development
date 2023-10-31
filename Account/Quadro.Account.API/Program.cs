using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Quadro.Account.API;
using Microsoft.Extensions.Primitives;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddLogging();

builder.Services.AddControllers();
builder.Services.AddMediatR((q) => q.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

//Add Core Infrastructure
builder.Services.AddCoreInfrastructure();
builder.Services.AddEmailService(builder.Configuration);

//Add Account Infrastructure
builder.Services.AddAccountInfrastructure(builder.Configuration);

builder.Services.AddSingleton<ITokenProvider, TokenProvider>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

})
     .AddJwtBearer(x =>
     {
         x.SaveToken = true;
         x.RequireHttpsMetadata = false;
         x.TokenValidationParameters.ValidateIssuerSigningKey = true;
         x.TokenValidationParameters.IssuerSigningKey = TokenProvider.GetSecurityKey();
         x.TokenValidationParameters.ValidateIssuer = false;
         x.TokenValidationParameters.ValidateAudience = false;
     }
     );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Account API",
        Description = "API for Managing Accounts",
        TermsOfService = new Uri("https://github.com/Quazzol/Shopping_Development"),
        Contact = new OpenApiContact
        {
            Name = "Quadro Contact",
            Url = new Uri("https://github.com/Quazzol/Shopping_Development")
        },
        License = new OpenApiLicense
        {
            Name = "Quadro License",
            Url = new Uri("https://github.com/Quazzol/Shopping_Development")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    // options.CustomSchemaIds(x => x.GetCustomAttributes<DisplayNameAttribute>().SingleOrDefault().DisplayName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

builder.WebHost.UseIIS();

app.Run();
