using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Refah.Application.Profiles;
using Refah.EntityFrameworkCore;
using Refah.WebApi.ApiExceptionHandlare;
using System.Text;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using ConfigurationManager = Refah.WebApi.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region [-AddMvcCore-]
builder.Services.AddMvcCore().AddApiExplorer();
#endregion

#region [-mappingConfig-]
builder.Services.AddAutoMapper(typeof(Program));

var mappingConfig = new MapperConfiguration
            (a => a.AddProfile(new Auto_Map())).CreateMapper();

builder.Services.AddSingleton(mappingConfig);
#endregion

#region [-AddSwaggerGen-]
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Email = string.Empty,
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });

});
#endregion

#region [-AddAuthentication-]
builder.Services.AddAuthentication(opt =>
{
opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = ConfigurationManager.AppSetting["JWT:ValidIssuer"],
        ValidAudience = ConfigurationManager.AppSetting["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]))
    };
});
#endregion


builder.Services.AddServicesOfAllTypes();
builder.Services.AddServicesWithAttributeOfType<ScopedServiceAttribute>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region [-AddDbContext-]
builder.Services.AddDbContext<WelfareBankDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Refah_Bank"))); 
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
#region [-Configure-]
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(a => { a.SerializeAsV2 = true; });
    app.UseSwaggerUI();
    app.UseSwaggerUi3();
}
else
{
    app.UseMiddleware<ApiExceptionMiddleware>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.Run(); 
#endregion
