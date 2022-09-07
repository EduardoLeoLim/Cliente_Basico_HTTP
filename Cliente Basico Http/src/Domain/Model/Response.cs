using System.Collections.Generic;

namespace Cliente_Basico_Http.Domain.Model;

public class Response
{
    public int StatusCode { get; }
    public string MessageResponse { get; }
    public string Body { get; }
    
    public string ContentType { get; }

    public Response(int statusCode, string messageResponse, string contentType,string body)
    {
        StatusCode = statusCode;
        MessageResponse = messageResponse;
        ContentType = contentType;
        Body = body;
    }
}