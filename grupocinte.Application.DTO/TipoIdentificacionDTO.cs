using System;
using System.Collections.Generic;
using System.Text;

namespace grupocinte.Application.DTO
{
    public class TipoIdentificacionDTO
    {
        /// <summary>
        /// Campo que identifica el registro único en la tabla TipoIdentificacion
        /// </summary>
        public int IDTipoId { get; set; }
        /// <summary>
        /// Campo que muestra el nombre del tipo de identificación
        /// </summary>
        public string Nombre { get; set; }
    }
}
