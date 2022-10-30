using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.API.Extensions
{
    public static class ConfiguracaoIdentityExtension
    {
        public static void ConfigurarSenhaUsuario(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredUniqueChars = 0;
            });
        }
    }
}
