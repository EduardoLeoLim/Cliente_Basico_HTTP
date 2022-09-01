using System.Threading.Tasks;
using Cliente_Basico_Http.Domain.Model;

namespace Cliente_Basico_Http.Domain.Services;

public interface RequestService
{
    Task<Response> SendRequest(Request request);
}