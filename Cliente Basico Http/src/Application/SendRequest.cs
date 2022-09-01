using Cliente_Basico_Http.Domain;

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
        return new RequestSender(_requestService).SendRequest(HttpMethods.Post, url, parameters);
    }

    ResponseData SendPuttRequest(string url, string parameters)
    {
        return new RequestSender(_requestService).SendRequest(HttpMethods.Put, url, parameters);
    }

    ResponseData SendPatchRequest(string url, string parameters)
    {
        return new RequestSender(_requestService).SendRequest(HttpMethods.Patch, url, parameters);
    }

    ResponseData SendGetRequest(string url, string parameters)
    {
        return new RequestSender(_requestService).SendRequest(HttpMethods.Get, url, parameters);
    }

    ResponseData SendDeleteRequest(string url, string parameters)
    {
        return new RequestSender(_requestService).SendRequest(HttpMethods.Delete, url, parameters);
    }
}