
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TiendaDeCarlos.ViewModels
{
    public class ProductoViewModel
    {
        #region Properties
        [Key]
        public int Id {get; set;}
        public string Nombre {get; set;}
        public int Cantidad {get; set;}
        public int IdVendedor {get; set;}


        [Required(ErrorMessage = "Please choose profile image")]  
        [Display(Name = "ImagenName")]
        public IFormFile ImagenName {get; set;}
        #endregion Properties
    }
}