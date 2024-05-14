import { Component, OnInit, Inject, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { fadeInOut } from 'src/app/fade-in-out';
import { HttpClient } from '@angular/common/http';
import { StoreUser } from 'src/app/stores/StoreUser';
import { ListaCuentasContables } from '../../models/ListaCuentasContables';
import { CuentaContablesAgregarWidget } from '../../widgets/cuentascontables/cuentacontableagregar.widget';
import { ToastWidget } from '../../widgets/toast/toast.widget';
import { ConfirmacionWidget } from '../../widgets/confirmacion/confirmacion.widget';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


declare var bootstrap: any;
@Component({
    selector: 'dashboard-comp',
    templateUrl: './cuentascontables.component.html',
    animations: [fadeInOut],

})

export class CuentasContablesComponent {
    @ViewChild(ConfirmacionWidget, { static: false }) estatus: ConfirmacionWidget;
    @ViewChild(CuentaContablesAgregarWidget, { static: false }) CtaConAgregar: CuentaContablesAgregarWidget;
    @ViewChild(ToastWidget, { static: false }) toastWidget: ToastWidget;

    estatuscta: boolean = false;
    id: number = 0;
    lerr: any = {};
    lctacon: ListaCuentasContables = {
        pagina:1,rows:0,numpaginas:0,cuentasContables:[]
    }

    constructor(@Inject('BASE_URL') private url: string, private http: HttpClient, public user: StoreUser) {
        this.lctacon.cuentasContables = [];
        http.get<ListaCuentasContables>(`${url}api/ContabilidadCatalogos/ObtenerCuentasContables/${this.lctacon.pagina}`).subscribe(response => {
            setTimeout(() => {
                this.lctacon = response;
               
            }, 300);
        })
        
    }
    getCtaCon() {
        this.http.get<ListaCuentasContables>(`${this.url}api/ContabilidadCatalogos/ObtenerCuentasContables/${this.lctacon.pagina}`).subscribe(response => {
            this.lctacon = response;
           
        }, err => console.log(err));
    }
    cambiarestatusctacon(id: number) {
        this.estatuscta = true; 
        if (this.estatuscta = true) {
            this.http.put<boolean>(`${this.url}api/ContabilidadCatalogos/CambiarEstatusCuentaContable`, id).subscribe(response => {
                    this.getCtaCon();
                    this.okToast('Cotizaci\u00F3n ' + id + ' desactivada');
                }, err => {
                    console.log(err);
                    this.errorToast('Ocurrió un error')
                });
            } else {
            this.http.put<boolean>(`${this.url}api/ContabilidadCatalogos/CambiarEstatusCuentaContable`,id).subscribe(response => {
                    this.getCtaCon();
                    this.okToast('Cotizaci\u00F3n ' + id + ' activada');
                }, err => {
                    console.log(err);
                    this.errorToast('Ocurrió un error');
                });
            }
        
    }
    eliCtaCon(id: number) {
        this.http.delete(`${this.url}api/ContabilidadCatalogos/EliminarCuentaContable/${id}`).subscribe(response => {
            this.okToast('Servicio eliminado');
            this.getCtaCon();

        }, err => {
            console.log(err);
            this.errorToast('Ocurri\u00F3 un error')
        });
    }
    openValida(tipo: string, mensaje: string, dato1?: any, dato2?: any) {
        this.id = dato1;
        this.estatus.titulo = "Confirmaci\u00F3n";
        this.estatus.mensaje = mensaje;
        this.estatus.open(tipo)
    }

    openNew(id: number) {
        this.CtaConAgregar.open(id);
    }

    ferr(nm: string) {
        let fld = this.lerr[nm];
        if (fld)
            return true;
        else
            return false;
    }

    terr(nm: string) {
        let fld = this.lerr[nm];
        let msg: string = fld.map((x: string) => "-" + x);
        return msg;
    }
    okToast(message: string) {
        this.toastWidget.errMessage = message;
        this.toastWidget.isErr = false;
        this.toastWidget.open();
    }
    errorToast(message: string) {
        this.toastWidget.isErr = true;
        this.toastWidget.errMessage = message;
        this.toastWidget.open();
    }
    matPagina(event) {
        this.lctacon.pagina = event;
        this.getCtaCon();
    }
    confirmacionEvent(event) {
        switch (event) {
            case 'CambiarEstatusCtaCon':
                this.cambiarestatusctacon(this.id);
            break;
            case 'EliminaCtaCon':
                this.eliCtaCon(this.id);
            break;
            default:
                this.errorToast('Ocurri\u00F3 un error');
            break;
        } 
    }
}