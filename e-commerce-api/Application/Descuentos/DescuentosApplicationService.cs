using AutoMapper;
using e_commerce_api.Application.Contracts;
using e_commerce_api.Domain.Contracts;
using e_commerce_api.Domain.Estados;
using e_commerce_api.DTO.Descuentos;
using e_commerce_api.DTO.Estados;
using e_commerce_api.Models;

namespace e_commerce_api.Application.Descuentos
{
    public class DescuentosApplicationService : IDescuentosApplicationService
    {
        #region Fields

        private readonly IDescuentosDomainService _descuentosDomainService;
        private readonly IMapper _mapper;

        #endregion Fields

        #region Builder
        public DescuentosApplicationService(IDescuentosDomainService descuentosDomainService,
            IMapper mapper)
        {
            _descuentosDomainService = descuentosDomainService;
            _mapper = mapper;
        }
        #endregion Builder

        #region Methods

        public IEnumerable<DescuentoDTO> GetDescuentos()
        {
            try
            {
                IEnumerable<Descuento> listDescuentos = _descuentosDomainService.GetDescuentos();

                if (listDescuentos.Count() == 0)
                    return null;

                IEnumerable<DescuentoDTO> result = _mapper.Map<IEnumerable<Descuento>, IEnumerable<DescuentoDTO>>(listDescuentos);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DescuentoDTO GetDescuentoById(int id)
        {
            try
            {
                Descuento descuento = _descuentosDomainService.GetDescuentoById(id);

                if (descuento == null)
                    return null;

                DescuentoDTO result = _mapper.Map<Descuento, DescuentoDTO>(descuento);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string SaveDescuento(DescuentoDTO descuento)
        {
            if (descuento == null)
                return "Valores vacios por favor verifique la informacion";

            string result = _descuentosDomainService.SaveDescuento(descuento);

            return result;
        }

        public string UpdateDescuento(DescuentoDTO descuento)
        {
            if (descuento == null)
                return "Valores vacios por favor verifique la informacion";

            string result = _descuentosDomainService.UpdateDescuento(descuento);

            return result;
        }
        #endregion Methods
    }
}
