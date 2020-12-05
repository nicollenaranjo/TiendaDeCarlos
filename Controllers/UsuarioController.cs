using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaDeCarlos.Models;
using TiendaDeCarlos.Services;

namespace TiendaDeCarlos.Controllers
{
    //https://localhost:5001/Usuario
    [Route("[controller]")]
    public class UsuarioController : Controller
    {

        #region Properties
        private readonly TiendaDBContext dBContext;
        #endregion Properties

        #region Constructor
        public UsuarioController(TiendaDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Constructor

        //https://localhost:5001/Usuario/ClienteDef
        [HttpGet("ClienteDef")]
        public async Task<IActionResult> ClienteDef(string user, string nombre, string apellido, string contrasena, string domicilio )
        {
            ClienteModel Cliente = new ClienteModel()
            {
                Username = user,
                Nombre = nombre,
                Apellido = apellido,
                Contrasena = contrasena,
                Domicilio = domicilio
            };
            dBContext.clientes.Add(Cliente);
            await dBContext.SaveChangesAsync();
            return View();
        }

        //https://localhost:5001/Usuario/CrearCliente
        [HttpGet("CrearCliente")]
        public IActionResult CrearCliente()
        {
            return View();
        }

        //https://localhost:5001/Usuario/CrearCampesino
        [HttpGet("CrearCampesino")]
        public IActionResult CrearCampesino()
        {
            return View();
        }

        public async Task<IActionResult> CampesinoDef( string user, string nombre, string apellido, string contrasena, string domicilio )
        {
            CampesinoModel Campesino = new CampesinoModel()
            {
                Username = user,
                Nombre = nombre,
                Apellido = apellido,
                Contrasena = contrasena,
                Domicilio = domicilio
            };
            dBContext.campesinos.Add(Campesino);
            await dBContext.SaveChangesAsync();
            return View();
        }
    }
}