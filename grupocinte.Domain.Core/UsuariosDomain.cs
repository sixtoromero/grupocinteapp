using grupocinte.Domain.Entity;
using grupocinte.Domain.Interface;
using grupocinte.InfraStructure.Interface;
using grupocinte.Transversal.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace grupocinte.Domain.Core
{
    public class UsuariosDomain : IUsuariosDomain
    {
        private readonly IUsuariosRepository _Repository;
        public IConfiguration Configuration { get; }

        public UsuariosDomain(IUsuariosRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        /// <summary>
        /// Método que consulta si un correo ya se encuentra registrado en la tabla usuarios
        /// </summary>
        /// <param name="Correo">Se envía el correo a consultar</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        public async Task<Usuarios> LoginAsync(Usuarios model)
        {
            return await _Repository.LoginAsync(model);
        }

        /// <summary>
        /// Método del repositorio encargado de realizar un registro en la base de datos.
        /// </summary>
        /// <param name="model">Recibe como parámetros el modelo Usuarios</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        public async Task<bool> InsertAsync(Usuarios model)
        {
            return await _Repository.InsertAsync(model);
        }

        /// <summary>
        /// Método del repositorio encargado de actualizar un registro en la base de datos.
        /// </summary>
        /// <param name="model">Recibe como parámetros el modelo Usuarios</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        public async Task<bool> UpdateAsync(Usuarios model)
        {
            return await _Repository.UpdateAsync(model);
        }

        /// <summary>
        /// Método del repositorio encargado de eliminar un registro en la base de datos.
        /// </summary>
        /// <param name="IDUsuario">Recibe como parámetros el ID del usuario seleccionado</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        public async Task<bool> DeleteAsync(int IDUsuario)
        {
            return await _Repository.DeleteAsync(IDUsuario);
        }
        /// <summary>
        /// Método encargado de consultar un único usuario por el IDUsuario
        /// </summary>
        /// <param name="IDUsuarios">Parametro tipo entero es el ID del usuario.</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        public async Task<Usuarios> GetAsync(int IDUsuario)
        {
            return await _Repository.GetAsync(IDUsuario);
        }

        /// <summary>
        /// Retorna todos los usuarios de la base de datos.
        /// </summary>
        /// <returns>Retorna una colección de Usuarios</returns>
        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }
        /// <summary>
        /// Método que consulta si un correo ya se encuentra registrado en la tabla usuarios
        /// </summary>
        /// <param name="Correo">Se envía el correo a consultar</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        public async Task<Usuarios> GetCorreo(string Correo)
        {
            return await _Repository.GetCorreo(Correo);
        }
    }
}
