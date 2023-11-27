using System.Reflection;
using Microsoft.OpenApi.Models;
using Quadro.Product.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddLogging();

builder.Services.AddControllers();
builder.Services.AddMediatR((q) => q.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

//Add Core Infrastructure
builder.Services.AddCoreInfrastructure();

//Add Product Infrastructure
builder.Services.AddProductInfrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Product API",
        Description = "API for Managing Products",
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

app.UseAuthorization();

app.MapControllers();

builder.WebHost.UseIIS();
app.Run();
