using System.Collections.Generic;
using System.Linq;
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
        List<string> parametersList = parameters.Split("\n").ToList();
        return new RequestSender(_requestService).SendRequest(Methods.Post, url, parametersList);
    }

    ResponseData SendPuttRequest(string url, string parameters)
    {
        List<string> parametersList = parameters.Split("\n").ToList();
        return new RequestSender(_requestService).SendRequest(Methods.Put, url, parametersList);
    }

    ResponseData SendPatchRequest(string url, string parameters)
    {
        List<string> parametersList = parameters.Split("\n").ToList();
        return new RequestSender(_requestService).SendRequest(Methods.Patch, url, parametersList);
    }

    ResponseData SendGetRequest(string url, string parameters)
    {
        List<string> parametersList = parameters.Split("\n").ToList();
        return new RequestSender(_requestService).SendRequest(Methods.Get, url, parametersList);
    }

    ResponseData SendDeleteRequest(string url, string parameters)
    {
        List<string> parametersList = parameters.Split("\n").ToList();
        return new RequestSender(_requestService).SendRequest(Methods.Delete, url, parametersList);
    }
}