using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVenta.Models.Request;
using WSVenta.Models.Response;
using WSVenta.Services;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Respuesta result = new Respuesta();
            var userResponse = _userService.Auth(model);

            if (userResponse == null)
            {
                result.Exito = 0;
                result.Mensaje = "Usuario o contraseña incorrecta";
                return BadRequest(result);
            }

            result.Exito = 1;
            result.Data = userResponse;

            return Ok(result);
        }
    }
}
