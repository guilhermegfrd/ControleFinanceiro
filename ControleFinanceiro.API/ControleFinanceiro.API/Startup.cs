using ControleFinanceiro.API.Extensions;
using ControleFinanceiro.API.Validacoes;
using ControleFinanceiro.API.ViewModels;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL;
using ControleFinanceiro.DAL.Interfaces;
using ControleFinanceiro.DAL.Repositorios;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace ControleFinanceiro.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Contexto>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConexaoDB")));

            services.AddIdentity<Usuario, Funcao>().AddEntityFrameworkStores<Contexto>();

            services.ConfigurarSenhaUsuario();

            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IFuncaoRepositorio, FuncaoRepositorio>();
            services.AddScoped<ITipoRepositorio, TipoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddTransient<IValidator<Categoria>, CategoriaValidator>();
            services.AddTransient<IValidator<FuncoesViewModel>, FuncoesViewModelValidator>();
            services.AddTransient<IValidator<RegistroViewModel>, RegistroViewModelValidator>();

            services.AddCors();

            services.AddSpaStaticFiles(dir =>
            {
                dir.RootPath = "ControleFinanceiro-UI";
            });

            services.AddControllers()
                .AddFluentValidation()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseSpaStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "ControleFinanceiro-UI");

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer($"http://localhost:4200/");
                }
            });
        }
    }
}
