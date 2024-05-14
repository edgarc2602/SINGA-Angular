import { Naturaleza } from './naturaleza'
import { TipoCuenta } from './tipocuenta';
export interface CuentasContables {
    id: number;
    noCuenta: string;
    descripcionC: string;
    noCtaPadre: number;
    codigoAgrupador: string;
    idTipoCuenta: number;
    TipoCuenta: string;
    idNaturaleza: number;
    Naturaleza: string;
    estatus: boolean;
    dimension: boolean;
    cliente_proveedor: boolean;
    lineanegocio: boolean;
    tipo: boolean;
}