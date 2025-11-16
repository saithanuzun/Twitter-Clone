using System.Text.RegularExpressions;

namespace Twitter.Backend.WebApi.Helpers;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value)   
    {
        if (value == null) return null;

        // Converts "MainPage" to "main-page"
        return Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}