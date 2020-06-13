using grupocinte.Application.DTO;
using grupocinte.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace grupocinte.Application.Interface
{
    public interface IUsuariosApplication
    {
        /// <summary>
        /// Método que consulta si un correo ya se encuentra registrado en la tabla usuarios
        /// </summary>
        /// <param name="model">Se envía los datos de Numero y cédula para autenticación</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        Task<Response<UsuariosDTO>> LoginAsync(UsuariosDTO model);
        /// <summary>
        /// Método del repositorio encargado de realizar un registro en la base de datos.
        /// </summary>
        /// <param name="modelDto">Recibe como parámetros el modelo UsuariosDTO</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        Task<Response<bool>> InsertAsync(UsuariosDTO modelDto);
        /// <summary>
        /// Método del repositorio encargado de actualizar un registro en la base de datos.
        /// </summary>
        /// <param name="modelDTO">Recibe como parámetros el modelo UsuariosDTO</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        Task<Response<bool>> UpdateAsync(UsuariosDTO modelDto);
        /// <summary>
        /// Método del repositorio encargado de eliminar un registro en la base de datos.
        /// </summary>
        /// <param name="IDUsuario">Recibe como parámetros el ID del usuario seleccionado</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        Task<Response<bool>> DeleteAsync(int IDUsuario);
        /// <summary>
        /// Método encargado de consultar un único usuario por el IDUsuario
        /// </summary>
        /// <param name="IDUsuarios">Parametro tipo entero es el ID del usuario.</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        Task<Response<UsuariosDTO>> GetAsync(int IDUsuario);
        /// <summary>
        /// Retorna todos los usuarios de la base de datos.
        /// </summary>
        /// <returns>Retorna una colección de Usuarios</returns>
        Task<Response<IEnumerable<UsuariosDTO>>> GetAllAsync();
        /// <summary>
        /// Método que consulta si un correo ya se encuentra registrado en la tabla usuarios
        /// </summary>
        /// <param name="Correo">Se envía el correo a consultar</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        Task<Response<UsuariosDTO>> GetCorreo(string Correo);
    }
}
