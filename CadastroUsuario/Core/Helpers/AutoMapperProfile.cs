using AutoMapper;
using CadastroUsuario.Model;
using CadastroUsuario.Model.dto;

namespace CadastroUsuario.Core.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioModel, UsuarioDto>();
            CreateMap<UsuarioDto, UsuarioModel>();

            CreateMap<UsuarioModel, UsuarioCreateModel>();
            CreateMap<UsuarioCreateModel, UsuarioModel>();
        }
    }
}
