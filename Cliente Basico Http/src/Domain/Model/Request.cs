﻿using System.Collections.Generic;
using Cliente_Basico_Http.Domain.Enums;

namespace Cliente_Basico_Http.Domain.Model;

public class Request
{
    public Methods Method { get; }
    public string Url { get; }
    public Dictionary<string, string> Parameters { get; }

    public Request(Methods method, string url, Dictionary<string, string> parameters)
    {
        Method = method;
        Url = url;
        Parameters = parameters;
    }
}