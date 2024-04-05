using System.Collections.Generic;

namespace SINGA.Models
{
    public class MenuArea
    {
        public int IdArea { get; set; }
        public string AreaNombre { get; set; }
        public string AreaDescripcion { get; set; }
        public int AreaPosicion { get; set; }
        public bool AreaEstatus{ get; set; }
        public string AreaIcono { get; set; }
        public List<MenuAreaProceso> MenuAreaProceso { get; set; }
    }
}
