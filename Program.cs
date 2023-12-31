using System.Net.NetworkInformation;
using System.Reflection;
using Api_SistemaCursosDistancia.Context;
using Api_SistemaCursosDistancia.Interfaces;
using Api_SistemaCursosDistancia.Models;
using Api_SistemaCursosDistancia.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CursoDistanciaContext>(
      options =>
          options.UseSqlServer(
              builder.Configuration.GetConnectionString("ConexaoPadrao")
          ));

builder.Services.AddScoped<ICadastroRepository, CadastroRepository>();
builder.Services.AddScoped<IAulaRepository, AulaRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IModuloRepository, ModuloRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "SistemaCursoDistancia.Api.", 
        Version = "v1.",
        Description = "API desenvolvida para o site do sistema curso a distancia. ",
        TermsOfService = new Uri("https://meusite.com"),
        Contact = new OpenApiContact
        {
            Name = "Victor Sérgio",
            Url = new Uri("https://meusite.com")
        },
        License = new OpenApiLicense
        {
            Name = "Curso a distancia ApTech",
            Url = new Uri("https://meusite.com")
        }
    });
//Add Configuracoes extras da documentaçao, para ler os XMLs
    var xmlArquivo = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlArquivo));
});

//config JWT
    
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ApiCursoAdistancia-chave-autenticacao")),
        ClockSkew = TimeSpan.FromMinutes(30),
        ValidIssuer = "ApiCursoAdistancia.webAPI",
        ValidAudience = "ApiCursoAdistancia.webAPI",
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();


app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")
    ),
    RequestPath = "/Files"
});

app.MapControllers();

app.Run();