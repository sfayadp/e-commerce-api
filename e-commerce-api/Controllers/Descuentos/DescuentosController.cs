using e_commerce_api.Application.Contracts;
using e_commerce_api.DTO.Descuentos;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Controllers.Descuentos
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescuentosController : ControllerBase
    {
        #region Fields
        private readonly IDescuentosApplicationService _descuentosApplicationService;
        #endregion Fields

        #region Builder
        public DescuentosController(IDescuentosApplicationService descuentosApplicationService)
        {
            _descuentosApplicationService = descuentosApplicationService;
        }
        #endregion Builder

        #region Methods

        /// <summary>
        /// Lista a todos los descuentos
        /// </summary>
        /// <returns>Lsita de descuentos</returns>
        [HttpGet]
        [Route(nameof(DescuentosController.GetDescuentos))]
        public IEnumerable<DescuentoDTO> GetDescuentos()
        {
            return _descuentosApplicationService.GetDescuentos();
        }

        /// <summary>
        /// Lista descuento por id
        /// </summary>
        /// <param name="id">Id asociado al descuento</param>
        /// <returns>Descuento</returns>
        [HttpGet]
        [Route(nameof(DescuentosController.GetDescuentoById))]
        public DescuentoDTO GetDescuentoById(int id)
        {
            return _descuentosApplicationService.GetDescuentoById(id);
        }

        /// <summary>
        /// Guardar un descuento
        /// </summary>
        /// <param name="descuento">Descuento a guardar</param>
        /// <returns>Mensaje con respuesta de guardado</returns>
        [HttpPost]
        [Route(nameof(DescuentosController.SaveDescuento))]
        public string SaveDescuento(DescuentoDTO descuento)
        {
            return _descuentosApplicationService.SaveDescuento(descuento);
        }

        /// <summary>
        /// Editar un descuento
        /// </summary>
        /// <param name="descuento">Descuento a editar</param>
        /// <returns>Mensaje con respuesta de edicion</returns>
        [HttpPost]
        [Route(nameof(DescuentosController.UpdateDescuento))]
        public string UpdateDescuento(DescuentoDTO descuento)
        {
            return _descuentosApplicationService.UpdateDescuento(descuento);
        }

        #endregion Methods
    }
}
