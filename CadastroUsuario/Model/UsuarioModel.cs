using CadastroUsuario.Core.Base.Model;

namespace CadastroUsuario.Model
{   
    public class UsuarioModel : BaseModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid EscolaridadeId  { get; set; }
        public EscolaridadeModel? Escolaridade { get; set; }
    }
}
