using AutoMapper;
using BuisnessLogicLayer;
using BuisnessLogicLayer.Services.Abstract;
using BuisnessLogicLayer.Services.Implement;
using DataAccessLayer.DAL;
using DataAccessLayer.Entities;
using DataAccessLayer.Validators;
using DATAlayer.Validators;
using FinalProject.Mapper;
using FinalProject.Services.Abstractions;
using FinalProjectMatrix;
using FluentValidation;
using HotelReservationProject.Services.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using speedyStayBL.Services.Abstractions;
using System.Reflection.Metadata;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IValidator<Advertisement>, AdvertisementValidator>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Room>, RoomValidator>();
builder.Services.AddScoped<IValidator<Reservation>, ReservationValidator>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Branch>, BranchValidator>();
builder.Services.AddScoped<IValidator<Customer>, CustomerValidator>();


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfiler());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = true;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("mjnhgvftdoqowevla")),
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidIssuer = "https://localhost:7136/swagger/index.html",
                   ValidAudience = "MyAPI",
               };
           });

builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
    c.SwaggerDoc($"v1", new OpenApiInfo
    {   
        Title = "Hotel Reservation Project",
        Version = "v1",


    });

    var xmlFile = Path.Combine(AppContext.BaseDirectory, "FinalProjectMatrix.xml");
    c.IncludeXmlComments(xmlFile);
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                      { jwtSecurityScheme, Array.Empty<string>() }
                });
});




// AddCustomerDTO services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ConfigureExceptionHandler(Log.Logger);

app.UseMiddleware<GlobalExceptionHandling>();


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
