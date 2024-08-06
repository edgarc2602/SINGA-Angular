import { Component, Inject, OnChanges, Input, SimpleChanges, Output, EventEmitter, ViewChild, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Catalogo } from 'src/app/models/catalogo';
import { ItemN } from 'src/app/models/item';

import { StoreUser } from 'src/app/stores/StoreUser';
import { CuentasContables } from 'src/app/models/Contabilidad/Catalogos/cuentascontables';
import { ToastWidget } from 'src/app/widgets/toast/toast.widget';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
declare var bootstrap: any;

@Component({
    selector: 'cuentacontableagregar-widget',
    templateUrl: './cuentacontableagregar.widget.html',
})

export class CuentaContablesAgregarWidget {
    lerr: any = {};
    Natu: Catalogo[] = [];
    TipCta: Catalogo[] = [];
    Ctapadre: Catalogo[] = [];
    validacion: boolean = false;
    existente: boolean = false;
    cuenta: number = 0;
    servicio: string = '';
    txtctapadre: boolean = false;
    chkestatus: boolean = false;
    chkdimension: boolean = false;
    chkctapadre: boolean = false;


    @Output('CtaCon') sendEvent = new EventEmitter<any>();
    @Output('returnModal') returnModal = new EventEmitter<boolean>();
    model: CuentasContables = {} as CuentasContables;
    @ViewChild(ToastWidget, { static: false }) toastWidget: ToastWidget;
    constructor(@Inject('BASE_URL') private url: string, private http: HttpClient, private sinU: StoreUser) { }
    
    imports: [MatSlideToggleModule];

    lista() {
        this.http.get<Catalogo[]>(`${this.url}api/catalogo/GetNaturaleza`).subscribe(response => {
            this.Natu = response;
        }, err => console.log(err));

        this.http.get<Catalogo[]>(`${this.url}api/catalogo/GetTipoCuenta`).subscribe(response => {
            this.TipCta = response;
        }, err => console.log(err));

        this.http.get<Catalogo[]>(`${this.url}api/catalogo/GetCtasPadres`).subscribe(response => {
            this.Ctapadre = response;
        }, err => console.log(err));
    }

    //AgregarCuenta(id: number) {
    //    this.serAdd.open(id, this.model.idCotizacion);
    //}

    existe(id: number) {
        this.http.get<CuentasContables>(`${this.url}api/ContabilidadCatalogos/CuentaContablesGetById/${id}`).subscribe(response => {
            this.model = response;
            this.chkctapadre = true;
            this.HabilitaTexbox();
        }, err => console.log(err));
    }
    //guarda() {
    //    this.http.post<Material>(`${this.url}api/${this.tipo}`, this.model).subscribe(response => {
    //        this.close();
    //        this.sendEvent.emit(2);
    //    }, err => console.log(err));
    //    let docModal = document.getElementById('modalLimpiezaMaterialOperario');
    //    let myModal = bootstrap.Modal.getOrCreateInstance(docModal);
    //    myModal.show();
    //}
    guarda() {
        this.quitarFocoDeElementos();
        this.lerr = {};
        if (this.valida()) {
            if (!this.validactapadreexistente()) {
                if (this.model.id == 0) {
                    this.http.post<CuentasContables>(`${this.url}api/ContabilidadCatalogos/insertarcuentacontable`, this.model).subscribe(response => {
                        this.close();
                        this.sendEvent.emit(2);
                        this.okToast('Cuenta contable agregado');
                    }, err => {
                        console.log(err);
                        if (err.error) {
                            if (err.error.errors) {
                                this.lerr = err.error.errors;
                            }
                        }
                        this.errorToast('Ocurri\u00F3 un error')
                    });
                }
                if (this.model.id >= 1) {
                    this.http.post<CuentasContables>(`${this.url}api/ContabilidadCatalogos/actualizarcuentacontable`, this.model).subscribe(response => {

                        this.close();
                        this.sendEvent.emit(2);
                        console.log(response);
                        this.okToast('Cuenta contable actualizado');
                    }, err => {
                        console.log(err);
                        if (err.error) {
                            if (err.error.errors) {
                                this.lerr = err.error.errors;
                            }
                        }
                        this.errorToast('Ocurri\u00F3 un error');
                    });
                }
            }
            else {
                this.lerr['noCuentaexistente'] = ['Numero de Cuenta ya existe'];
                this.validacion = false;
            }
           
        }
    }
    validactapadreexistente() {
        this.existente = false;

        if (this.model.id == 0) {
            if (this.model.dimension) { 
            this.cuenta = parseInt(this.model.noCuenta);
            for (let cta = 0; cta < this.Ctapadre.length; cta++)
                if (this.Ctapadre[cta].id == this.cuenta) { // Comparar el ID con this.model.nocuenta
                    this.existente = true; // Establecer validacion en true si hay coincidencia
                    break; // Salir del bucle una vez que se haya encontrado una coincidencia
                }
            return this.existente;
            }
        }
        else {
            return this.existente;
        }
    }
        valida() {
            this.validacion = true;
            if (this.model.noCuenta == '') {
                this.lerr['noCuenta'] = ['Numero de Cuenta es obligatorio'];
                this.validacion = false;
            }
            if (this.model.descripcionC == '') {
                this.lerr['descripcionC'] = ['Descripcion es obligatorio'];
                this.validacion = false;
            }
            if (!this.model.dimension) {
                if (this.model.noCtaPadre == 0) {
                    this.lerr['noCtaPadre'] = ['Seleccione una cuenta padre'];
                    this.validacion = false;
                }
            }
            //if (this.model.noCtaPadre == '') {
            //    this.lerr['noCtaPadre'] = ['Cuenta Padre es obligatorio'];
            //    this.validacion = false;
            //}
            if (this.model.codigoAgrupador == '') {
                this.lerr['codigoAgrupador'] = ['Codigo Agrupador es obligatorio'];
                this.validacion = false;
            }
            if (this.model.idTipoCuenta == 0) {
                this.lerr['idTipoCuenta'] = ['Seleccione el tipo de cuenta'];
                this.validacion = false;
            }
            if (this.model.idNaturaleza == 0) {
                this.lerr['idNaturaleza'] = ['Seleccione la naturaleza'];
                this.validacion = false;
            }
            return this.validacion;
        }
    
    quitarFocoDeElementos(): void {
        const elementos = document.querySelectorAll('button, input[type="text"]');
        elementos.forEach((elemento: HTMLElement) => {
            elemento.blur();
        });
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
    nuevo() {
        let fec: Date = new Date();
        this.txtctapadre = false;
        this.chkestatus = false;
        this.chkdimension = false;
        this.model = {
            id:0,
            noCuenta: '',
            descripcionC: '',
            noCtaPadre: 0,
            codigoAgrupador: '',
            idTipoCuenta: 0,
            TipoCuenta: '',
            idNaturaleza:0,
            Naturaleza: '',
            estatus: false,
            dimension: false,
            cliente_proveedor: false,
            lineanegocio: false,
            tipo: false
        };
    }
    actualizarCampo2() {
        if (this.model.noCtaPadre != 0) {
            this.model.noCuenta = this.model.noCtaPadre + '-'; // Completa automáticamente el campo2 con lo que se escribe en campo1
        }
        else {
            this.model.noCuenta = '';
        }
    }
    open(id: number) {
        this.lerr = {};
        this.chkctapadre = false;
        this.lista();
        if (id == 0) {
            this.nuevo();
        } else {
            this.nuevo();
            this.existe(id);
        }
        let docModal = document.getElementById('modalcuentascontables');
        let myModal = bootstrap.Modal.getOrCreateInstance(docModal);
        myModal.show();
    }

    close() {
        let docModal = document.getElementById('modalcuentascontables');
        let myModal = bootstrap.Modal.getOrCreateInstance(docModal);
        myModal.hide();
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
    HabilitaTexbox() {
        if (this.model.dimension) {
            if (this.model.id == 0) {
                this.model.estatus = true;
                this.model.noCuenta = '';
            }
            this.Habilitadim();                                                                       
            this.txtctapadre = true;
            this.chkestatus = true;
            this.chkdimension = true;
            this.model.noCtaPadre = 0;
            
        }
        else {
            
            this.txtctapadre = false;
            if (this.model.id == 0) {
                this.model.noCtaPadre = 0;
                this.model.estatus = false;
            }
            this.chkestatus = false;
            this.Habilitadim();
        }
    }
    Habilitadim() {
        if (this.model.estatus) {
            this.chkdimension = true;
            this.model.tipo = false;
            this.model.lineanegocio = false;
            this.model.cliente_proveedor = false;
        }
        else {
            this.chkdimension = false;
        }
    }
}