import { CuentasContables } from "./cuentascontables";

export interface ListaCuentasContables {
    pagina: number;
    rows: number;
    numpaginas: number;
    cuentasContables: CuentasContables[];
}
