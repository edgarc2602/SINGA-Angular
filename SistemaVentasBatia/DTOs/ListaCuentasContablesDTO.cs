﻿using System.Collections.Generic;

namespace SINGA.DTOs
{
    public class ListaCuentasContablesDTO
    {
        public int Pagina { get; set; }

        public int NumPaginas { get; set; }

        public int Rows { get; set; }
        public List<CuentasContablesDTO> CuentasContables { get; set; }
    }
}
