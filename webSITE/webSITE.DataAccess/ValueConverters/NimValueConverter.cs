using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webSITE.Domain.ValueObjects;

namespace webSITE.DataAccess.ValueConverters
{
    public class NimValueConverter : ValueConverter<Nim, string>
    {
        public NimValueConverter() 
            : base(nim => nim.Value, s => Nim.Create(s), null)
        {
        }
    }
}
