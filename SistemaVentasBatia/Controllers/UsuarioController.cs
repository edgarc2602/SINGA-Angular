using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SINGA.DTOs;
using SINGA.Models;
using SINGA.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SINGA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _logic;

        public UsuarioController(IUsuarioService logic)
        {
            _logic = logic;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<UsuarioDTO>> Login(AccesoDTO dto)
        {
            return await _logic.Login(dto);
        }
    }
}
