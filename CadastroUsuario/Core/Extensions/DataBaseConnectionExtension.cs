using CadastroUsuario.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Core.Extensions
{
    public static class DataBaseConnectionExtension
    {
        public static IServiceCollection AddDataBaseConnection(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            return services;

        }
    }
}
