using System.Collections.Generic;

namespace SINGA.DTOs.Miscelaneos
{
    public class ListadoMaterialDTO
    {
        public List<ListadosDTO> Listas { get; set; }
        public int Pagina { get; set; }
        public int Rows { get; set; }
        public int NumPaginas { get; internal set; }
    }
}
