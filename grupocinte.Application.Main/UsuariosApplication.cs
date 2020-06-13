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
    public class UsuariosApplication : IUsuariosApplication
    {
        private readonly IUsuariosDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UsuariosApplication> _logger;

        public UsuariosApplication(IUsuariosDomain _Domain, IMapper mapper, IAppLogger<UsuariosApplication> logger)
        {
            this._Domain = _Domain;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Método que consulta si un correo ya se encuentra registrado en la tabla usuarios
        /// </summary>
        /// <param name="modelDto">Se manda los datos para el logueo en la app</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        public async Task<Response<UsuariosDTO>> LoginAsync(UsuariosDTO modelDto)
        {
            var response = new Response<UsuariosDTO>();
            try
            {

                var resp = _mapper.Map<Usuarios>(modelDto);
                var model = await _Domain.LoginAsync(resp);
                response.Data = _mapper.Map<UsuariosDTO>(model);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                //Manejo de excepciones en el Log
                _logger.LogError(ex.Message, ex);

            }

            return response;
        }

        public async Task<Response<bool>> InsertAsync(UsuariosDTO modelDto)
        {
            var response = new Response<bool>();
            try
            {
                var resp = _mapper.Map<Usuarios>(modelDto);
                response.Data = await _Domain.InsertAsync(resp);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message, ex);
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(UsuariosDTO modelDto)
        {
            var response = new Response<bool>();
            try
            {
                var resp = _mapper.Map<Usuarios>(modelDto);
                response.Data = await _Domain.UpdateAsync(resp);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                _logger.LogError(ex.Message, ex);

            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int ID)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _Domain.DeleteAsync(ID);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

                _logger.LogError(ex.Message, ex);
            }

            return response;
        }

        public async Task<Response<UsuariosDTO>> GetAsync(int ID)
        {
            var response = new Response<UsuariosDTO>();
            try
            {
                var result = await _Domain.GetAsync(ID);

                response.Data = _mapper.Map<UsuariosDTO>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message, ex);
            }

            return response;
        }

        public async Task<Response<IEnumerable<UsuariosDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<UsuariosDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<UsuariosDTO>>(resp);
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

        /// <summary>
        /// Método que consulta si un correo ya se encuentra registrado en la tabla usuarios
        /// </summary>
        /// <param name="Correo">Se envía el correo a consultar</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        public async Task<Response<UsuariosDTO>> GetCorreo(string Correo)
        {
            var response = new Response<UsuariosDTO>();
            try
            {
                var result = await _Domain.GetCorreo(Correo);

                response.Data = _mapper.Map<UsuariosDTO>(result);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
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
