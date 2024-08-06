using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace SINGA.Models.MenuLateral
{
    public class MenuAreaProceso
    {
        public int IdProceso { get; set; }
        public string Proceso { get; set; }
        public List<MenuAreaProcesoFormulario> MenuAreaProcesoFormulario { get; set; }
    }
}
