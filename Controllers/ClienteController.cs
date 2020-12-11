using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaDeCarlos.Models;
using TiendaDeCarlos.Services;

namespace TiendaDeCarlos.Controllers
{
    //https://localhost:5001/Cliente
    [Route("[controller]")]
    public class ClienteController : Controller
    {

        #region Properties
        private readonly TiendaDBContext dBContext;
        #endregion Properties

        #region Constructor
        public ClienteController(TiendaDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Constructor

        public async Task<IActionResult> CrearClienteDef(string username, string nombre, string apellido, string contrasena, string domicilio)
        {
            try
            {
                int i = Convert.ToInt16(Request.Form["testSelect"]);
                ClienteModel Cliente = new ClienteModel()
                {
                    Username = username,
                    Nombre = nombre,
                    Apellido = apellido,
                    Contrasena = contrasena,
                    Domicilio = domicilio,
                    metodoPago = (MetodoPago)i
                };
                Console.WriteLine(Cliente.metodoPago);
                dBContext.clientes.Add(Cliente);
                await dBContext.SaveChangesAsync();
                return RedirectToAction("HomeCliente",Cliente);
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        //https://localhost:5001/Cliente/CrearCliente
        [HttpPost("CrearCliente")]
        public IActionResult CrearCliente()
        {
            return View();
        }


        //https://localhost:5001/Cliente/HomeCliente
        [HttpGet("HomeCliente")]
        public IActionResult HomeCliente(ClienteModel cliente)
        {
            return View(cliente);
        }

        //https://localhost:5001/Cliente/CarritoCliente
        [HttpGet("CarritoCliente")]
        public IActionResult CarritoCliente()
        {
            return View();
        }
    }
}