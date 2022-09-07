using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cliente_Basico_Http.Domain.Enums;
using Cliente_Basico_Http.Domain.Model;
using Cliente_Basico_Http.Domain.Services;
using Newtonsoft.Json;

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
                    return await SendPostRequest(client, request);
                case Methods.Put:
                    return await SendPutRequest(client, request);
                case Methods.Patch:
                    return await SendPatchRequest(client, request);
                case Methods.Delete:
                    return await SendDeleteRequest(client, request);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private async Task<Response> SendGetRequest(HttpClient client, Request request)
    {
        var responseHttpCliente = await client.GetAsync(request.Url);
        Response response = new Response(
            (int)responseHttpCliente.StatusCode,
            responseHttpCliente.RequestMessage.ToString(),
            responseHttpCliente.Content.Headers.ContentType?.MediaType,
            await responseHttpCliente.Content.ReadAsStringAsync()
        );

        return response;
    }

    private async Task<Response> SendPostRequest(HttpClient client, Request request)
    {
        var jsonDictionary = JsonConvert.SerializeObject(request.Parameters);
        var content = new StringContent(jsonDictionary, Encoding.UTF8, "application/json");
        var responseHttpCliente = await client.PostAsync(request.Url, content);
        Response response = new Response(
            (int)responseHttpCliente.StatusCode,
            responseHttpCliente.RequestMessage.ToString(),
            responseHttpCliente.Content.Headers.ContentType?.MediaType,
            await responseHttpCliente.Content.ReadAsStringAsync()
        );

        return response;
    }

    private async Task<Response> SendPutRequest(HttpClient client, Request request)
    {
        var jsonDictionary = JsonConvert.SerializeObject(request.Parameters);
        var content = new StringContent(jsonDictionary, Encoding.UTF8, "application/json");
        var responseHttpCliente = await client.PutAsync(request.Url, content);
        Response response = new Response(
            (int)responseHttpCliente.StatusCode,
            responseHttpCliente.RequestMessage.ToString(),
            responseHttpCliente.Content.Headers.ContentType?.MediaType,
            await responseHttpCliente.Content.ReadAsStringAsync()
        );

        return response;
    }

    private async Task<Response> SendPatchRequest(HttpClient client, Request request)
    {
        var jsonDictionary = JsonConvert.SerializeObject(request.Parameters);
        var content = new StringContent(jsonDictionary , Encoding.UTF8, "application/json");
        var responseHttpCliente = await client.PatchAsync(request.Url, content);
        Response response = new Response(
            (int)responseHttpCliente.StatusCode,
            responseHttpCliente.RequestMessage.ToString(),
            responseHttpCliente.Content.Headers.ContentType?.MediaType,
            await responseHttpCliente.Content.ReadAsStringAsync()
        );

        return response;
    }

    private async Task<Response> SendDeleteRequest(HttpClient client, Request request)
    {
        var responseHttpCliente = await client.DeleteAsync(request.Url);
        Response response = new Response(
            (int)responseHttpCliente.StatusCode,
            responseHttpCliente.RequestMessage.ToString(),
            responseHttpCliente.Content.Headers.ContentType?.MediaType,
            await responseHttpCliente.Content.ReadAsStringAsync()
        );

        return response;
    }
}