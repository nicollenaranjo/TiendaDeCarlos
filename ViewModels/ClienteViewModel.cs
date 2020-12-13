using System;
using System.IO;
using TiendaDeCarlos.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaDeCarlos.ViewModels
{
    public class ClienteViewModel : ClienteModel
    {
        #region Properties
        public List<ProductoModel> productos = new List<ProductoModel>();
        public double TotalCompra;
        #endregion Properties

        #region Methods
        #endregion Methods

    }
}