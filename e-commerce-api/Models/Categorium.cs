using System;
using System.Collections.Generic;

namespace e_commerce_api.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public int Estado { get; set; }

        public virtual Estado EstadoNavigation { get; set; } = null!;
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
