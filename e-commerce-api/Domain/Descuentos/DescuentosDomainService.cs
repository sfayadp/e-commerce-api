using e_commerce_api.Domain.Contracts;
using e_commerce_api.DTO.Descuentos;
using e_commerce_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.Domain.Descuentos
{
    public class DescuentosDomainService : IDescuentosDomainService
    {
        #region Fields

        private readonly ecommerceContext _context;

        #endregion Fields

        #region Builder

        public DescuentosDomainService(ecommerceContext ecommerceContext)
        {
            _context = ecommerceContext;
        }

        #endregion Builder


        public IEnumerable<Descuento> GetDescuentos()
        {
            return _context.Descuentos.ToList();
        }

        public Descuento GetDescuentoById(int id)
        {
            return _context.Descuentos.Where(x => x.Id == id).FirstOrDefault();
        }

        public string SaveDescuento(DescuentoDTO descuento)
        {
            Descuento newDescuento = new Descuento();
            string result = "";

            if (descuento != null)
            {
                newDescuento.Nombre = descuento.NombreDTO;
                newDescuento.Codigo = descuento.CodigoDTO;
                newDescuento.ValorPorcentaje = descuento.ValorPorcentajeDTO;
            }
            _context.Descuentos.Add(newDescuento);

            if (newDescuento == null)
                return result = "No se pudo guardar el registro";

            _context.SaveChanges();
            return result = "Ok";
        }

        public string UpdateDescuento(DescuentoDTO descuento)
        {
            Descuento updateDescuento = _context.Descuentos.Where(x => x.Id == descuento.IdDTO).FirstOrDefault();
            string result = "";

            if (descuento != null)
            {
                updateDescuento.Nombre = descuento.NombreDTO;
                updateDescuento.Codigo = descuento.CodigoDTO;
                updateDescuento.ValorPorcentaje = descuento.ValorPorcentajeDTO;
            }
            _context.Entry(updateDescuento).State = EntityState.Modified;

            if (updateDescuento == null)
                return result = "No se pudo editar el registro";

            _context.SaveChanges();
            return result = "Ok";
        }
    }
}
