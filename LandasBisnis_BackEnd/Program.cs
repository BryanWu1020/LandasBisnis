using AutoMapper;
using FluentValidation;
using LandasBisnis_BackEnd.Contracts;
using LandasBisnis_BackEnd.Mappings;
using LandasBisnis_BackEnd.Models;
using LandasBisnis_BackEnd.Repositories;
using LandasBisnis_BackEnd.Services;
using LandasBisnis_BackEnd.Settings;
using LandasBisnis_BackEnd.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configuration

builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection("DatabaseSetting"));
builder.Services.AddSingleton<DatabaseSetting>(serviceProvider => serviceProvider.GetRequiredService<IOptions<DatabaseSetting>>().Value);

builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("JwtSetting"));
builder.Services.AddSingleton<JwtSetting>(serviceProvider => serviceProvider.GetRequiredService<IOptions<JwtSetting>>().Value);

// Repository

builder.Services.AddSingleton<IUserRepository<User>, UserRepository<User>>();
builder.Services.AddSingleton<IUserRepository<Admin>, UserRepository<Admin>>();
builder.Services.AddSingleton<IUserRepository<Sponsor>, UserRepository<Sponsor>>();
builder.Services.AddSingleton<IUserRepository<Sponsoree>, UserRepository<Sponsoree>>();

// Validator

builder.Services.AddSingleton<IValidator<CreateSponsoreeContract>, CreateSponsoreeValidator>();
builder.Services.AddSingleton<IValidator<CreateSponsorContract>, CreateSponsorValidator>();

// Mapper

builder.Services.AddAutoMapper(typeof(UserMapping));

// Services

builder.Services.AddSingleton(serviceProvider =>
   new AuthService(
    serviceProvider.GetRequiredService<JwtSetting>()
    )
);

builder.Services.AddSingleton<IUserService, UserService>(serviceProvider =>
    new UserService(
        serviceProvider.GetRequiredService<IUserRepository<User>>(),
        serviceProvider.GetRequiredService<AuthService>(),
        serviceProvider.GetRequiredService<IMapper>()
    )
);

builder.Services.AddSingleton<ISponsoreeService, SponsoreeService>(serviceProvider =>
    new SponsoreeService(
        serviceProvider.GetRequiredService<IUserRepository<Sponsoree>>(),
        serviceProvider.GetRequiredService<IMapper>(),
        serviceProvider.GetRequiredService<IValidator<CreateSponsoreeContract>>()
    )
);

builder.Services.AddSingleton<ISponsorService, SponsorService>(serviceProvider =>
    new SponsorService(
        serviceProvider.GetRequiredService<IUserRepository<Sponsor>>(),
        serviceProvider.GetRequiredService<IMapper>(),
        serviceProvider.GetRequiredService<IValidator<CreateSponsorContract>>()
    )
);

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.Events = new JwtBearerEvents{
        OnMessageReceived = context => {
            var service = context.HttpContext.RequestServices.GetRequiredService<AuthService>();
            service.ConfigureJwtOptions(options);
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin"))
    .AddPolicy("Sponsor", policy => policy.RequireClaim("Role", "Sponsor"))
    .AddPolicy("Sponsoree", policy => policy.RequireClaim("Role", "Sponsoree"))
    .AddPolicy("CanManageAdmins", policy => policy.RequireClaim("Role", "Admin").RequireClaim("CanManageAdmins", "True"))
    .AddPolicy("CanManageUsers", policy => policy.RequireClaim("Role", "Admin").RequireClaim("CanManageUsers", "True"))
    .AddPolicy("CanManageEvents", policy => policy.RequireClaim("Role", "Admin").RequireClaim("CanManageEvents", "True"))
    .AddPolicy("CanManageStatus", policy => policy.RequireClaim("Role", "Admin").RequireClaim("CanManageStatus", "True"));

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
