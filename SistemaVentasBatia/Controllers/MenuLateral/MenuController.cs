using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Configuration;
using SINGA.DTOs;
using SINGA.Models.MenuLateral;
using SINGA.Services;


namespace SINGA.Controllers.MenuLateral
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService logic;

        public MenuController(IMenuService service)
        {
            logic = service;
        }

        [HttpGet("[action]")]
        public async Task<List<MenuArea>> ObtenerMenu()
        {
            return await logic.ObtenerMenu();
        }
    }
}