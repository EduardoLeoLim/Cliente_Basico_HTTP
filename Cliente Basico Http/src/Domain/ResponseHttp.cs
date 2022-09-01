using System.Collections.Generic;

namespace Cliente_Basico_Http.Domain;

public class ResponseHttp
{
    public int StatusCode { get; }
    public string MessageResponse { get; }
    public List<string> Headers { get; }
    public string Body { get; }
}