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
using SINGA.Models.MenuLateral;

namespace SINGA.Repositories
{
    public interface IMenuRepository
    {
        Task<List<MenuArea>> ObtenerMenu();
        Task<List<MenuAreaProceso>> ObtenerProcesos(int idArea);
        Task<List<MenuAreaProcesoFormulario>> ObtenerFormularios(int idArea, int idProceso);
    }

    public class MenuRepository : IMenuRepository
    {
        private readonly DapperContext ctx;

        public MenuRepository(DapperContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<List<MenuArea>> ObtenerMenu()
        {
            string query = @"
            SELECT 
            IdArea IdArea,
            Ar_Nombre AreaNomre,
            Ar_Descripcion AreaDescripcion,
            Ar_Posicion AreaPosicion,
            Ar_Estatus AreaEstatus,
            ar_icon AreaIcono
            FROM Tbl_Area_Menu
            ";
            var listaMenu = new List<MenuArea>();
            try
            {
                using var connection = ctx.CreateConnection();
                listaMenu = (await connection.QueryAsync<MenuArea>(query)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return listaMenu;
        }
        
        public async Task<List<MenuAreaProceso>> ObtenerProcesos(int idArea)
        {
            string query = @"
            SELECT
            DISTINCT idProceso IdProceso,
            case 
            WHEN IdProceso = 1 then 'Catalogos'
            WHEN IdProceso = 2 then 'Procesos'
            WHEN IdProceso = 3 then 'Consultas'
            WHEN IdProceso = 4 then 'Reportes' 
            end
            AS Proceso
            FROM Tbl_Formularios WHERE IdArea = @idArea
            ";
            var listaMenu = new List<MenuAreaProceso>();
            try
            {
                using var connection = ctx.CreateConnection();
                listaMenu = (await connection.QueryAsync<MenuAreaProceso>(query, new { idArea })).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return listaMenu;
        }

        public async Task<List<MenuAreaProcesoFormulario>> ObtenerFormularios(int idArea, int idProceso)
        {
            string query = @"
            SELECT 
            IdForma IdForma,
            Ar_Label AreaLabel,
            Ar_Path AreaPath,
            Ar_Icono AreaIcono,
            Ar_orden AreaOrden,
            IdArea IdArea,
            IdPadre IdPadre,
            IdProceso IdProceso,
            COALESCE(Ar_Path_New, '/exclusivo') AS AreaPathNew
            FROM Tbl_Formularios WHERE IdArea = @idArea AND IdProceso = @idProceso ORDER BY AreaLabel
            ";
            var listaFormularios = new List<MenuAreaProcesoFormulario>();
            try
            {
                using var connection = ctx.CreateConnection();
                listaFormularios = (await connection.QueryAsync<MenuAreaProcesoFormulario>(query, new { idArea, idProceso})).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return listaFormularios;
        }
    }
}
