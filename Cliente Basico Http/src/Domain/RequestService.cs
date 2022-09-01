namespace Cliente_Basico_Http.Domain;

public interface RequestService
{
    ResponseHttp SendRequest(RequestHttp requestHttp);
}