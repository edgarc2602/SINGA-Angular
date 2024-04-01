using AutoMapper;
using SINGA.Models;
using SINGA.Repositories;
using SINGA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINGA.Enums;
using Microsoft.Extensions.Options;
using SINGA.Controllers;

namespace SINGA.Services
{
    public interface ICatalogosService
    {
        Task<List<CatalogoDTO>> ObtenerMeses();
    }

    public class CatalogosService : ICatalogosService
    {
        private readonly ICatalogosRepository catalogosRepo;
        private readonly IMapper mapper;

        public CatalogosService(ICatalogosRepository catalogosRepo, IMapper mapper)
        {
            this.catalogosRepo = catalogosRepo;
            this.mapper = mapper;
        }

        public async Task<List<CatalogoDTO>> ObtenerMeses()
        {
            var meses = mapper.Map<List<CatalogoDTO>>(await catalogosRepo.ObtenerMeses());
            return meses;
        }
    }
}
