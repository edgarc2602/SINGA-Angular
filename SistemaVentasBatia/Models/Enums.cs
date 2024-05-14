using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SINGA.Enums
{
    [Flags]
    public enum Documento
    {
        RFC = 1,
        PoderNotarial = 2
    }


    public enum Servicio
    {
        Mantenimiento = 1,
        Limpieza = 2,
        Sanitización = 3
    }

    public enum EstatusTicket
    {
        Alta = 1,
        Recibido = 2,
        Atendido = 3,
        Cerrado = 4
    }

    public enum PrioridadTicket
    {
        Normal = 1,
        Urgente = 2
    }
    public enum TipoAlerta
    {
        Exito = 1,
        Error = 2,
        Aviso = 3,
        Info = 4
    }
    public enum TipoCuenta
    {
       Activo = 1,
       Pasivo = 2,
       Capital = 3
    }
    public enum Naturaleza
    {
        Deudor = 1,
        Acreedora = 2
    }
    public enum EstatusCtaCon
    {
        Activo = 1,
        Inactivo = 2
    }
}
