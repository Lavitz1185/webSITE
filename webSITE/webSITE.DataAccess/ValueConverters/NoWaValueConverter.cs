using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.ValueObjects;

namespace webSITE.DataAccess.ValueConverters
{
    public class NoWaValueConverter : ValueConverter<NoWa, string>
    {
        public NoWaValueConverter() 
            : base(noWa => noWa.Value, s => NoWa.Create(s), null)
        {
        }
    }
}
