using Cliente_Basico_Http.Domain;

namespace Cliente_Basico_Http.Application;

public class ResponseData
{


    public static ResponseData FromAggregate(ResponseHttp responseHttp)
    {

        return new ResponseData();
    }
}