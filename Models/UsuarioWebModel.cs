namespace TiendaDeCarlos.Models
{
    public class UsuarioWebModel : IUsuarioModel
    {
        #region Properties
        public string Nombre;
        public string Apellido;
        public string Contrasena;
        public string Domicilio;
        #endregion Properties

        #region Methods
        public void CrearUsuario(string n, string a, string c, string d)
        {
            Nombre = n;
            Apellido = a;
            Contrasena = c;
            Domicilio =d;
        }
        #endregion Methods
    }
}
