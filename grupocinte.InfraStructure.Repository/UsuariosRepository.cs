using grupocinte.Domain.Entity;
using grupocinte.InfraStructure.Interface;
using grupocinte.Transversal.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace grupocinte.InfraStructure.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UsuariosRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Método que consulta si un correo ya se encuentra registrado en la tabla usuarios
        /// </summary>
        /// <param name="model">Se envía los datos de Numero y cédula para autenticación</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        public async Task<Usuarios> LoginAsync(Usuarios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspLogin";
                var parameters = new DynamicParameters();
                parameters.Add("Numero", model.Numero);
                parameters.Add("Contrasena", model.Contrasena);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<Usuarios>(query, param: parameters, commandType: CommandType.StoredProcedure);
                //var result = await connection.QuerySingleAsync<Usuarios>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Método del repositorio encargado de realizar un registro en la base de datos.
        /// </summary>
        /// <param name="model">Recibe como parámetros el modelo Usuarios</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        public async Task<bool> InsertAsync(Usuarios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUsuariosInsert";
                var parameters = new DynamicParameters();
                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("IDTipoId", model.IDTipoId);
                parameters.Add("Numero", model.Numero);
                parameters.Add("Contrasena", model.Contrasena);
                parameters.Add("Correo", model.Correo);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        /// <summary>
        /// Método del repositorio encargado de actualizar un registro en la base de datos.
        /// </summary>
        /// <param name="model">Recibe como parámetros el modelo Usuarios</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        public async Task<bool> UpdateAsync(Usuarios model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUsuariosUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IDUsuario", model.IDUsuario);
                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("IDTipoId", model.IDTipoId);
                parameters.Add("Numero", model.Numero);
                parameters.Add("Contrasena", model.Contrasena);
                parameters.Add("Correo", model.Correo);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        /// <summary>
        /// Método del repositorio encargado de eliminar un registro en la base de datos.
        /// </summary>
        /// <param name="IDUsuario">Recibe como parámetros el ID del usuario seleccionado</param>
        /// <returns>Retorna un valor boolean verdader = proceso realizado exitosamente de lo contrario un error</returns>
        public async Task<bool> DeleteAsync(int IDUsuario)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelUsuarios";
                var parameters = new DynamicParameters();

                parameters.Add("IDUsuario", IDUsuario);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        /// <summary>
        /// Método encargado de consultar un único usuario por el IDUsuario
        /// </summary>
        /// <param name="IDUsuarios">Parametro tipo entero es el ID del usuario.</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        public async Task<Usuarios> GetAsync(int IDUsuarios)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetUsuariosByID";
                var parameters = new DynamicParameters();

                parameters.Add("IDUsuarios", IDUsuarios);

                var result = await connection.QuerySingleAsync<Usuarios>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Retorna todos los usuarios de la base de datos.
        /// </summary>
        /// <returns>Retorna una colección de Usuarios</returns>
        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspGetUsuarios";
                var parameters = new DynamicParameters();

                var result = await connection.QueryAsync<Usuarios>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// Método que consulta si un correo ya se encuentra registrado en la tabla usuarios
        /// </summary>
        /// <param name="Correo">Se envía el correo a consultar</param>
        /// <returns>Retorna una entidad de Usuarios</returns>
        public async Task<Usuarios> GetCorreo(string Correo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetUsuariosByCorreo";
                var parameters = new DynamicParameters();

                parameters.Add("Correo", Correo);

                var result = await connection.QuerySingleAsync<Usuarios>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

    }
}
