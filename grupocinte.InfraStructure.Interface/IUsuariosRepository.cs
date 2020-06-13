using grupocinte.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace grupocinte.InfraStructure.Interface
{
    public interface IUsuariosRepository
    {

        /// <summary>
        /// Método que consulta si un correo ya se encuentra registrado en la tabla usuarios
        /// </summary>
        /// <param name="model">Se envía los datos de Numero y cédula para autenticación</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        Task<Usuarios> LoginAsync(Usuarios model);
        /// <summary>
        /// Método del repositorio encargado de realizar un registro en la base de datos.
        /// </summary>
        /// <param name="model">Recibe como parámetros el modelo Usuarios</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        Task<bool> InsertAsync(Usuarios model);
        /// <summary>
        /// Método del repositorio encargado de actualizar un registro en la base de datos.
        /// </summary>
        /// <param name="model">Recibe como parámetros el modelo Usuarios</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        Task<bool> UpdateAsync(Usuarios model);
        /// <summary>
        /// Método del repositorio encargado de eliminar un registro en la base de datos.
        /// </summary>
        /// <param name="IDUsuario">Recibe como parámetros el ID del usuario seleccionado</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        Task<bool> DeleteAsync(int IDUsuario);
        /// <summary>
        /// Método encargado de consultar un único usuario por el IDUsuario
        /// </summary>
        /// <param name="IDUsuarios">Parametro tipo entero es el ID del usuario.</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        Task<Usuarios> GetAsync(int IDUsuario);
        /// <summary>
        /// Retorna todos los usuarios de la base de datos.
        /// </summary>
        /// <returns>Retorna una colección de Usuarios</returns>
        Task<IEnumerable<Usuarios>> GetAllAsync();
        /// <summary>
        /// Método que consulta si un correo ya se encuentra registrado en la tabla usuarios
        /// </summary>
        /// <param name="Correo">Se envía el correo a consultar</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        Task<Usuarios> GetCorreo(string Correo);
    }
}
