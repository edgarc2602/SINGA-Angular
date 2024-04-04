import { Component, OnInit, HostListener } from '@angular/core';
declare var bootstrap: any;

@Component({
    selector: 'lat-menu',
    templateUrl: './latmenu.component.html'
})
export class LatMenuComponent implements OnInit {
    isDarkTheme: boolean = false;
    menuExpandido: boolean = false;
    menuExpandidotext: boolean = false;
    ultMenu: string = '';
    constructor() {
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
        // Verificar si el clic ocurrió fuera del menú
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
    }

    toggleSubSubMenu(subsubmenuId: string, event: Event) {
        event.stopPropagation();
        const subsubmenus = document.querySelectorAll('.subsubmenu.active');
        subsubmenus.forEach((subsubmenu) => {
            if (subsubmenu.id !== subsubmenuId) {
                subsubmenu.classList.remove('active');
            }
        });
        const subsubmenu = document.getElementById(subsubmenuId);
        subsubmenu.classList.toggle('active');
    }

    togglePageMenu(subsubmenuId: string, event: Event) {
        event.stopPropagation();
        const subsubmenu = document.getElementById(subsubmenuId);
        subsubmenu.classList.toggle('active');
    }
    openMenu() {
        setTimeout(() => {
            this.menuExpandido = true;
            setTimeout(() => {
                this.menuExpandidotext = true;
            }, 150);
        }, 50);

    }

    closeMenu() {
        setTimeout(() => {
            this.menuExpandido = false;

                this.menuExpandidotext = false;
        }, 50);
    }
    closeMenuMouse() {
        setTimeout(() => {
            const submenus = document.querySelectorAll('.submenu.active');
            submenus.forEach((submenu) => {
                submenu.classList.remove('active');
            });
            this.menuExpandido = false;
            this.menuExpandidotext = false;
        }, 50);
    }
}