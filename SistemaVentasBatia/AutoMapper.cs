using AutoMapper;
using SINGA.Models;
using SINGA.DTOs;
using SINGA.Enums;

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