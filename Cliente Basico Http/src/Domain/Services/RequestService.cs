using Cliente_Basico_Http.Domain.Model;

namespace Cliente_Basico_Http.Domain.Services;

public interface RequestService
{
    Response SendRequest(Request request);
}