using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.DataAccess.EntityConfigurations
{
    public static class ConfigurationAssemblyReference
    {
        public static Assembly Assembly { get => typeof(ConfigurationAssemblyReference).Assembly;}
    }
}
