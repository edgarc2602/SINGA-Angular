using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Configuration;
using SINGA.DTOs;
using SINGA.Services;


namespace SINGA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogosService logic;

        public CatalogoController(ICatalogosService service)
        {
            logic = service;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<CatalogoDTO>> ObtenerMeses()
        {
            return await logic.ObtenerMeses();
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<CatalogoDTO>> GetNaturaleza()
        {
            return await logic.ObtenerNaturaleza();
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<CatalogoDTO>> GetTipoCuenta()
        {
            return await logic.ObtenerTipoCuenta();
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<CatalogoDTO>> GetCtasPadres()
        {
            return await logic.ObtenerCtasPadres();
        }
    }
}