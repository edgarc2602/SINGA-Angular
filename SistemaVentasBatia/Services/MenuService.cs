using AutoMapper;
using SINGA.Models;
using SINGA.Repositories.Contabilidad;
using SINGA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINGA.Models.Miscelaneos;
using SINGA.DTOs.Miscelaneos;
using Microsoft.Extensions.Options;
using SINGA.Controllers;
using SINGA.Models.MenuLateral;
using SINGA.Repositories;

namespace SINGA.Services
{
    public interface IMenuService
    {
        Task<List<MenuArea>> ObtenerMenu();
    }

    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _MenuRepo;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository MenuRepo, IMapper mapper)
        {
            _MenuRepo = MenuRepo;
            _mapper = mapper;
        }

        public async Task<List<MenuArea>> ObtenerMenu()
        {
            var listaMenuArea = await _MenuRepo.ObtenerMenu();
            foreach( var area in listaMenuArea)
            {
                area.MenuAreaProceso = await _MenuRepo.ObtenerProcesos(area.IdArea);
                foreach(var proceso in area.MenuAreaProceso)
                {
                    proceso.MenuAreaProcesoFormulario = await _MenuRepo.ObtenerFormularios(area.IdArea, proceso.IdProceso);
                }
            }
            return listaMenuArea;
        }
    }
}
