using Cliente_Basico_Http.Domain.Enums;

namespace Cliente_Basico_Http.Domain.Model;

public class Request
{
    public Methods Method { get; }
    public string Url { get; }
    public string JsonParameters { get; }

    public Request(Methods method, string url, string jsonParameters)
    {
        Method = method;
        Url = url;
        JsonParameters = jsonParameters;
    }
}