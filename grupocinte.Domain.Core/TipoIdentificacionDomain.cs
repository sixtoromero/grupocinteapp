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
    public class TipoIdentificacionDomain : ITipoIdentificacionDomain
    {
        private readonly ITiposIdentificacionRepository _Repository;
        public IConfiguration Configuration { get; }

        public TipoIdentificacionDomain(ITiposIdentificacionRepository Repository, IConfiguration _configuration)
        {
            _Repository = Repository;
            Configuration = _configuration;
        }

        public async  Task<IEnumerable<TipoIdentificacion>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }
    }
}
