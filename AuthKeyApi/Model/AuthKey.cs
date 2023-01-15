using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace AuthKeyApi.Model
{

    public class AuthKey
    {
        public string clientKey { get; set; }
        public string privateKey { get; set; }
        public string publicKeyBaseUrl { get; set; } 
        public string publicKeyEndPoint { get; set; } 
        public string Auth { get; set; } 
        public string ErrorMsg { get; set; } 

        public AuthKey()
        {
            clientKey = "MXDZDGSECDLMSEOIYCZH";
            privateKey = "GW5Z48P534GHP6JCX2ZALMBU94F0B8OI";
            publicKeyBaseUrl = "http://172.27.27.7:8080/";
            publicKeyEndPoint = "api/UCAMAPI/core/v3/GetKey";
            ErrorMsg = "Theres an error";
        }

        public string  ToHash( string s)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
            var sb = new StringBuilder();
            for(int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
        
        public Dictionary<string, string> getKeyValues() { 
            var keyValues = new Dictionary<string, string>();
            keyValues.Add("clk", clientKey);
            keyValues.Add("prk", privateKey);
            keyValues.Add("pbu", publicKeyBaseUrl);
            keyValues.Add("pep", publicKeyEndPoint);

            return keyValues;
        }
  
        public async Task<AuthKey> getPublicKey()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{publicKeyBaseUrl}");
                var response = await client.GetAsync($"{publicKeyEndPoint}/{publicKeyEndPoint}");
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonSerializer.Deserialize<AuthKey>(await response.Content.ReadAsStringAsync());
                    return result;
                }
                else
                {

                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Dictionary<string, string>> getAuthKey()

        {
            /*var publicKey = await getPublicKey();*/
            var publicKey = "idkfhfghew83hyu939";
            var hashString = $"{publicKey} + {clientKey} + {privateKey}";
            Auth = ToHash(hashString);
            var AuthDict = new Dictionary<string, string>();
            AuthDict.Add("AuthenticationKey", Auth);
            return AuthDict;
        }

    }
}
