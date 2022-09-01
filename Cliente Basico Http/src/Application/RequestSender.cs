using Cliente_Basico_Http.Domain;
using Cliente_Basico_Http.Domain.Enums;
using Cliente_Basico_Http.Domain.Model;
using Cliente_Basico_Http.Domain.Services;

namespace Cliente_Basico_Http.Application;

public class RequestSender
{
    private readonly RequestService _requestService;
    
    public RequestSender(RequestService requestService)
    {
        _requestService = requestService;
    }

    public ResponseData SendRequest(Methods method, string url, string parameters)
    {
        Request request = new Request(method, url, parameters);
        return ResponseData.FromAggregate(_requestService.SendRequest(request));
    }
}