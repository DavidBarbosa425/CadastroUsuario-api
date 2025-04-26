using AutoMapper;
using CadastroUsuario.Core.Data;
using CadastroUsuario.Model;
using CadastroUsuario.Model.dto;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Service
{
    public class UsuarioService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UsuarioDto>> Get()
        {
            var res = await _context.Usuarios.Include(u => u.Escolaridade).ToListAsync();
            var resultadoMapeado = _mapper.Map<IEnumerable<UsuarioDto>>(res);
            return resultadoMapeado;
        }
        public async Task<UsuarioDto> GetUsuarioById(Guid id)
        {
            var res = _context.Usuarios.Find(id);
            var resMapeado = _mapper.Map<UsuarioDto>(res);
            return resMapeado;
        }

        public async Task<bool> Create(UsuarioCreateModel usuario)
        {
            var usuarioModel = _mapper.Map<UsuarioModel>(usuario);
            usuarioModel.DataInclusao = DateTime.Now;
            _context.Add(usuarioModel);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> Update(UsuarioModel usuario)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(usuario.Id);

            if (usuarioExistente == null) return false;

            usuarioExistente.Id = usuario.Id;
            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Sobrenome = usuario.Sobrenome;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.DataNascimento = usuario.DataNascimento;
            usuarioExistente.EscolaridadeId = usuario.EscolaridadeId;

            _context.Usuarios.Update(usuarioExistente);
            var res = _context.SaveChanges();
            return res > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return false;
            _context.Usuarios.Remove(usuario);
            var res = _context.SaveChanges();
            return res > 0;

        }

        public async Task<IEnumerable<EscolaridadeModel>> GetEscolaridade()
        {
            var res = await _context.Escolaridades.ToListAsync();

            if (res.Count <= 0)
            {
                res = await PopularEscolaridade();
            }

            return res;
        }

        public async Task<List<EscolaridadeModel>> PopularEscolaridade()
        {
            var escolaridadeList = new List<EscolaridadeModel>() {
        new EscolaridadeModel
        {
            Id = Guid.NewGuid(),
            Descricao = "INFANTIL"
        },
        new EscolaridadeModel
        {
            Id = Guid.NewGuid(),
            Descricao = "FUNDAMENTAL"
        },
        new EscolaridadeModel
        {
            Id = Guid.NewGuid(),
            Descricao = "MEDIO"
        },
        new EscolaridadeModel
        {
            Id = Guid.NewGuid(),
            Descricao = "SUPERIOR"
        }
   };

            _context.AddRange(escolaridadeList);
            var res = await _context.SaveChangesAsync();

            if (res <= 0) return new List<EscolaridadeModel>();

            var escolaridades = await _context.Escolaridades.ToListAsync();

            return escolaridades;
        }
    }
}
