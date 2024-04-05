import { MenuAreaProceso } from "./menuareaproceso";

export interface MenuArea {
    idArea: number;
    areaNombre: string;
    areaDescripcion: string;
    areaPosicion: number;
    areaEstatus: boolean;
    areaIcono: string;
    menuAreaProceso: MenuAreaProceso[];
}