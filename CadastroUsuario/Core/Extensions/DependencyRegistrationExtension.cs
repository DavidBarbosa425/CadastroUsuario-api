using CadastroUsuario.Core.Helpers;
using CadastroUsuario.Service;

namespace CadastroUsuario.Core.Extensions
{
    public static class DependencyRegistrationExtension
    {
        public static IServiceCollection RegistersDependencies(this IServiceCollection service)
        {
            service.AddScoped<UsuarioService>();
            service.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            return service;
        }
    }
}
