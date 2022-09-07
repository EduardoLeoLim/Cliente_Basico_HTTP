using System.Collections.Generic;
using System.Threading.Tasks;
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

    public async Task<ResponseData> SendRequest(Methods method, string url, Dictionary<string, string> parameters)
    {
        Request request = new Request(method, url, parameters);
        return ResponseData.FromAggregate( await _requestService.SendRequest(request));
    }
}