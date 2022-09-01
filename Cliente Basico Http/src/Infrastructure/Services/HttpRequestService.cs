using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cliente_Basico_Http.Domain.Enums;
using Cliente_Basico_Http.Domain.Model;
using Cliente_Basico_Http.Domain.Services;

namespace Cliente_Basico_Http.Infrastructure.Services;

public class HttpRequestService : RequestService
{
    public async Task<Response> SendRequest(Request request)
    {
        using (var client = new HttpClient())
        {
            switch (request.Method)
            {
                case Methods.Get:
                    return await SendGetRequest(client, request);
                case Methods.Post:
                    break;
                case Methods.Put:
                    break;
                case Methods.Patch:
                    break;
                case Methods.Delete:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return null;
    }

    private async Task<Response> SendGetRequest(HttpClient client , Request request)
    {
        var responseHttpCliente = await client.GetAsync(request.Url);
        Response response = new Response((int)responseHttpCliente.StatusCode, responseHttpCliente.RequestMessage.ToString(), await responseHttpCliente.Content.ReadAsStringAsync());
        
        return response;
    }
}