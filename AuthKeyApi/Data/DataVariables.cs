namespace AuthKeyApi.Data
{
    public class DataVariables
    {
        private readonly string _clientKey = "MXDZDGSECDLMSEOIYCZH";
        private readonly string _privateKey = "GW5Z48P534GHP6JCX2ZALMBU94F0B8OI";
        private readonly string _publicKeyApi = "http://172.27.27.7:8080/api/UCAMAPI/core/v3/GetKey";

        public DataVariables()
        {
            var ck = _clientKey;
            var prk = _privateKey;
            var puk = _publicKeyApi;
        }

    }
}
