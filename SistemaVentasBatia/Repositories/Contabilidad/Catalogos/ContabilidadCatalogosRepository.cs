using Dapper;
using SINGA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINGA.Models.Miscelaneos;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Data.Common;
using System.Data;
using SINGA.Models.Contabilidad.Catalogos;
using SINGA.DTOs.Contabilidad.Catalogos;

namespace SINGA.Repositories.Contabilidad.Catalogos

{
    public interface IContabilidadCatalogosRepository
    {
        Task<List<CtasContables>> ObtenerCuentasContables(int pagina);
        Task<int> ContarCuentasContables();
        Task<CuentasContablesDTO> CuentaContablesGetById(int id);
        Task InsertarCuentaContable(CtasContables servicio);
        Task ActualizarCuentaContable(CtasContables servicio);
        Task EliminarCuentaContable(int id);
        Task<bool> CambiarEstatusCuentaContable(int id);
    }

    public class ContabilidadCatalogosRepository : IContabilidadCatalogosRepository
    {
        private readonly DapperContext ctx;

        public ContabilidadCatalogosRepository(DapperContext ctx)
        {
            this.ctx = ctx;
        }

        #region :: Cuentas Contables ::
        public async Task<List<CtasContables>> ObtenerCuentasContables(int pagina)
        {
            string query = @"WITH CuentasOrganizadas AS (
    SELECT 
        ROW_NUMBER() OVER (ORDER BY id ASC) AS RowNum,
        id,
        NoCuenta,
        DescripcionC,
        NoCtaPadre,
        CodigoAgrupador,
        ti.Descripcion AS TipoCuenta,
        na.Descripcion AS Naturaleza,
        Estatus,
        Dimension,
        Cliente_Proveedor,
        LineaNegocio,
        Tipo,
        CASE 
            WHEN CHARINDEX('-', NoCuenta) = 0 THEN NoCuenta -- Cuentas Padre
            ELSE LEFT(NoCuenta, CHARINDEX('-', NoCuenta) - 1) -- Subcuentas
        END AS Orden
    FROM 
        tb_cuentas_contables cc  
        INNER JOIN tb_tipo_cuenta ti ON ti.IdTipoCuenta = cc.IdTipoCuenta 
        INNER JOIN tb_naturaleza na ON na.IdNaturaleza = cc.IdNaturaleza
)
, FiltradoCuentas AS (
    SELECT 
        co.*,
        ROW_NUMBER() OVER (ORDER BY Orden, LEN(NoCuenta), NoCuenta) AS RowNumFiltrado
    FROM 
        CuentasOrganizadas co
)
SELECT 
    fc.*
FROM 
    FiltradoCuentas fc
WHERE 
    fc.RowNumFiltrado >= ((@pagina - 1) * 10) + 1
    AND fc.RowNumFiltrado <= (@pagina * 10)
ORDER BY 
    fc.Orden,
    fc.RowNumFiltrado
";
            var listaCuentaCon = new List<CtasContables>();
            try
            {
                using var connection = ctx.CreateConnection();
                listaCuentaCon = (await connection.QueryAsync<CtasContables>(query, new { pagina })).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return listaCuentaCon;
        }
        public async Task<int> ContarCuentasContables()
        {
            var query = @"SELECT count(*) Rows
                          FROM tb_cuentas_contables";
            var rows = 0;

            try
            {
                using var connection = ctx.CreateConnection();
                rows = await connection.QuerySingleAsync<int>(query);
            }
            catch (Exception)
            {
                throw;
            }

            return rows;
        }
        public async Task<CuentasContablesDTO> CuentaContablesGetById(int id)
        {
            var query = @"Select cc.id,cc.NoCuenta,cc.DescripcionC,cc.NoCtaPadre,cc.CodigoAgrupador,
                          ti.IdTipoCuenta,ti.Descripcion,na.IdNaturaleza,na.Descripcion,cc.Estatus,cc.Dimension,cc.Cliente_Proveedor,cc.LineaNegocio,cc.Tipo
                          FROM tb_cuentas_contables cc 
                          INNER JOIN tb_tipo_cuenta ti on ti.IdTipoCuenta = cc.IdTipoCuenta
                          INNER JOIN tb_naturaleza na on na.IdNaturaleza = cc.IdNaturaleza
                          where cc.id = @id";

            var servicio = new CuentasContablesDTO();

            try
            {
                using var connection = ctx.CreateConnection();
                servicio = await connection.QueryFirstAsync<CuentasContablesDTO>(query, new { id });
            }
            catch (Exception)
            {
                throw;
            }
            return servicio;
        }
        public async Task InsertarCuentaContable(CtasContables servicio)
        {
            string query = @"INSERT INTO tb_cuentas_contables 
                          (
                           NoCuenta,
                           DescripcionC,
                           NoCtaPadre,
                           CodigoAgrupador,
                           IdTipoCuenta,
                           IdNaturaleza,
                           Estatus,
                           Dimension,
                           Cliente_Proveedor,
                           LineaNegocio,
                           Tipo
                           )                           
                           VALUES
                           (
                           @noCuenta,
                           @descripcionC,
                           @noCtaPadre,
                           @codigoAgrupador,
                           @idTipoCuenta,
                           @idNaturaleza,
                           @estatus,
                           @dimension,
                           @cliente_proveedor,
                           @lineanegocio,
                           @tipo
                           )";
            try
            {
                using var connection = ctx.CreateConnection();
                await connection.ExecuteAsync(query, servicio);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task ActualizarCuentaContable(CtasContables servicio)
        {

            string query = @"
                           UPDATE tb_cuentas_contables
                           SET 
                           NoCuenta= @noCuenta,
                           DescripcionC=@descripcionC,
                           NoCtaPadre= @noCtaPadre,
                           CodigoAgrupador=@codigoAgrupador,
                           IdTipoCuenta=@idTipoCuenta,
                           IdNaturaleza=@idNaturaleza,
                           Estatus=@estatus,
                           Dimension = @dimension,
                           Cliente_Proveedor = @cliente_proveedor,
                           LineaNegocio = @lineanegocio,
                           Tipo = @tipo
                           WHERE id= @id";
            try
            {
                using var connection = ctx.CreateConnection();
                await connection.ExecuteAsync(query, servicio);
            }
            catch (Exception)
            {
                throw;
            }


        }
        public async Task EliminarCuentaContable(int id)
        {
            string query = @"DELETE FROM tb_cuentas_contables WHERE id = @id";

            try
            {
                using var connection = ctx.CreateConnection();
                await connection.ExecuteAsync(query, new { id });
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> CambiarEstatusCuentaContable(int id)
        {
            string query = @" UPDATE tb_cuentas_contables
                           SET estatus=0 WHERE id = @id";
            bool result;
            try
            {
                using var connection = ctx.CreateConnection();
                result = await connection.ExecuteScalarAsync<bool>(query, new { id });
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        #endregion


    }


}
