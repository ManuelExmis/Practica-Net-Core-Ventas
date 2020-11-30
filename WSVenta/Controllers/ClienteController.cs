using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVenta.Models;
using WSVenta.Models.Response;
using WSVenta.Models.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {     
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta result = new Respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    var lista = db.Cliente.OrderByDescending( d => d.Id ).ToList();
                    result.Exito = 1;
                    result.Mensaje = "Ok";
                    result.Data = lista;
                }
            }
            catch (Exception ex)
            {
                result.Mensaje = ex.Message;
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest entity)
        {
            Respuesta result = new Respuesta();

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.Nombre = entity.Nombre;
                    db.Cliente.Add(objCliente);
                    db.SaveChanges();
                    result.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                result.Mensaje = ex.Message;
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Edit(ClienteRequest entity)
        {
            Respuesta result = new Respuesta();

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente objCliente = db.Cliente.Find(entity.Id);
                    objCliente.Nombre = entity.Nombre;
                    db.Entry(objCliente).State = EntityState.Modified;
                    db.SaveChanges();
                    result.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                result.Mensaje = ex.Message;
            }


            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta result = new Respuesta();

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente objCliente = db.Cliente.Find(Id);
                    db.Remove(objCliente);
                    db.SaveChanges();
                    result.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                result.Mensaje = ex.Message;
            }

            return Ok(result);
        }      
    }      
        
}
