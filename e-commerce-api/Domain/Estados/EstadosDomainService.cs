using e_commerce_api.Domain.Contracts;
using e_commerce_api.DTO.Estados;
using e_commerce_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.Domain.Estados
{
    public class EstadosDomainService : IEstadosDomainService
    {
        #region Fields

        private readonly ecommerceContext _context;

        #endregion Fields

        #region Builder

        public EstadosDomainService(ecommerceContext ecommerceContext)
        {
            _context = ecommerceContext;
        }

        #endregion Builder

        #region Methods
        public IEnumerable<Estado> GetEstados()
        {
            return _context.Estados.ToList();
        }

        public Estado GetEstadoById(int id)
        {
            return _context.Estados.Where(x => x.Id == id).FirstOrDefault();
        }

        public string SaveEstado(EstadoDTO estado)
        {
            Estado newEstado = new Estado();
            string result = "";

            if(estado != null)
            {
                newEstado.Nombre = estado.NombreDTO;
                newEstado.Descripcion = estado.DescripcionDTO;
                newEstado.FechaCreacion = DateTime.Now;
            }
            _context.Estados.Add(newEstado);

            if(newEstado == null)
               return result = "No se pudo guardar el registro";

            _context.SaveChanges();
            return result = "Ok";
        }

        public string UpdateEstado(EstadoDTO estado)
        {
            Estado updateEstado = _context.Estados.Where(x => x.Id == estado.IdDTO).FirstOrDefault();
            string result = "";

            if (estado != null)
            {
                updateEstado.Nombre = estado.NombreDTO;
                updateEstado.Descripcion = estado.DescripcionDTO;
                updateEstado.FechaCreacion = DateTime.Now;
            }
            _context.Entry(updateEstado).State = EntityState.Modified;

            if (updateEstado == null)
                return result = "No se pudo editar el registro";

            _context.SaveChanges();
            return result = "Ok";
        }

        #endregion Methods

    }
}
