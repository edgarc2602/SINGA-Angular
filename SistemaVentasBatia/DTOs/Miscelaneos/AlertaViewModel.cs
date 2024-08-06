using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINGA.Models.Miscelaneos;

namespace SINGA.DTOs.Miscelaneos
{
    public class AlertaViewModel
    {
        public string Descripcion { get; set; }

        public TipoAlerta IdTipoAlerta { get; set; }
    }
}
