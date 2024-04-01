import { Component, Inject, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { fadeInOut } from 'src/app/fade-in-out';
import { StoreUser } from 'src/app/stores/StoreUser';
import { Catalogo } from 'src/app/models/catalogo'
import { ConfirmaWidget } from '../../widgets/confirma/confirma.widget';
import Swal from 'sweetalert2';

@Component({
    selector: 'consulta-comp',
    templateUrl: './consulta.component.html',
    animations: [fadeInOut],
})
export class ConsultaComponent {

    @ViewChild(ConfirmaWidget, { static: false }) confirma: ConfirmaWidget;
    isLoading: boolean = false;

    constructor(@Inject('BASE_URL') private url: string, private http: HttpClient, public user: StoreUser) {
        //http.get<Catalogo[]>(`${url}api/catalogo/GetPrioridadTK`).subscribe(response => {
        //    this.prioridad = response;
        //})
    }

    ngOnInit() {
    //    this.obtenerTickets(1);
    }





    //muevePagina(event) {
    //    this.quitarFocoDeElementos();
    //    this.model.pagina = event;
    //    this.obtenerTickets(1);
    //}


    //quitarFocoDeElementos(): void {
    //    const elementos = document.querySelectorAll('button, input[type="text"]');
    //    elementos.forEach((elemento: HTMLElement) => {
    //        elemento.blur();
    //    });
    //}
}
