using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

    public async Task<ResponseData> SendPostRequest(string url, string parameters)
    {
        List<string> parametersList = parameters.Split("\r\n").ToList();
        var dictonary = ListToParamenter(parametersList);
        return await new RequestSender(_requestService).SendRequest(Methods.Post, url, dictonary);
    }

    public async Task<ResponseData> SendPutRequest(string url, string parameters)
    {
        List<string> parametersList = parameters.Split("\r\n").ToList();
        var dictonary = ListToParamenter(parametersList);
        return await new RequestSender(_requestService).SendRequest(Methods.Put, url, dictonary);
    }

    public async Task<ResponseData> SendPatchRequest(string url, string parameters)
    {
        List<string> parametersList = parameters.Split("\r\n").ToList();
        var dictonary = ListToParamenter(parametersList);
        return await new RequestSender(_requestService).SendRequest(Methods.Patch, url, dictonary);
    }

    public async Task<ResponseData> SendGetRequest(string url, string parameters)
    {
        List<string> parametersList = parameters.Split("\r\n").ToList();
        var dictonary = ListToParamenter(parametersList);
        return await new RequestSender(_requestService).SendRequest(Methods.Get, url, dictonary);
    }

    public async Task<ResponseData> SendDeleteRequest(string url, string parameters)
    {
        List<string> parametersList = parameters.Split("\r\n").ToList();
        var dictonary = ListToParamenter(parametersList);
        return await new RequestSender(_requestService).SendRequest(Methods.Delete, url, dictonary);
    }

    private Dictionary<string, string> ListToParamenter(List<string> list)
    {
        Dictionary<string, object> paramenters;
        Regex separator = new Regex(" +");
        return list.Where(item => separator.Split(item).Length == 2)
            .ToDictionary(itemKey => separator.Split(itemKey)[0], itemValue => separator.Split(itemValue)[1]);
    }
}