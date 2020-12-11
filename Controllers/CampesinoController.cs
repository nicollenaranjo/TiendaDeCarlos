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
    //https://localhost:5001/Campesino
    [Route("[controller]")]
    public class CampesinoController : Controller
    {

        #region Properties
        private readonly TiendaDBContext dBContext;
        #endregion Properties

        #region Constructor
        public CampesinoController(TiendaDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        #endregion Constructor

        //https://localhost:5001/Campesino/CrearCampesino
        [HttpPost("CrearCampesino")]
        public IActionResult CrearCampesino()
        {
            return View();
        }

        public async Task<IActionResult> CrearCampesinoDef( string username, string nombre, string apellido, string contrasena, string domicilio )
        {
            try
            {
                CampesinoModel Campesino = new CampesinoModel()
                {
                    Username = username,
                    Nombre = nombre,
                    Apellido = apellido,
                    Contrasena = contrasena,
                    Domicilio = domicilio
                };
                dBContext.campesinos.Add(Campesino);
                await dBContext.SaveChangesAsync();
                return RedirectToAction("HomeCampesino","Campesino",Campesino);

            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        //https://localhost:5001/Campesino/HomeCampesino
        [HttpGet("HomeCampesino")]
        public async Task<IActionResult> HomeCampesino(CampesinoModel cam)
        {
            try
            {
                List<ProductoModel> Products = await dBContext.productos.ToListAsync(); 
                foreach( ProductoModel producto in Products )
                {
                    if( producto.IdVendedor == cam.Id)
                        cam.ProductoVendedor.Add(producto);
                }
                return View(cam);
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
            
        }

        //https://localhost:5001/Campesino/CasiAgregarProducto
        [HttpPost("CasiAgregarProducto")]
        public IActionResult CasiAgregarProducto()
        {
            return View();
        }

        
        [HttpPost("AgregoProductoCampesino")]
        public async Task<IActionResult> AgregoProductoCampesino( ProductoModel producto )
        {
            try
            {
                List<CampesinoModel> Campesinos = await dBContext.campesinos.ToListAsync();
                CampesinoModel cam = new CampesinoModel();
                cam = Campesinos.First(a => a.Id == producto.IdVendedor);
                cam.ProductoVendedor.Add(producto);
                return View("HomeCampesino",cam);
            }
            catch( Exception e)
            {
                return View(e.Message);
            }
            
        }

        //https://localhost:5001/Campesino/CasiEditarProducto
        [HttpPost("CasiEditarProducto")]
        public IActionResult CasiEditarProducto( int Id)
        {
            return View( Id );
        }
    }
}