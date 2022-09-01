using Cliente_Basico_Http.Domain.Enums;

namespace Cliente_Basico_Http.Domain.Model;

public class Request
{
    public Methods Method { get; }
    public string Url { get; }
    public string Parameters { get; }

    public Request(Methods method, string url, string parameters)
    {
        Method = method;
        Url = url;
        Parameters = parameters;
    }
}