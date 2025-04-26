namespace CadastroUsuario.Model.dto
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid EscolaridadeId { get; set; }
        public EscolaridadeModel Escolaridade { get; set; }
    }
}
