using System;

namespace LandasBisnis_BackEnd.Settings;

public class JwtSetting
{
    public string Key {get; set;} = null!;
    public string Issuer {get; set;} = null!;
    public string Audience {get; set;} = null!;
}
