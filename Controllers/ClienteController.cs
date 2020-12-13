using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaDeCarlos.Models;
using TiendaDeCarlos.Services;
using TiendaDeCarlos.ViewModels;

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
                ClienteModel cliente = dBContext.clientes.First(a => a.Username == username);
                if( cliente == null )
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
                return View("MalCrear");
                
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
        public async Task<IActionResult> HomeCliente(ClienteModel cliente)
        {
            ClienteViewModel ClienteView = new ClienteViewModel()
            {
                Id = cliente.Id,
                Username = cliente.Username,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Contrasena = cliente.Contrasena,
                Domicilio = cliente.Contrasena,
                metodoPago = cliente.metodoPago
            };
            cliente.productosCarrito.ForEach(producto => ClienteView.productosCarrito.Add(producto));
            ClienteView.productos = await dBContext.productos.ToListAsync(); 
            return View(ClienteView);
        }

        //https://localhost:5001/Cliente/CarritoCliente
        [HttpGet("CarritoCliente")]
        public IActionResult CarritoCliente()
        {
            return View();
        }

        [HttpPost("AgregarProductoCanasta")]
        public async Task<IActionResult> AgregarProductoCanasta( int idpro, int IdCliente)
        {
            try
            {
                ClienteModel cliente = await dBContext.clientes.FindAsync(IdCliente);
                ProductoModel canasta = await dBContext.productos.FindAsync(idpro);
                cliente.productosCarrito.Add(canasta);
                return RedirectToAction("HomeCliente",cliente);
            }
            catch( Exception e)
            {
                return View(e.Message);
            }
        }
    }
}