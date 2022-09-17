using e_commerce_api.DTO.Estados;
using e_commerce_api.Models;

namespace e_commerce_api.Domain.Contracts
{
    public interface IEstadosDomainService
    {
        /// <summary>
        /// Lista a todos los estados
        /// </summary>
        /// <returns>Lista de estados</returns>
        IEnumerable<Estado> GetEstados();

        /// <summary>
        /// Lista estado por id
        /// </summary>
        /// <param name="id">Id asociado al estado</param>
        /// <returns>Estado</returns>
        Estado GetEstadoById(int id);

        /// <summary>
        /// Guardar un estado
        /// </summary>
        /// <param name="estado">Estado a guardar</param>
        /// <returns>Mensaje con respuesta de guardado</returns>
        string SaveEstado(EstadoDTO estado);

        /// <summary>
        /// Editar un estado
        /// </summary>
        /// <param name="estado">Estado a editar</param>
        /// <returns>Mensaje con respuesta de edicion</returns>
        string UpdateEstado(EstadoDTO estado);
    }
}
