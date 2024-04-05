import { MenuAreaProcesoFormulario } from "./menuareaprocesoformulario";

export interface MenuAreaProceso {
    idProceso: number;
    proceso: string;
    menuAreaProcesoFormulario: MenuAreaProcesoFormulario[];
}