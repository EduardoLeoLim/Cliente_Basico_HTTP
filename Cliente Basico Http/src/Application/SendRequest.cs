using Cliente_Basico_Http.Domain;
using Cliente_Basico_Http.Domain.Enums;
using Cliente_Basico_Http.Domain.Services;

namespace Cliente_Basico_Http.Application;

public class SendRequest
{
    private readonly RequestService _requestService;

    public SendRequest(RequestService requestService)
    {
        _requestService = requestService;
    }

    ResponseData SendPostRequest(string url, string parameters)
    {
        return new RequestSender(_requestService).SendRequest(Methods.Post, url, parameters);
    }

    ResponseData SendPuttRequest(string url, string parameters)
    {
        return new RequestSender(_requestService).SendRequest(Methods.Put, url, parameters);
    }

    ResponseData SendPatchRequest(string url, string parameters)
    {
        return new RequestSender(_requestService).SendRequest(Methods.Patch, url, parameters);
    }

    ResponseData SendGetRequest(string url, string parameters)
    {
        return new RequestSender(_requestService).SendRequest(Methods.Get, url, parameters);
    }

    ResponseData SendDeleteRequest(string url, string parameters)
    {
        return new RequestSender(_requestService).SendRequest(Methods.Delete, url, parameters);
    }
}