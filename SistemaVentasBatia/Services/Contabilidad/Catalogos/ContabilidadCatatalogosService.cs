using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINGA.Models.Miscelaneos;
using Microsoft.Extensions.Options;
using SINGA.Controllers;
using System.Net;
using SINGA.Models.Contabilidad.Catalogos;
using SINGA.Repositories.Contabilidad.Catalogos;
using SINGA.DTOs.Contabilidad.Catalogos;

namespace SINGA.Services.Contabilidad.Catalogos
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
                ListaCuentasContablesVM.NumPaginas = ListaCuentasContablesVM.Rows / 10;

                if (ListaCuentasContablesVM.Rows % 10 > 0)
                {
                    ListaCuentasContablesVM.NumPaginas++;
                }

                var lista = await contabilidadcatalogosRepo.ObtenerCuentasContables(ListaCuentasContablesVM.Pagina);
                ListaCuentasContablesVM.CuentasContables = lista.Select(c =>
                    new CuentasContablesDTO
                    {
                        Id = c.Id,
                        NoCuenta = c.NoCuenta,
                        DescripcionC = c.DescripcionC,
                        NoCtaPadre = c.NoCtaPadre,
                        CodigoAgrupador = c.CodigoAgrupador,
                        TipoCuenta = c.TipoCuenta,
                        Naturaleza = c.Naturaleza,
                        Estatus = c.Estatus,
                        Dimension = c.Dimension,
                        Cliente_proveedor = c.Cliente_Proveedor,
                        Lineanegocio = c.Lineanegocio,
                        Tipo = c.Tipo

                    }).ToList();
            }
            else
            {
                ListaCuentasContablesVM.CuentasContables = new List<CuentasContablesDTO>();
            }

        }
        public async Task<CuentasContablesDTO> CuentaContablesGetById(int id)
        {
            var servicio = mapper.Map<CuentasContablesDTO>(await contabilidadcatalogosRepo.CuentaContablesGetById(id));
            return servicio;
        }
        public async Task InsertarCuentaContable(CtasContables servicio)
        {

            await contabilidadcatalogosRepo.InsertarCuentaContable(servicio);
        }

        public async Task ActualizarCuentaContable(CtasContables servicio)
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
