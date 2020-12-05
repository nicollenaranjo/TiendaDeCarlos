using System;
using System.IO;
using TiendaDeCarlos.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaDeCarlos.Models
{
    public class ClienteModel : UsuarioWebModel
    {
        #region Properties
        public List<DateTime> FechaCompra = new List<DateTime>();
        public List<ProductoModel> ProductoCompra = new List<ProductoModel>();
        public enum MetodoPago
        {
            TarjetaCredito,
            PayPal,
            CuentaAhorros
        }
        public MetodoPago metodoPago;
        #endregion Properties

        #region Methods
        
        #endregion Methods

    }
}