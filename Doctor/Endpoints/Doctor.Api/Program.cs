using Common.Application;
using Doctor.Config;
using Common.AspNetCore.Middlewares;
using Doctor.Api.Infrastructure.JwtUtil;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Doctor.Api.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(option =>
    {
        option.InvalidModelStateResponseFactory = (context =>
        {
            var result = new ApiResult()
            {
                IsSuccess = false,
                MetaData = new()
                {
                    AppStatusCode = AppStatusCode.BadRequest,
                    Message = ModelStateUtil.GetModelStateErrors(context.ModelState)
                }
            };
            return new BadRequestObjectResult(result);
        });
    });
builder.Services.AddDistributedRedisCache(option =>
{
    option.Configuration = "localhost:6379";
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Enter Token",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    option.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.RegisterDocotrDependency(connectionString);
builder.Services.RegisterApiDependency(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);

CommonBootstrapper.Init(builder.Services);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseApiCustomExceptionHandler();
app.UseHttpsRedirection();

app.UseCors("DoctorApi");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
