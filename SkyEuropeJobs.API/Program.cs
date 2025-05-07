using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkyEuropeJobs.Application.Interfaces;
using SkyEuropeJobs.Application.Mapping;
using SkyEuropeJobs.Application.Services;
using SkyEuropeJobs.Core.Entities;
using SkyEuropeJobs.Core.Interfaces;
using SkyEuropeJobs.Infrastructure.Data;
using SkyEuropeJobs.Infrastructure.UnitOfWork;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, b =>
    b.MigrationsAssembly("SkyEuropeJobs.Infrastructure")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
       builder =>
       {
           builder.WithOrigins("https://portal.skyeuropejobs.com", "http://localhost:5173")
               .AllowCredentials()
               .AllowAnyMethod()
               .AllowAnyHeader();
       });
});

builder.Services.AddIdentityCore<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();



// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(secretKey),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.Name = "refreshToken";
});


builder.Services.AddAuthorization();


//DI references
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(MappingProfile));



var app = builder.Build();
app.UseCors("AllowSpecificOrigin");

//// Handle OPTIONS preflight requests before authentication
//app.Use(async (context, next) =>
//{
//    if (context.Request.Method == "OPTIONS")
//    {
//        context.Response.StatusCode = 200;
//        context.Response.Headers.AccessControlAllowOrigin = "https://portal.skyeuropejobs.com";
//        return;
//    }
//    await next();
//});

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

app.Run();
