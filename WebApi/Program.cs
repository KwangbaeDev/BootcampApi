using Infrastructure;
using Microsoft.OpenApi.Models;
using WebApi;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(c =>
//    {
//        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Api", Version = "v1" });
//        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//        {
//            Description = "JWT Authorization header using the Bearer scheme",
//            Name = "Authorization",
//            In = ParameterLocation.Header,
//            Type = SecuritySchemeType.Http,
//            BearerFormat = "JWT",
//            Scheme = "bearer"
//        });

//        c.AddSecurityRequirement(new OpenApiSecurityRequirement
//        {
//            {
//                new OpenApiSecurityScheme
//                {
//                    Reference = new OpenApiReference
//                    {
//                        Type = ReferenceType.SecurityScheme,
//                        Id = "Bearer"
//                    }
//                },
//                new string[] { }
//            }
//        });
//    });



builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddWebApi(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api V1");
    //    c.RoutePrefix = string.Empty;
    //});
    //app.UseSwaggerUI();
    //builder.Services.AddSwaggerGen(c =>
    //{
    //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Api", Version = "v1" });
    //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //    {
    //        Description = "JWT Authorization header using the Bearer scheme",
    //        Name = "Authorization",
    //        In = ParameterLocation.Header,
    //        Type = SecuritySchemeType.Http,
    //        BearerFormat = "JWT",
    //        Scheme = "bearer"
    //    });

    //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //    {
    //        {
    //            new OpenApiSecurityScheme
    //            {
    //                Reference = new OpenApiReference
    //                {
    //                    Type = ReferenceType.SecurityScheme,
    //                    Id = "Bearer"
    //                }
    //            },
    //            new string[] { }
    //        }
    //    });
    //});
}

app.UseMiddleware<ExceptionHandleMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
