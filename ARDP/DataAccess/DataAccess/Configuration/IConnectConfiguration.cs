using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.Data
{
    public interface IConnectConfiguration
    {
        string ConnectionString
        {
            get;
        }

        string ParameterPrefix
        {
            get;
        }
    }
}
