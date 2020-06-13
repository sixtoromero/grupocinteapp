using grupocinte.Application.DTO;
using grupocinte.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace grupocinte.Application.Interface
{
    public interface ITipoIdentificacionApplication
    {
        /// <summary>
        /// Método encargado de consultar todos los tipos de identificación
        /// </summary>
        /// <returns>Retorna una colección de TipoIdentificacion</returns>
        Task<Response<IEnumerable<TipoIdentificacionDTO>>> GetAllAsync();
    }
}
