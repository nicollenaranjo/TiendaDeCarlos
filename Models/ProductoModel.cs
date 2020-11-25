using System.ComponentModel.DataAnnotations;

namespace TiendaDeCarlos.Models
{ 
    public class ProductoModel
    {
        #region Properties
        [Key]
        public long IDProd;
        public string Nombre;
        public int Valor;
        public int Cantidad;
        #endregion Properties
    }
}