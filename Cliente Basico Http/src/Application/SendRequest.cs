using System.Threading.Tasks;
using Cliente_Basico_Http.Domain.Enums;
using Cliente_Basico_Http.Domain.Services;
using Newtonsoft.Json.Linq;

namespace Cliente_Basico_Http.Application;

public class SendRequest
{
    private readonly RequestService _requestService;

    public SendRequest(RequestService requestService)
    {
        _requestService = requestService;
    }

    public async Task<ResponseData> SendPostRequest(string url, string parameters)
    {
        if (parameters.Length > 0)
            _ = JToken.Parse(parameters);
        return await new RequestSender(_requestService).SendRequest(Methods.Post, url, parameters);
    }

    public async Task<ResponseData> SendPutRequest(string url, string parameters)
    {
        if (parameters.Length > 0)
            _ = JToken.Parse(parameters);
        return await new RequestSender(_requestService).SendRequest(Methods.Put, url, parameters);
    }

    public async Task<ResponseData> SendPatchRequest(string url, string parameters)
    {
        if (parameters.Length > 0)
            _ = JToken.Parse(parameters);
        return await new RequestSender(_requestService).SendRequest(Methods.Patch, url, parameters);
    }

    public async Task<ResponseData> SendGetRequest(string url)
    {
        return await new RequestSender(_requestService).SendRequest(Methods.Get, url, "");
    }

    public async Task<ResponseData> SendHeadRequest(string url)
    {
        return await new RequestSender(_requestService).SendRequest(Methods.Head, url, "");
    }

    public async Task<ResponseData> SendDeleteRequest(string url)
    {
        return await new RequestSender(_requestService).SendRequest(Methods.Delete, url, "");
    }
}