using System;
using System.Collections.Generic;

namespace e_commerce_api.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Categoria = new HashSet<Categorium>();
            Marcas = new HashSet<Marca>();
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Categorium> Categoria { get; set; }
        public virtual ICollection<Marca> Marcas { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
