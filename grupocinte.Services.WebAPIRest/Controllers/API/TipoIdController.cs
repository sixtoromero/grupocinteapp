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
//using Microsoft.IdentityModel.Tokens;

namespace grupocinte.Services.WebAPIRest.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TipoIdController : Controller
    {
        private readonly ITipoIdentificacionApplication _Application;
        private readonly AppSettings _appSettings;

        public TipoIdController(ITipoIdentificacionApplication _Application,
                                  IOptions<AppSettings> appSettings)
        {
            this._Application = _Application;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Método que se encarga de conseguir todos los Tipos de identificación.
        /// </summary>
        /// <returns>Retorna una colección de TipoIdentificacionDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<TipoIdentificacionDTO>> response = new Response<IEnumerable<TipoIdentificacionDTO>>();

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
    }
}