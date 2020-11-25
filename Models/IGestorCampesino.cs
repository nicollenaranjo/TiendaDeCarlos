namespace TiendaDeCarlos.Models
{
    public interface IGestorCampesino
    {
        #region Methods
        void AgregarProducto(ProductoModel ProductoNuevo )
        {
        }
        void EditarProducto(ProductoModel ProductoEditado )
        {
        }
        void EliminarProducto(ProductoModel ProductoEliminado )
        {
        }
        void VisualizarProductos()
        {
        }
        void GenerarRegistro(ProductoModel producto, ClienteModel c)
        {

        }
        #endregion Methods
    }
}