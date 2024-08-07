import { Component, OnInit, HostListener, Inject, ViewChild, ElementRef } from '@angular/core';
import { MenuArea } from '../../models/menuarea';
import { HttpClient } from '@angular/common/http';
import { PlotAbandsBottomLineOptions } from 'highcharts';

declare var bootstrap: any;

@Component({
    selector: 'lat-menu',
    templateUrl: './latmenu.component.html'
})
export class LatMenuComponent implements OnInit {
    @ViewChild('menuStatic', { static: false }) menuStatic: ElementRef;
    isDarkTheme: boolean = false;
    menuExpandido: boolean = false;
    menuExpandidoSubSubMenu: boolean = false;
    menuExpandidoTextSubSubMenu: boolean = false;
    menuExpandidotext: boolean = false;
    ultMenu: string = '';
    menuExpandidophone: boolean = true;
    menuExpandidoSubSubMenuphone: boolean = false;
    menuExpandidoTextSubSubMenuphone: boolean = true;
    menuExpandidotextphone: boolean = true;
    ultMenuphone: string = '';
    menu: MenuArea = { idArea: 0, areaNombre: '', areaDescripcion: '', areaPosicion: 0, areaEstatus: false, areaIcono: '', menuAreaProceso:[] };
    constructor(@Inject('BASE_URL') private url: string, private http: HttpClient) {
        http.get<MenuArea>(`${url}api/Menu/ObtenerMenu`).subscribe(response => {
            this.menu = response;
        }, err => {
        });
    }

    ngOnInit(): void {
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl)
        });
        
    }

    @HostListener('document:click', ['$event'])
    onClick(event: MouseEvent) {
        if (!this.menuExpandido) return;
        const sidebarMenu = document.getElementById('sidebarMenustatic');
        if (!sidebarMenu) return;
        // Verificar si el clic ocurri� fuera del men�
        if (!sidebarMenu.contains(event.target as Node)) {
            const submenus = document.querySelectorAll('.submenu.active');
            submenus.forEach((submenu) => {
                submenu.classList.remove('active');
            });
            this.closeMenu();
        }
    }

    toggleTheme() {
        this.isDarkTheme = !this.isDarkTheme;
        if (this.isDarkTheme) {
            document.body.classList.add('dark-theme');
        } else {
            document.body.classList.remove('dark-theme');
        }
        this.quitarFocoDeElementos();
    }

    quitarFocoDeElementos(): void {
        const elementos = document.querySelectorAll('button, input[type="text"]');
        elementos.forEach((elemento: HTMLElement) => {
            elemento.blur();
        });
    }

    toggleMenu() {
        this.menuExpandido = !this.menuExpandido;
    }

    toggleSubMenu(submenuId: string, idCierre: number) {
        this.ultMenu = submenuId;
        //Selecciona los menus activos
        const submenus = document.querySelectorAll('.submenu.active');
        submenus.forEach((submenu) => {
            if (submenu.id !== submenuId) {
                submenu.classList.remove('active');
            }
        });
        if (idCierre == 1) {
            const submenu = document.getElementById(submenuId);
            submenu.classList.toggle('active');
        }
        const subsubmenus = document.querySelectorAll('.subsubmenu.active');
        subsubmenus.forEach((subsubmenus) => {
            subsubmenus.classList.remove('active');
        });
    }

    toggleSubSubMenu(subsubmenuId: string, event: Event) {
        
        event.stopPropagation();
        const subsubmenus = document.querySelectorAll('.subsubmenu.active');
        subsubmenus.forEach((subsubmenu) => {
            if (subsubmenu.id !== subsubmenuId) {
                subsubmenu.classList.remove('active');
                this.menuExpandidoSubSubMenu = false;
                this.menuExpandidoSubSubMenuphone = false;
                this.menuExpandidoTextSubSubMenu = false;
                this.menuExpandidoTextSubSubMenuphone = false;


            }
        });
        const subsubmenu = document.getElementById(subsubmenuId);
        subsubmenu.classList.toggle('active');
        this.menuExpandidoSubSubMenu = !this.menuExpandidoSubSubMenu;
        this.menuExpandidoSubSubMenuphone = !this.menuExpandidoSubSubMenuphone;
        setTimeout(() => {
            this.menuExpandidoTextSubSubMenu = !this.menuExpandidoTextSubSubMenu;
            this.menuExpandidoTextSubSubMenuphone = !this.menuExpandidoTextSubSubMenuphone;
        }, 250);

    }

    togglePageMenu(subsubmenuId: string, event: Event) {
        event.stopPropagation();
        const subsubmenu = document.getElementById(subsubmenuId);
        subsubmenu.classList.toggle('active');
    }

    openMenu() {
        
        this.menuExpandidoSubSubMenu = false;
        this.menuExpandidoSubSubMenuphone = false;
        this.menuExpandidoTextSubSubMenu = false;
        this.menuExpandidoTextSubSubMenuphone = false;

        this.menuExpandido = true;
        this.menuExpandidophone = true;
            setTimeout(() => {
                this.menuExpandidotext = true;
                this.menuExpandidotextphone = true;

                const div = document.querySelector('#sidebarMenustatic');

                if (div) {
                    // Quita el scroll bar estableciendo overflow a 'hidden'
                    (div as HTMLElement).style.overflow = 'auto';
                    (div as HTMLElement).style.overflowX = 'hidden';
                }
            }, 110);
    }

    closeMenu() {
        const div = document.querySelector('sidebarMenustatic');

        if (div) {
            // Quita el scroll bar estableciendo overflow a 'hidden'
            (div as HTMLElement).style.overflow = 'hidden';
        }
        this.menuExpandidoSubSubMenu = false;
        this.menuExpandidoSubSubMenuphone = false;
        this.menuExpandidoTextSubSubMenu = false;
        this.menuExpandidoTextSubSubMenuphone = false;
        this.menuExpandido = false;
        this.menuExpandidophone = false;
        this.menuExpandidotext = false;
        this.menuExpandidotextphone = false;
    }

    closeMenuMouse() {
        
        setTimeout(() => {
            const submenus = document.querySelectorAll('.submenu.active');
            submenus.forEach((submenu) => {
                submenu.classList.remove('active');
            });
            const subsubmenus = document.querySelectorAll('.subsubmenu.active');
            subsubmenus.forEach((subsubmenus) => {
                subsubmenus.classList.remove('active');
            });
            this.menuExpandidoSubSubMenu = false;
            this.menuExpandidoSubSubMenuphone = false;
            this.menuExpandidoTextSubSubMenu = false;
            this.menuExpandidoTextSubSubMenuphone = false;
            this.menuExpandido = false;
            this.menuExpandidophone = false;
            this.menuExpandidotext = false;
            this.menuExpandidotextphone = false;

            const div = document.querySelector('#sidebarMenustatic');

            if (div) {
                // Quita el scroll bar estableciendo overflow a 'hidden'
                (div as HTMLElement).style.overflow = 'hidden';
                (div as HTMLElement).style.overflowY = 'hidden';
            }
            if (this.menuStatic) {
                const container = this.menuStatic.nativeElement;
                container.scrollTop = 0;
            }
        }, 120);
    }
    onToggleClick(event: Event) {
        // Remover la clase 'active' de todos los enlaces
        const links = document.querySelectorAll('.nav-link');
        links.forEach((link) => {
            link.classList.remove('active');
        });

        // Agregar la clase 'active' al enlace clicado
        const target = event.target as HTMLElement;
        target.classList.add('active');
    }



    //MOVILES

    toggleMenuMov() {
        this.menuExpandido = !this.menuExpandido;
    }

    toggleSubMenuMov(submenuId: string, idCierre: number) {

        this.menuExpandidoSubSubMenu = false;
        this.menuExpandidoSubSubMenuphone = false;
        this.menuExpandidoTextSubSubMenu = false;
        this.menuExpandidoTextSubSubMenuphone = false;
        this.menuExpandido = true;
        this.menuExpandidophone = true;
        this.menuExpandidotext = true;
        this.menuExpandidotextphone = true;
        this.ultMenu = submenuId;
        //Selecciona los menus activos
        const submenus = document.querySelectorAll('.submenumov.active');
        submenus.forEach((submenu) => {
            if (submenu.id !== submenuId) {
                submenu.classList.remove('active');
            }
        });
        if (idCierre == 1) {
            const submenu = document.getElementById(submenuId);
            submenu.classList.toggle('active');
        }
        const subsubmenus = document.querySelectorAll('.subsubmenumov.active');
        subsubmenus.forEach((subsubmenus) => {
            subsubmenus.classList.remove('active');
        });
    }

    toggleSubSubMenuMov(subsubmenuId: string, event: Event) {

        event.stopPropagation();
        const subsubmenus = document.querySelectorAll('.subsubmenumov.active');
        subsubmenus.forEach((subsubmenu) => {
            if (subsubmenu.id !== subsubmenuId) {
                subsubmenu.classList.remove('active');
                this.menuExpandidoSubSubMenu = false;
                this.menuExpandidoSubSubMenuphone = false;
                this.menuExpandidoTextSubSubMenu = false;
                this.menuExpandidoTextSubSubMenuphone = false;


            }
        });
        const subsubmenu = document.getElementById(subsubmenuId);
        subsubmenu.classList.toggle('active');
        this.menuExpandidoSubSubMenu = !this.menuExpandidoSubSubMenu;
        this.menuExpandidoSubSubMenuphone = !this.menuExpandidoSubSubMenuphone;
        setTimeout(() => {
            this.menuExpandidoTextSubSubMenu = !this.menuExpandidoTextSubSubMenu;
            this.menuExpandidoTextSubSubMenuphone = !this.menuExpandidoTextSubSubMenuphone;
        }, 250);

    }

    togglePageMenuMov(subsubmenuId: string, event: Event) {
        event.stopPropagation();
        const subsubmenu = document.getElementById(subsubmenuId);
        subsubmenu.classList.toggle('active');
    }

    openMenuMov() {

        this.menuExpandidoSubSubMenu = false;
        this.menuExpandidoSubSubMenuphone = false;
        this.menuExpandidoTextSubSubMenu = false;
        this.menuExpandidoTextSubSubMenuphone = false;

        this.menuExpandido = true;
        this.menuExpandidophone = true;
        setTimeout(() => {
            this.menuExpandidotext = true;
            this.menuExpandidotextphone = true;

            const div = document.querySelector('#sidebarMenuMovil');

            if (div) {
                // Quita el scroll bar estableciendo overflow a 'hidden'
                (div as HTMLElement).style.overflow = 'auto';
                (div as HTMLElement).style.overflowX = 'hidden';
            }
        }, 110);
    }

    closeMenuMov() {
        const div = document.querySelector('sidebarMenuMovil');

        if (div) {
            // Quita el scroll bar estableciendo overflow a 'hidden'
            (div as HTMLElement).style.overflow = 'hidden';
        }
        this.menuExpandidoSubSubMenu = false;
        this.menuExpandidoSubSubMenuphone = false;
        this.menuExpandidoTextSubSubMenu = false;
        this.menuExpandidoTextSubSubMenuphone = false;
        this.menuExpandido = false;
        this.menuExpandidophone = false;
        this.menuExpandidotext = false;
        this.menuExpandidotextphone = false;
    }

    closeMenuMouseMov() {

        setTimeout(() => {
            const submenus = document.querySelectorAll('.submenumov.active');
            submenus.forEach((submenu) => {
                submenu.classList.remove('active');
            });
            const subsubmenus = document.querySelectorAll('.subsubmenumov.active');
            subsubmenus.forEach((subsubmenus) => {
                subsubmenus.classList.remove('active');
            });
            this.menuExpandidoSubSubMenu = false;
            this.menuExpandidoSubSubMenuphone = false;
            this.menuExpandidoTextSubSubMenu = false;
            this.menuExpandidoTextSubSubMenuphone = false;
            this.menuExpandido = false;
            this.menuExpandidophone = false;
            this.menuExpandidotext = false;
            this.menuExpandidotextphone = false;

            const div = document.querySelector('#sidebarMenuMovil');

            if (div) {
                // Quita el scroll bar estableciendo overflow a 'hidden'
                (div as HTMLElement).style.overflow = 'hidden';
                (div as HTMLElement).style.overflowY = 'hidden';
            }
            if (this.menuStatic) {
                const container = this.menuStatic.nativeElement;
                container.scrollTop = 0;
            }
        }, 120);
    }
    onToggleClickMov(event: Event) {
        // Remover la clase 'active' de todos los enlaces
        const links = document.querySelectorAll('.nav-link');
        links.forEach((link) => {
            link.classList.remove('active');
        });

        // Agregar la clase 'active' al enlace clicado
        const target = event.target as HTMLElement;
        target.classList.add('active');
    }
}