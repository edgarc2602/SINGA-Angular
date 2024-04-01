import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import * as Highcharts from 'highcharts';
import { fadeInOut } from 'src/app/fade-in-out';
import { HttpClient } from '@angular/common/http';
import { StoreUser } from 'src/app/stores/StoreUser';
import { Catalogo } from 'src/app/models/catalogo';
import Swal from 'sweetalert2';
import accessibility from 'highcharts/modules/accessibility';

@Component({
    selector: 'dashboard-comp',
    templateUrl: './dashboard.component.html',
    animations: [fadeInOut],
})
export class DashboardComponent implements OnInit {

    isLoading: boolean = false;

    //@ViewChild(/*EvaluacionWidget*/, { static: false }) EvaWid: EvaluacionWidget;

    
    constructor(@Inject('BASE_URL') private url: string, private http: HttpClient, public user: StoreUser) {
        //http.get<Catalogo[]>(`${url}api/catalogo/obtenermeses`).subscribe(response => {
        //    this.mesesc = response;
        //})
        
    }

    ngOnInit(): void {
        accessibility(Highcharts);
    }



    //graficaAsistenciaMes(sucursaln: string) {
    //    let container: HTMLElement = document.getElementById('GAM');
    //    let totalAsistencia = 0;
    //    this.dashboard.asistenciaMes.forEach(dia => {
    //        totalAsistencia += dia.asistencia;
    //    });
    //    const seriesData = this.dashboard.asistenciaMes.map(dia => {
    //        return {
    //            name: dia.fecha,
    //            y: dia.asistencia
    //        };
    //    });
    //    const totalSubtitle = `Total: ${totalAsistencia}`;
    //    Highcharts.chart(container, {
    //        chart: {
    //            type: 'column'
    //        },
    //        title: {

    //            text: null/*'Asistencia mensual'*/
    //        },
    //        subtitle: {
    //            text: totalSubtitle,
    //            align: 'center',
    //            style: {
    //                fontSize: '16px'
    //            }
    //        },
    //        plotOptions: {
    //            column: {
    //                color: '#5094fc'
    //            }
    //        },
    //        xAxis: {
    //            categories: this.dashboard.asistenciaMes.map(dia => dia.fecha.toString()),
    //            crosshair: true
    //        },
    //        yAxis: {
    //            allowDecimals: false,
    //            min: 0,
    //            title: null
    //        },
    //        tooltip: {
    //            headerFormat: '<span style="font-size:10px">Dia:{point.key}</span><table>',
    //            pointFormat: '<tr><td style="color:{series.color};padding:0">Total: </td>' +
    //                '<td style="padding:0"><b>{point.y:.0f}</b></td></tr>',
    //            footerFormat: '</table>',
    //            shared: true,
    //            useHTML: true
    //        },
    //        series: [{
    //            type: 'column',
    //            name: 'Dias',
    //            data: seriesData
    //        }],
    //        credits: {
    //            enabled: false
    //        }
    //    });
    //}
}