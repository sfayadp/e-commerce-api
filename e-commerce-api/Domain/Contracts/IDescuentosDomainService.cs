using e_commerce_api.DTO.Descuentos;
using e_commerce_api.Models;

namespace e_commerce_api.Domain.Contracts
{
    public interface IDescuentosDomainService
    {
        /// <summary>
        /// Lista a todos los Descuentos
        /// </summary>
        /// <returns>Lista de descuentos</returns>
        IEnumerable<Descuento> GetDescuentos();

        /// <summary>
        /// Lista descuento por id
        /// </summary>
        /// <param name="id">Id asociado al descuento</param>
        /// <returns>Descuento</returns>
        Descuento GetDescuentoById(int id);

        /// <summary>
        /// Guardar un descuento
        /// </summary>
        /// <param name="descuento">Descuento a guardar</param>
        /// <returns>Mensaje con respuesta de guardado</returns>
        string SaveDescuento(DescuentoDTO descuento);

        /// <summary>
        /// Editar un descuento
        /// </summary>
        /// <param name="descuento">Descuento a editar</param>
        /// <returns>Mensaje con respuesta de edicion</returns>
        string UpdateDescuento(DescuentoDTO descuento);
    }
}
