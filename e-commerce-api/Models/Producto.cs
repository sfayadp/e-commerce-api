using System;
using System.Collections.Generic;

namespace e_commerce_api.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public string Imagen { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public int Estado { get; set; }
        public int Marca { get; set; }
        public int Categoria { get; set; }
        public int Descuento { get; set; }

        public virtual Categorium CategoriaNavigation { get; set; } = null!;
        public virtual Descuento DescuentoNavigation { get; set; } = null!;
        public virtual Estado EstadoNavigation { get; set; } = null!;
        public virtual Marca MarcaNavigation { get; set; } = null!;
    }
}
