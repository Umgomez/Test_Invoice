﻿using Newtonsoft.Json;

namespace Test_Invoice.Services;

public class BaseService
{
    public Dictionary<string, string> GetData(string Json)
    {
        Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(Json);
        return data;
    }
    public Dictionary<string, object> GetData2(string Json)
    {
        Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(Json);
        return data;
    }
}
