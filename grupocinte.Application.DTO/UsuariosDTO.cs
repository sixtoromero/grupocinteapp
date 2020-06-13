using System;
using System.Collections.Generic;
using System.Text;

namespace grupocinte.Application.DTO
{
    public class UsuariosDTO
    {
        /// <summary>
        /// Identificador único en la tabla Usuarios
        /// </summary>
        public int IDUsuario { get; set; }
        /// <summary>
        /// Campo que indica los nombres del usuario
        /// </summary>
        public string Nombres { get; set; }
        /// <summary>
        /// Campo que indica los apellidos del usuario
        /// </summary>
        public string Apellidos { get; set; }
        /// <summary>
        /// Campo que identifica el tipo de documento seleccionado, es una clave foránea
        /// </summary>
        public int IDTipoId { get; set; }
        /// <summary>
        /// Número de identificación del usuario
        /// </summary>
        public string Numero { get; set; }
        /// <summary>
        /// Campo que identifica la clave del usuario
        /// </summary>
        public string Contrasena { get; set; }
        /// <summary>
        /// Campo que identifica el correo electrónico del usuario
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// Campo para almacenar el token del usuario.
        /// </summary>
        public string Token { get; set; }

    }
}
