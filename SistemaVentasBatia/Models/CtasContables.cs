using SINGA.Enums;

namespace SINGA.Models
{
    public class CtasContables
    {
        public int id { get; set; }
        public string noCuenta { get; set; }
        public string descripcionC { get; set; }
        public int noCtaPadre { get; set; }
        public string codigoAgrupador { get; set; }
        public int idTipoCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public int idNaturaleza { get; set; }
        public string Naturaleza { get; set; }
        public bool estatus { get; set; }
        public bool dimension { get; set; }
        public bool cliente_Proveedor { get; set; }
        public bool lineanegocio { get; set; }
        public bool tipo { get; set; }
    }
}
