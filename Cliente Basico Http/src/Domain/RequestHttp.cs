namespace Cliente_Basico_Http.Domain;

public class RequestHttp
{
    public HttpMethods Method { get; }
    public string Url { get; }
    public string Parameters { get; }

    public RequestHttp(HttpMethods method, string url, string parameters)
    {
        Method = method;
        Url = url;
        Parameters = parameters;
    }
}