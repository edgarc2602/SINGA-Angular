using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SINGA.Enums;

namespace SINGA.DTOs
{
    public class AlertaViewModel
    {
        public string Descripcion { get; set; }

        public TipoAlerta IdTipoAlerta { get; set; }
    }
}
