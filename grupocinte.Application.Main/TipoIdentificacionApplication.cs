using grupocinte.Application.DTO;
using grupocinte.Application.Interface;
using grupocinte.Domain.Entity;
using grupocinte.Domain.Interface;
using grupocinte.Transversal.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace grupocinte.Application.Main
{
    public class TipoIdentificacionApplication : ITipoIdentificacionApplication
    {
        private readonly ITipoIdentificacionDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<TipoIdentificacionApplication> _logger;

        public TipoIdentificacionApplication(ITipoIdentificacionDomain _Domain, IMapper mapper, IAppLogger<TipoIdentificacionApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Método encargado de consultar todos los tipos de identificación
        /// </summary>
        /// <returns>Retorna una colección de TipoIdentificacion</returns>
        public async Task<Response<IEnumerable<TipoIdentificacionDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<TipoIdentificacionDTO>>();
            try
            {
                var result = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<TipoIdentificacionDTO>>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message, ex);
            }

            return response;
        }


    }
}
