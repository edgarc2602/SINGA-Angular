using AutoMapper;
using SINGA.DTOs.Usuario;
using SINGA.DTOs.Miscelaneos;
using SINGA.Models.Usuario;
using SINGA.Models.Miscelaneos;
namespace SINGA
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Catalogo, CatalogoDTO>();
            CreateMap<CatalogoDTO, Catalogo>();
            CreateMap<AccesoDTO, Acceso>();
            CreateMap<Acceso, AccesoDTO>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}