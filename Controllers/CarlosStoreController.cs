using System;
using Microsoft.AspNetCore.Mvc;
using TiendaDeCarlos.Models;

namespace TiendaDeCarlos.Controllers
{
    //https://localhost:5001/CarlosStore
    [Route("[controller]")]
    public class CarlosStoreController : Controller
    {
        //https://localhost:5001/CarlosStore/Login
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}