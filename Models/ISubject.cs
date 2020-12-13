namespace TiendaDeCarlos.Models
{
    public interface ISubject
    {
        #region Methods
        void add(IObserver ProductoComprar )
        {
        }
        void Remove(IObserver ProdcutoComprado)
        {
        }
        void notify()
        {
        }
        #endregion Methods
    }
}