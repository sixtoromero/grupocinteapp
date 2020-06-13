using grupocinte.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace grupocinte.InfraStructure.Interface
{
    public interface ITiposIdentificacionRepository
    {
        /// <summary>
        /// Método encargado de consultar todos los tipos de identificación
        /// </summary>
        /// <returns>Retorna una colección de TipoIdentificacion</returns>
        Task<IEnumerable<TipoIdentificacion>> GetAllAsync();
    }
}
