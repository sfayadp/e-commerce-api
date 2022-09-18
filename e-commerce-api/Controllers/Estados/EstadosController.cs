using e_commerce_api.Application.Contracts;
using e_commerce_api.DTO.Estados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Controllers.Estados
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        #region Fields
        private readonly IEstadosApplicationService _estadosApplicationService;
        #endregion Fields

        #region Builder
        public EstadosController(IEstadosApplicationService estadosApplicationService)
        {
            _estadosApplicationService = estadosApplicationService;
        }
        #endregion Builder

        #region Methods

        /// <summary>
        /// Lista a todos los estados
        /// </summary>
        /// <returns>Lista de estados</returns>
        [HttpGet]
        [Route(nameof(EstadosController.GetEstados))]
        public IEnumerable<EstadoDTO> GetEstados()
        {
            return _estadosApplicationService.GetEstados();
        }

        /// <summary>
        /// Lista estado por id
        /// </summary>
        /// <param name="id">Id asociado al estado</param>
        /// <returns>Estado</returns>
        [HttpGet]
        [Route(nameof(EstadosController.GetEstadoById))]
        public EstadoDTO GetEstadoById(int id)
        {
            return _estadosApplicationService.GetEstadoById(id);
        }

        /// <summary>
        /// Guardar un estado
        /// </summary>
        /// <param name="estado">Estado a guardar</param>
        /// <returns>Mensaje con respuesta de guardado</returns>
        [HttpPost]
        [Route(nameof(EstadosController.SaveEstado))]
        public string SaveEstado(EstadoDTO estado)
        {
            return _estadosApplicationService.SaveEstado(estado);
        }

        /// <summary>
        /// Editar un estado
        /// </summary>
        /// <param name="estado">Estado a editar</param>
        /// <returns>Mensaje con respuesta de edicion</returns>
        [HttpPost]
        [Route(nameof(EstadosController.UpdateEstado))]
        public string UpdateEstado(EstadoDTO estado)
        {
            return _estadosApplicationService.UpdateEstado(estado);
        }

        #endregion Methods
    }
}
