namespace CadastroUsuario.Model
{
    public class UsuarioCreateModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid EscolaridadeId { get; set; }
    }
}
