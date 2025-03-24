using BlogApi.InfIoc.dependencyContainer;
using BlogApi.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

using Serilog;



using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//configuration serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .WriteTo.File("serilogd/mylog.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.MSSqlServer(
    connectionString: "Server=.; Database=blogLogs; User Id=sa;Password=123456789;Connect Timeout=60;TrustServerCertificate=True",

    tableName: "Logs",
    autoCreateSqlTable: true
    )

    .CreateLogger();

builder.Host.UseSerilog();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Add security definition for JWT Bearer
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Scheme = "bearer",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Description = "Enter '' [space] and then your token in the text input below.\n\nExample: \"Bearer 12345abcdef\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.RegisterService();
builder.Services.AddDbContext<BlogApiDbContext>(Options =>
{

    Options.UseSqlServer(builder.Configuration.GetConnectionString("App"));
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {

        option.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateActor = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:44384",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-256-bit-secret-32-bytes"))

        };
    });
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("EnableCors", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .Build();

    });
});














var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//?
app.MapGet("/", () => "Hello World!");



app.UseAuthorization();

app.MapControllers();
app.UseCors("EnableCors");
app.UseAuthentication();


app.Run();
