﻿using System.ComponentModel.DataAnnotations;

namespace SINGA.DTOs
{
    public class AccesoDTO
    {
        [Required(ErrorMessage = "Usuario es requerido")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Contraseña es requerido")]
        public string Contrasena { get; set; }
    }
}
