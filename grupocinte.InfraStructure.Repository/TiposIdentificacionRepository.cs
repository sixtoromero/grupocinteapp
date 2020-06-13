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
    public class TiposIdentificacionRepository : ITiposIdentificacionRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public TiposIdentificacionRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Método encargado de consultar todos los tipos de identificación
        /// </summary>
        /// <returns>Retorna una colección de TipoIdentificacion</returns>
        public async Task<IEnumerable<TipoIdentificacion>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspGetTipoIdentificacion";
                var parameters = new DynamicParameters();

                var result = await connection.QueryAsync<TipoIdentificacion>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }



    }
}
