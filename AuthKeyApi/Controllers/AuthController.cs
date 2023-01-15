using AuthKeyApi.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace AuthKeyApi.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /*public readonly Dictionary<string, string> keyValues;
        
        public string AuthKey { get; set; }*/
        public AuthKey dv = new AuthKey();
        private Task<Dictionary<string, string>> _getKey;
        public AuthController() => _getKey = dv.getAuthKey();
        [HttpGet]
        public ActionResult<Dictionary<string, string>> Get()
        {
            return Ok(_getKey);
        }
    }
}
