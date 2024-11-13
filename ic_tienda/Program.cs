// using ic_tienda_bussines.Auth.repositories;
// using ic_tienda_bussines.Auth.services;
using ic_tienda_bussines.Auth.repositories;
using ic_tienda_bussines.Auth.services;
using ic_tienda_bussines.Store.repositories;
using ic_tienda_bussines.Store.services;
using ic_tienda_data.Auth.repositories;
using ic_tienda_data.Auth.services;

// using ic_tienda_data.Auth.repositories;
// using ic_tienda_data.Auth.services;
using ic_tienda_data.Store.repositories;
using ic_tienda_data.Store.services;
using Microsoft.EntityFrameworkCore;
using ic_tienda.Middlewares;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// string connStr = builder.Configuration
//     .GetValue<string>("ConnectionStrings:IcLocalDb");

string connStr = builder.Configuration
    .GetValue<string>("ConnectionStrings:IcTiendaDb");

builder.Services.AddDbContext<ic_tienda_data.sources.BaseDeDatos.IcTiendaDbContext>(
    // Connect to SqlServer
    (config) => config.UseSqlServer(connStr, b => b.MigrationsAssembly("ic_tienda_presentacion"))
    // connect to sqlite database
    // (config) => config.UseSqlite(
    //     builder.Configuration.GetConnectionString("IcLocalDb"),
    //     b => b.MigrationsAssembly("ic_tienda_presentacion")
    // )
);


string webFront = builder.Configuration.GetValue<string>("CORS:web");
string webFront2 = builder.Configuration.GetValue<string>("CORS:web2");
builder.Services.AddCors(
    (conf) => conf.AddDefaultPolicy( policy => 
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            //.AllowAnyOrigin()
            //.WithMethods("GET,PUT")
            .WithOrigins(webFront, webFront2)
    )
);

// LOGS
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File($"Logs/logs.txt")
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();


// Inyeccion de dependencias
// services
// builder.Services.AddScoped<IRolService, RolServiceDbImpl>();
// builder.Services.AddScoped<IAppUserService, AppUserDbImpl>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationServiceDbImpl>();
builder.Services.AddScoped<IBrandService, BrandServiceDbImpl>();
builder.Services.AddScoped<ICategoryService, CategoryServiceDbImpl>();
builder.Services.AddScoped<IProductService, ProductServiceDbImpl>();
// repositories
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepositoryImpl>();
builder.Services.AddScoped<IProductRepository, ProductRepositryImpl>();




var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.MapGet("/", async () =>  Results.Ok(new { Page = "Index"}) );
app.MapGet("/health", async () =>  Results.Ok(new { Status = "Live"}) );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.UseMiddleware<JwtMiddleware>();

app.Run();
