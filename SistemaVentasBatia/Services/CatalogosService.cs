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
using System.Runtime.CompilerServices;

namespace SINGA.Services
{
    public interface ICatalogosService
    {
        Task<List<CatalogoDTO>> ObtenerMeses();
        Task<List<CatalogoDTO>> ObtenerNaturaleza();
        Task<List<CatalogoDTO>> ObtenerTipoCuenta();
        Task<List<CatalogoDTO>> ObtenerCtasPadres();
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
        public async Task<List<CatalogoDTO>> ObtenerNaturaleza()
        {
            var naturaleza = mapper.Map<List<CatalogoDTO>>(await catalogosRepo.ObtenerNaturaleza());

            return naturaleza;
        }
        public async Task<List<CatalogoDTO>> ObtenerTipoCuenta()
        {
            var tipocuenta = mapper.Map<List<CatalogoDTO>>(await catalogosRepo.ObtenerTipoCuenta());
            return tipocuenta;
        }
        public async Task<List<CatalogoDTO>> ObtenerCtasPadres()
        {
            var ctapadre = mapper.Map<List<CatalogoDTO>>(await catalogosRepo.ObtenerCtasPadres());
            return ctapadre;
        }
    }

}
