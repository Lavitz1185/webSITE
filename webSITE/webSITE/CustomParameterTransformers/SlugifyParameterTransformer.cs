using System.Text.RegularExpressions;

namespace webSITE.CustomParameterTransformers
{
    public sealed class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string? TransformOutbound(object? value) => 
            value is not null && value is string str && !string.IsNullOrWhiteSpace(str) 
            ? Regex.Replace(str, "([a-z])([A-Z])", "$1-$2").ToLower() 
            : null;
    }
}
