using AuthKeyApi.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace AuthKeyApi.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class AuthController : ControllerBase
    {
        /*public readonly Dictionary<string, string> keyValues;
        
        public string AuthKey { get; set; }*/
        public AuthKey dv = new AuthKey();
       

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(AuthenticationKey))]
        [ProducesResponseType(500)]
        
        public ActionResult<Dictionary<string, string>> Get()
        {
            var key = dv.getAuthKey().Result;
            Dictionary<string, string> AuthKey = new Dictionary<string, string>();
            AuthKey.Add("AuthenticationKey", key);
            return Ok(AuthKey);
        }
    }
}
