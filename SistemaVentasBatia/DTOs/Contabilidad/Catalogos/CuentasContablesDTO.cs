
using Microsoft.AspNetCore.SignalR.Protocol;
using SINGA.Models.Miscelaneos;

namespace SINGA.DTOs.Contabilidad.Catalogos
{
    public class CuentasContablesDTO
    {
        public int Id { get; set; }
        public string NoCuenta { get; set; }
        public string DescripcionC { get; set; }
        public int NoCtaPadre { get; set; }
        public string CodigoAgrupador { get; set; }
        public int IdTipoCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public int IdNaturaleza { get; set; }
        public string Naturaleza { get; set; }
        public bool Estatus { get; set; }
        public bool Dimension { get; set; }
        public bool Cliente_proveedor { get; set; }
        public bool Lineanegocio { get; set; }
        public bool Tipo { get; set; }


    }
}
