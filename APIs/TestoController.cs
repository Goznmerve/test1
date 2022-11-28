using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Helpers;
using WebApplication5.Models;

namespace WebApplication5.APIs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TestoController : ControllerBase
    {
        private readonly ITokenHelper _tokenHelper;

        public TestoController(ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }

        [HttpGet("get-data")]
        public IActionResult Getdata()
        {
            return Ok(new { Name = "Merve", Surname = "Gozen" }); 
        }

        [HttpPost("add")]
        public IActionResult PostData([FromBody]PostDataApiModels model)
        {
            return Ok(model);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginViewModel model)
        {
            if( model.Username == "abc" && model.Password == "123123")
            {
                string token = _tokenHelper.GenerateToken(model.Username, 0);

                return Ok(new { Error = false, Message = "Token created", Data = token});
            }
            else
            {
                return BadRequest(new { Error = true, Message = "Incorrect identity." });
            }
        }
    }
}
