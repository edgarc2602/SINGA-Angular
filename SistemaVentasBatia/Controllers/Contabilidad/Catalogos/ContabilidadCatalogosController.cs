﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Configuration;
using SINGA.Models.Miscelaneos;
using SINGA.Models.Contabilidad.Catalogos;
using SINGA.Services.Contabilidad.Catalogos;
using SINGA.DTOs.Contabilidad.Catalogos;

namespace SINGA.Controllers.Contabilidad.Catalogos
{


    [ApiController]
    [Route("api/[controller]")]
    public class ContabilidadCatalogosController : ControllerBase
    {

        private readonly IContabilidadCatalogosService contabilidadCatalogosSvc;

        public ContabilidadCatalogosController(IContabilidadCatalogosService service)
        {
            contabilidadCatalogosSvc = service;
        }
        #region :: Cuentas Contables ::
        [HttpGet("[action]/{pagina}")]
        public async Task<ActionResult<ListaCuentasContablesDTO>> ObtenerCuentasContables(int pagina = 1)
        {
            var ListaCuentasContablesVM = new ListaCuentasContablesDTO
            {
                Pagina = pagina
            };


            await contabilidadCatalogosSvc.ObtenerListaCuentasContables(ListaCuentasContablesVM);
            return ListaCuentasContablesVM;
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<CuentasContablesDTO>> CuentaContablesGetById(int id)
        {

            var ctaCon = await contabilidadCatalogosSvc.CuentaContablesGetById(id);
            return ctaCon;
        }
        [HttpPost("[action]")]
        public async Task InsertarCuentaContable(CtasContables servicio)
        {
            await contabilidadCatalogosSvc.InsertarCuentaContable(servicio);

        }
        [HttpPost("[action]")]
        public async Task ActualizarCuentaContable(CtasContables servicio)
        {
            await contabilidadCatalogosSvc.ActualizarCuentaContable(servicio);

        }
        [HttpDelete("[action]/{id}")]
        public async Task EliminarCuentaContable(int id)
        {
            await contabilidadCatalogosSvc.EliminarCuentaContable(id);

        }
        [HttpPut("[action]")]
        public async Task<ActionResult<bool>> CambiarEstatusCuentaContable([FromBody] int id)
        {
            return await contabilidadCatalogosSvc.CambiarEstatusCuentaContable(id);

        }
        #endregion
    }


}
