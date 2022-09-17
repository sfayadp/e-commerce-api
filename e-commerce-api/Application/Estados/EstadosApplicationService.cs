using AutoMapper;
using e_commerce_api.Application.Contracts;
using e_commerce_api.Domain.Contracts;
using e_commerce_api.DTO.Estados;
using e_commerce_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Application.Estados
{
    public class EstadosApplicationService : IEstadosApplicationService
    {
        #region Fields

        private readonly IEstadosDomainService _estadosDomainService;
        private readonly IMapper _mapper;

        #endregion Fields

        #region Builder
        public EstadosApplicationService(IEstadosDomainService estadosDomainService,
            IMapper mapper)
        {
            _estadosDomainService = estadosDomainService;
            _mapper = mapper;
        }
        #endregion Builder

        #region Methods

        /// <summary>
        /// Lista a todos los estados
        /// </summary>
        /// <returns>Lista de estados</returns>
        public IEnumerable<EstadoDTO> GetEstados()
        {
            try
            {
                IEnumerable<Estado> listEstados = _estadosDomainService.GetEstados();

                if (listEstados.Count() == 0)
                    return null;

                IEnumerable<EstadoDTO> result = _mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoDTO>>(listEstados);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista estado por id
        /// </summary>
        /// <param name="id">Id asociado al estado</param>
        /// <returns>Estado</returns>
        public EstadoDTO GetEstadoById(int id)
        {
            try
            {
                Estado estado = _estadosDomainService.GetEstadoById(id);

                if (estado == null)
                    return null;

                EstadoDTO result = _mapper.Map<Estado, EstadoDTO>(estado);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Guardar un estado
        /// </summary>
        /// <param name="estado">Estado a guardar</param>
        /// <returns>Mensaje con respuesta de guardado</returns>
        public string SaveEstado(EstadoDTO estado)
        {
            if (estado == null)
                return "Valores vacios por favor verifique la informacion";

            string result = _estadosDomainService.SaveEstado(estado);

            return result;
        }

        /// <summary>
        /// Editar un estado
        /// </summary>
        /// <param name="estado">Estado a editar</param>
        /// <returns>Mensaje con respuesta de edicion</returns>
        public string UpdateEstado(EstadoDTO estado)
        {
            if (estado == null)
                return "Valores vacios por favor verifique la informacion";

            string result = _estadosDomainService.UpdateEstado(estado);

            return result;
        }
        #endregion Methods
    }
}
