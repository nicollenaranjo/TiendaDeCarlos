using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaDeCarlos.Models;
using TiendaDeCarlos.Services;
using TiendaDeCarlos.ViewModels;

namespace TiendaDeCarlos.Controllers
{
    //https://localhost:5001/Usuario
    [Route("[controller]")]
    public class ProductoController : Controller
    {

        #region Properties
        private readonly TiendaDBContext dBContext;
        private readonly IWebHostEnvironment hostEnvironment;  

        #endregion Properties

        #region Constructor
        public ProductoController(TiendaDBContext dBContext, IWebHostEnvironment hostEnvironment)
        {
            this.dBContext = dBContext;
            this.hostEnvironment = hostEnvironment;
        }
        #endregion Constructor

        [HttpPost("AgregarProducto")]
        public async Task<IActionResult> AgregarProducto(ProductoViewModel productoV)
        {
            try
            {
                string uniqueFileName = UploadedFile(productoV);  
                int i = Convert.ToInt16(Request.Form["testSelect"]);
                ProductoModel producto = new ProductoModel()
                {
                    Nombre = productoV.Nombre,
                    Cantidad = productoV.Cantidad,
                    IdVendedor = Convert.ToInt16(TempData["Id"]),
                    Imagen = uniqueFileName
                };
                producto.Cantidad = i;
                dBContext.productos.Add(producto);
                await dBContext.SaveChangesAsync();
                return RedirectToAction("AgregoProductoCampesino","Campesino", producto);
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        public async Task<IActionResult> EditarProducto()
        {
            return View();
        }

        private string UploadedFile(ProductoViewModel pro)  
        {  
            string uniqueFileName = null;  
  
            if (pro.ImagenName != null)  
            {  
                string uploadsFolder = Path.Combine(hostEnvironment.WebRootPath, "Pictures");  
                uniqueFileName = Guid.NewGuid().ToString() + "_" + pro.ImagenName.FileName;  
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);  
                using (var fileStream = new FileStream(filePath, FileMode.Create))  
                {  
                    pro.ImagenName.CopyTo(fileStream);  
                }  
            }  
            return uniqueFileName;  
        } 
    }
}