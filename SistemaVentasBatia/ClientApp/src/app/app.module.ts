import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ColectivoComponent } from './colectivo/colectivo.component';
import { ColMenuComponent } from './colectivo/menu/menu.component';
import { LoginComponent } from './colectivo/login/login.component';
import { ExclusivoComponent } from './exclusivo/exclusivo.component';
import { ExMenuComponent } from './exclusivo/menu/menu.component';
import { LatMenuComponent } from './exclusivo/menu/latmenu.component';
import { PaginaWidget } from './widgets/paginador/paginador.widget';
import { ToastWidget } from './widgets/toast/toast.widget';
import { EliminaWidget } from './widgets/elimina/elimina.widget';
import { StoreUser } from './stores/StoreUser';
import { CommonModule } from '@angular/common';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashboardComponent } from './exclusivo/dashboard/dashboard.component';
import { ConfirmaWidget } from './widgets/confirma/confirma.widget';
import { ReactiveFormsModule } from '@angular/forms';
import { ConsultaComponent } from './exclusivo/consulta/consulta.component'


 

@NgModule({
    declarations: [
        AppComponent,
        ColectivoComponent,
        ColMenuComponent,
        LoginComponent,
        ExclusivoComponent,
        ExMenuComponent,
        LatMenuComponent,
        DashboardComponent,

        PaginaWidget,
        ToastWidget,
        EliminaWidget,
        ConfirmaWidget,
        ConsultaComponent
        
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        RouterModule.forRoot([
            {
                path: '', component: ColectivoComponent,
                children: [
                    { path: '', component: LoginComponent, pathMatch: 'full' }
                ]
            },
            {
                path: 'exclusivo', component: ExclusivoComponent,
                children: [
                    { path: '', component: DashboardComponent, pathMatch: 'full' },
                    { path: 'consulta', component: ConsultaComponent },
                    //{ path: 'prospecto/:id', component: ProsNuevoComponent }, ejemplo ruta a componente con id
                ]
            }
        ])
    ],
    providers: [StoreUser],
    bootstrap: [AppComponent]
})
export class AppModule { }
