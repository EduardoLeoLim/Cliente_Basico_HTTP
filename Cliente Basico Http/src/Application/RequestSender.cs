using Cliente_Basico_Http.Domain;

namespace Cliente_Basico_Http.Application;

public class RequestSender
{
    private readonly RequestService _requestService;
    
    public RequestSender(RequestService requestService)
    {
        _requestService = requestService;
    }

    public ResponseData SendRequest(HttpMethods method, string url, string parameters)
    {
        RequestHttp requestHttp = new RequestHttp(method, url, parameters);
        return ResponseData.FromAggregate(_requestService.SendRequest(requestHttp));
    }
}