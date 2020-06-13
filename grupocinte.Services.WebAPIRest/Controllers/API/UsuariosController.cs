using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using grupocinte.Application.DTO;
using grupocinte.Application.Interface;
using grupocinte.Services.WebAPIRest.Helpers;
using grupocinte.Transversal.Common;
using grupocinte.Transversal.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace grupocinte.Services.WebAPIRest.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosApplication _Application;
        private readonly AppSettings _appSettings;

        public UsuariosController(IUsuariosApplication _Application,
                                  IOptions<AppSettings> appSettings)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Método que consulta si un correo ya se encuentra registrado en la tabla usuarios
        /// </summary>
        /// <param name="modelDto">Se envía los datos de Numero y cédula para autenticación</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        [HttpPost]
        public async Task<IActionResult> LoginAsync(UsuariosDTO modelDto)
        {
            Response<UsuariosDTO> response = new Response<UsuariosDTO>();

            try
            {
                
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.LoginAsync(modelDto);
                if (response.IsSuccess)
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.OK;
                    return Ok(response);
                }
                else
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.PreconditionFailed;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                response.ReponseCode = (int)HttpStatusCode.InternalServerError;

                return BadRequest(response);
            }
        }

        /// <summary>
        /// Método que se encarga de los registros en la tabla Usuarios de la base de datos
        /// </summary>
        /// <param name="modelDto">Se envía como parámetro un módelo de tipo UsuariosDTO</param>
        /// <returns>Retorna un Response de tipo Boolean si su valor es true el proceso fue ejecutado exitosamente</returns>
        [HttpPost]
        public async Task<IActionResult> InsertAsync(UsuariosDTO modelDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.InsertAsync(modelDto);
                if (response.IsSuccess)
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.OK;
                    return Ok(response);
                }
                else
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.PreconditionFailed;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.ReponseCode = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        /// <summary>
        /// Método que se encarga de actualizar en la tabla Usuarios de la base de datos
        /// </summary>
        /// <param name="modelDto">Se envía como parámetro un módelo de tipo UsuariosDTO</param>
        /// <returns>Retorna un Response de tipo Boolean si su valor es true el proceso fue ejecutado exitosamente</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UsuariosDTO modelDto)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                if (modelDto == null)
                    return BadRequest();

                response = await _Application.UpdateAsync(modelDto);
                if (response.IsSuccess)
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.OK;
                    return Ok(response);
                }
                else
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.PreconditionFailed;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                response.ReponseCode = (int)HttpStatusCode.InternalServerError;

                return BadRequest(response);
            }
        }

        /// <summary>
        /// Método que se encarga de eliminar un usuario en específico por IDUsuario
        /// </summary>
        /// <param name="IDUsuario">ID del usuario seleccionado</param>
        /// <returns>Retorna un Response de tipo Boolean si su valor es true el proceso fue ejecutado exitosamente</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int IDUsuario)
        {
            Response<bool> response = new Response<bool>();

            try
            {
                response = await _Application.DeleteAsync(IDUsuario);
                if (response.IsSuccess)
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.OK;
                    return Ok(response);
                }
                else
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.PreconditionFailed;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.IsSuccess = false;
                response.Message = ex.Message;

                response.ReponseCode = (int)HttpStatusCode.InternalServerError;

                return BadRequest(response);
            }
        }
        /// <summary>
        /// Método que devuelve todos los registros de la tabla usuarios.
        /// </summary>
        /// <returns>Retorna una colección de tipo UsuariosDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<UsuariosDTO>> response = new Response<IEnumerable<UsuariosDTO>>();

            try
            {
                response = await _Application.GetAllAsync();
                if (response.IsSuccess)
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.OK;
                    return Ok(response);
                }
                else
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.PreconditionFailed;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                response.ReponseCode = (int)HttpStatusCode.InternalServerError;

                return BadRequest(response);
            }
        }

        /// <summary>
        /// Método que consulta un usuario en específico por IDUsuario
        /// </summary>
        /// <param name="IDUsuario">El ID del usuario a buscar</param>
        /// <returns>Retorna una entidad de tipo UsuariosDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync(int IDUsuario)
        {
            Response<UsuariosDTO> response = new Response<UsuariosDTO>();

            try
            {
                response = await _Application.GetAsync(IDUsuario);
                if (response.IsSuccess)
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.OK;
                    return Ok(response);
                }
                else
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.PreconditionFailed;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                response.ReponseCode = (int)HttpStatusCode.InternalServerError;

                return BadRequest(response);
            }
        }

        /// <summary>
        /// Método que consulta un usuario en específico por Correo, se usa para validar si el correo está registrado.
        /// </summary>
        /// <param name="Correo">El Correo del usuario a buscar</param>
        /// <returns>Retorna una entidad de tipo UsuariosDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetCorreo(string Correo)
        {
            Response<UsuariosDTO> response = new Response<UsuariosDTO>();

            try
            {
                response = await _Application.GetCorreo(Correo);
                if (response.IsSuccess)
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.OK;
                    return Ok(response);
                }
                else
                {
                    response.ReponseCode = response.ReponseCode = (int)HttpStatusCode.PreconditionFailed;
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                response.ReponseCode = (int)HttpStatusCode.InternalServerError;

                return BadRequest(response);
            }
        }




    }
}