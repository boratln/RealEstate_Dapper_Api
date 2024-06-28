namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenDefault
    {
        public const string ValidAudince = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "RealEstate..01020304Asp.NetCore8.0";
        public const int Expire = 5; //zaman aşım süresi
    }
}
