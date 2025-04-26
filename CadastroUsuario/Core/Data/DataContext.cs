using CadastroUsuario.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }       
        public DbSet<EscolaridadeModel> Escolaridades { get; set; }       
    }
}

