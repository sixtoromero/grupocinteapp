using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace grupocinte.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
