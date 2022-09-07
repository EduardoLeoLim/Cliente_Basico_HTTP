using Cliente_Basico_Http.Domain;
using Cliente_Basico_Http.Domain.Model;

namespace Cliente_Basico_Http.Application;

public class ResponseData
{
    public string Body { get; }
    public string ContentType { get; }
    public int StatusCode { get; }

    public ResponseData(int statusCode, string contentType, string body)
    {
        Body = body;
        ContentType = contentType;
        StatusCode = statusCode;
    }

    public static ResponseData FromAggregate(Response response)
    {
        return new ResponseData(response.StatusCode, response.ContentType, response.Body);
    }
}