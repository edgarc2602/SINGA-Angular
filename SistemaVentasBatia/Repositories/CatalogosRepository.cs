using Dapper;
using SINGA.Context;
using SINGA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINGA.Models.Miscelaneos;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace SINGA.Repositories
{
    public interface ICatalogosRepository
    {
        Task<List<Catalogo>> ObtenerMeses();
        Task<List<Catalogo>> ObtenerNaturaleza();
        Task<List<Catalogo>> ObtenerTipoCuenta();
        Task<List<Catalogo>> ObtenerCtasPadres();
    }

    public class CatalogosRepository : ICatalogosRepository
    {
        private readonly DapperContext ctx;

        public CatalogosRepository(DapperContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<List<Catalogo>> ObtenerMeses()
        {
            var query = @"
SELECT 
id_mes Id,
descripcion Descripcion
From tb_mes
";
            var meses = new List<Catalogo>();
            try

            {
                using var connection = ctx.CreateConnection();
                meses = (await connection.QueryAsync<Catalogo>(query)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return meses;
        }
        public async Task<List<Catalogo>> ObtenerNaturaleza()
        {
            var query = @"SELECT IdNaturaleza Id, Descripcion Descripcion  FROM tb_naturaleza";


            var naturaleza = new List<Catalogo>();

            try
            {
                using var connection = ctx.CreateConnection();
                naturaleza = (await connection.QueryAsync<Catalogo>(query)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return naturaleza;
        }
        public async Task<List<Catalogo>> ObtenerTipoCuenta()
        {
            var query = @"SELECT IdTipoCuenta Id, Descripcion Descripcion  FROM tb_tipo_cuenta";


            var naturaleza = new List<Catalogo>();

            try
            {
                using var connection = ctx.CreateConnection();
                naturaleza = (await connection.QueryAsync<Catalogo>(query)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return naturaleza;
        }
        public async Task<List<Catalogo>> ObtenerCtasPadres()
        {
            var query = @"SELECT NoCuenta Id, DescripcionC Descripcion from tb_cuentas_contables where Dimension = 1";


            var ctapadre = new List<Catalogo>();

            try
            {
                using var connection = ctx.CreateConnection();
                ctapadre = (await connection.QueryAsync<Catalogo>(query)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ctapadre;
        }


    }
}
