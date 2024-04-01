using AutoMapper;
using SINGA.Controllers;
using SINGA.DTOs;
using SINGA.Models;
using SINGA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace SINGA.Services
{
    public interface IConsultaService
    {
        //Task<ListaEvaluacionDTO> GetListaEvaluacion(ParamDashboardDTO param, ListaEvaluacionDTO listaEvaluacion);
    }

    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _ConsultaRepo;
        private readonly IMapper _mapper;

        public ConsultaService(IConsultaRepository ConsultaRepo, IMapper mapper)
        {
            _ConsultaRepo = ConsultaRepo;
            _mapper = mapper;
        }

        //public async Task<ListaEvaluacionDTO> GetListaEvaluacion(ParamDashboardDTO param, ListaEvaluacionDTO listaEvaluacion)
        //{
        //    listaEvaluacion.Rows = await _EvaluacionRepo.ContarEvaluaciones(param);
        //    if (listaEvaluacion.Rows > 0)
        //    {
        //        listaEvaluacion.NumPaginas = (listaEvaluacion.Rows / 40);

        //        if (listaEvaluacion.Rows % 40 > 0)
        //        {
        //            listaEvaluacion.NumPaginas++;
        //        }
        //        var lista = await _EvaluacionRepo.ObtenerEvaluaciones(param.Mes, param.Anio, param.IdCliente, listaEvaluacion.Pagina, param.IdInmueble);
        //        listaEvaluacion.Evaluaciones = _mapper.Map<List<EvaluacionDTO>>(lista);
        //    }
        //    else
        //    {
        //        listaEvaluacion.Evaluaciones = new List<EvaluacionDTO>();
        //    }
        //    return listaEvaluacion;
        //}
    }
}
