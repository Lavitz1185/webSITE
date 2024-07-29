using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace webSITE.DataAccess.ValueConverters;

public class UriValueConverter : ValueConverter<Uri,  string>
{
    public UriValueConverter()
        : base(uri => uri.ToString(), s => new Uri(s))
    {}
}
