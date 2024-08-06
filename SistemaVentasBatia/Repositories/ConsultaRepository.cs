using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using SINGA.Context;
using SINGA.DTOs;
using SINGA.Models.Miscelaneos;
using SINGA.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace SINGA.Repositories
{
    public interface IConsultaRepository
    {
        //Task<int> ContarEvaluaciones(ParamDashboardDTO param);
    }

    public class ConsultaRepository : IConsultaRepository
    {
        //private readonly DapperContext _ctx;

        //public ConsultaRepository(DapperContext context)
        //{
        //    _ctx = context;
        //}

//        public async Task<int> ContarEvaluaciones(ParamDashboardDTO param)
//        {
//            string query = @"
//SELECT
//count(a.id_campania) Rows 
//from tb_encuesta_registro a
//where a.id_status = 1
//and ISNULL(NULLIF(@IdInmueble,0), a.id_inmueble) = a.id_inmueble
//AND MONTH(a.fecha) = @Mes
//AND YEAR(a.fecha) = @Anio
//AND a.id_cliente = @IdCliente
//";
//            var numrows = 0;
//            try
//            {
//                using var connection = _ctx.CreateConnection();
//                numrows = await connection.QuerySingleAsync<int>(query, param);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return numrows;
//        }

    }
}
