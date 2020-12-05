using System.ComponentModel.DataAnnotations;

namespace TiendaDeCarlos.Models
{
    public class UsuarioWebModel : IUsuarioModel
    {
        #region Properties
        [Key]
        public int Id;
        public string Username;
        public string Nombre;
        public string Apellido;
        public string Contrasena;
        public string Domicilio;
        #endregion Properties

        #region Methods
        #endregion Methods
    }
}
