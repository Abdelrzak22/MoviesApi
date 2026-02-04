using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography.Xml;
using WebApplication2.dbcontext;
using WebApplication2.services;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("DefualtConnection");

            builder.Services.AddDbContext<Applicationdbcontext>(Options =>
            Options.UseSqlServer(connection));

            // Add services to the container.
            builder.Services.AddTransient<IGenerservices, Generservices>();
            builder.Services.AddTransient<Imovieservice, Movieservices>();
            builder.Services.AddControllers();
            builder.Services.AddCors();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(Options =>
            {
                Options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BEBO",
                    Description = "Wenderfull api",
                    TermsOfService = new Uri("https://www.example.com"),
                    Contact = new OpenApiContact
                    {
                        Name="taha",
                        Email="abo@gamil.com",
                        Url=new Uri ("https://www.example.com")

                    },
                    License = new OpenApiLicense
                    {

                        Name = "License",
                    }

                    

                });

                Options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {

                    Scheme="Bearer",
                    Name="authorization",
                    Type=SecuritySchemeType.ApiKey,
                    BearerFormat="jwt",
                    Description="enter your token"

                });

                Options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference=new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        },
                        Name="Bearer",
                        In=ParameterLocation.Header
                    },

                    new List<string>()
                    }

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
            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
