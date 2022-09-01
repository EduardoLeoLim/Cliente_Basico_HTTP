using System.Collections.Generic;

namespace Cliente_Basico_Http.Domain.Model;

public class Response
{
    public int StatusCode { get; }
    public string MessageResponse { get; }
    public string Body { get; }

    public Response(int statusCode, string messageResponse, string body)
    {
        StatusCode = statusCode;
        MessageResponse = messageResponse;
        Body = body;
    }
}