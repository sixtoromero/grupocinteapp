using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace grupocinte.Transversal.Common
{
    public class Response<T>
    {
        /// <summary>
        /// Aquí se recibe el resultado de la operación pedida
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Nos indica si fue exitoso o no el proceso
        /// </summary>
        public bool IsSuccess { get; set; }
        //public bool IsSuccess 
        //{
        //    get
        //    {
        //        if (ReponseCode >= 200 && ReponseCode < 300)
        //        {
        //            return true;
        //        }

        //        return false;
        //    }
        //}
        /// <summary>
        /// Se almacena información si fue exitoso o no la transacción
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Define el estado de la petición realizada con la API
        /// OK = 200
        /// BadRequest = 400
        /// Unauthorized = 401
        /// InternalServerError = 500
        /// </summary>
        public int ReponseCode { get; set; }
    }
}
