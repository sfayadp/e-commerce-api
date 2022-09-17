using System;
using System.Collections.Generic;

namespace e_commerce_api.Models
{
    public partial class Descuento
    {
        public Descuento()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public decimal ValorPorcentaje { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
