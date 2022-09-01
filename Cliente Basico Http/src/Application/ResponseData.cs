using Cliente_Basico_Http.Domain;
using Cliente_Basico_Http.Domain.Model;

namespace Cliente_Basico_Http.Application;

public class ResponseData
{


    public static ResponseData FromAggregate(Response response)
    {

        return new ResponseData();
    }
}