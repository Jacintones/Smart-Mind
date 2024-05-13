using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Application.Mappings;
using Smart_Mind.Application.Services;
using Smart_Mind.Domain.Interfaces;
using Smart_Mind.infrastructure.Context;
using Smart_Mind.infrastructure.Repositories;
using System.Text;

namespace Smart_Mind.CrossCutting.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            var mySqlConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            services.AddAuthorization();

            var secretKey = configuration["JWT:SecretKey"]
                ?? throw new ArgumentException("Invalid secret key");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IMateriaRepository, MateriaRepository>();
            services.AddScoped<IMateriaService, MateriaService>();

            services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            services.AddScoped<IAssuntoService, AssuntoService>();

            services.AddScoped<IQuestaoRepository, QuestaoRepository>();
            services.AddScoped<IQuestaoService, QuestaoService>();

            services.AddScoped<IExplicacaoAssuntoRepositorio, ExplicacaoAssuntoRepositorio>();
            services.AddScoped<IExplicacaoAssuntoService,  ExplicacaoAssuntoService>();

            services.AddScoped<ITesteRepository, TesteRepository>();
            services.AddScoped<ITesteService, TesteService>();

            services.AddScoped<ITokenService, TokenService>();


            services.AddAutoMapper(typeof(DomainToDTOProfile));

            return services;
        }

    }
}
