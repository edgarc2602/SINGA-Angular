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
using System.Net;

namespace SINGA.Services
{
    public interface IContabilidadCatalogosService
    {
        #region :: Referencias Cuentas Contables ::
        Task ObtenerListaCuentasContables(ListaCuentasContablesDTO ListaCuentasContablesVM);
        Task<CuentasContablesDTO> CuentaContablesGetById(int id);
        Task InsertarCuentaContable(CtasContables servicio);
        Task ActualizarCuentaContable(CtasContables servicio);
        Task EliminarCuentaContable(int id);
        Task<bool> CambiarEstatusCuentaContable(int id);
        #endregion
    }

    public class ContabilidadCatalogosService : IContabilidadCatalogosService
    {
        private readonly IContabilidadCatalogosRepository contabilidadcatalogosRepo;
        private readonly IMapper mapper;


        public ContabilidadCatalogosService(IContabilidadCatalogosRepository contabilidadcatalogosRepo, IMapper mapper)
        {
            this.contabilidadcatalogosRepo = contabilidadcatalogosRepo;
            this.mapper = mapper;
        }
        #region :: Cuentas Contables ::
        public async Task ObtenerListaCuentasContables(ListaCuentasContablesDTO ListaCuentasContablesVM)
        {
            ListaCuentasContablesVM.Rows = await contabilidadcatalogosRepo.ContarCuentasContables();

            if (ListaCuentasContablesVM.Rows > 0)
            {
                ListaCuentasContablesVM.NumPaginas = (ListaCuentasContablesVM.Rows / 10);

                if (ListaCuentasContablesVM.Rows % 10 > 0)
                {
                    ListaCuentasContablesVM.NumPaginas++;
                }

                var lista = await contabilidadcatalogosRepo.ObtenerCuentasContables(ListaCuentasContablesVM.Pagina);
                ListaCuentasContablesVM.CuentasContables = lista.Select(c =>
                    new CuentasContablesDTO
                    {
                        id = c.id,
                        noCuenta = c.noCuenta,
                        descripcionC = c.descripcionC,
                        noCtaPadre = c.noCtaPadre,
                        codigoAgrupador = c.codigoAgrupador,
                        TipoCuenta = c.TipoCuenta,
                        Naturaleza = c.Naturaleza,
                        estatus = c.estatus,
                        dimension = c.dimension,
                        cliente_proveedor = c.cliente_Proveedor,
                        lineanegocio = c.lineanegocio,
                        tipo = c.tipo
                        
                    }).ToList();
            }
            else
            {
                ListaCuentasContablesVM.CuentasContables = new List<CuentasContablesDTO>();
            }
            
        }
        public async Task<CuentasContablesDTO> CuentaContablesGetById(int id)
        {
            var servicio = new CuentasContablesDTO();

            servicio = mapper.Map<CuentasContablesDTO>(await contabilidadcatalogosRepo.CuentaContablesGetById(id));
            return servicio;
        }
        public async Task InsertarCuentaContable(CtasContables servicio)
        {
         
            await contabilidadcatalogosRepo.InsertarCuentaContable(servicio);
        }

        public async Task ActualizarCuentaContable (CtasContables servicio)
        {
            
            await contabilidadcatalogosRepo.ActualizarCuentaContable(servicio);
        }
        public async Task EliminarCuentaContable(int id)
        {
            await contabilidadcatalogosRepo.EliminarCuentaContable(id);
        }
        public async Task<bool> CambiarEstatusCuentaContable(int id)
        {
            return await contabilidadcatalogosRepo.CambiarEstatusCuentaContable(id);
        }
        
        #endregion
    }
}
