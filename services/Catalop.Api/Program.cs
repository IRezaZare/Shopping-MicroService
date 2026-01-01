using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
// Register Mediator
builder.Services.AddMediatR(x =>  x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
//DI
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<ITypeRepository , TypeRepository>();
builder.Services.AddScoped<IBrandRepository , BrandRepository>();
builder.Services.AddScoped<IProductRepository , ProductRepository>();
// Add Swagger Services
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
    c.SwaggerDoc("v1" , new ()
    {
        Title = "Catalog.Api",
        Version = "v1",
        Description = "Catalog Api"
    })
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
