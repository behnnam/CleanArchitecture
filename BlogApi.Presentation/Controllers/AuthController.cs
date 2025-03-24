using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Blog.Api.Command.DtoIn.DtoIn;

namespace BlogApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {


        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto input)
        {
            _logger.LogError(input.UserName,"user not finde");
            _logger.LogInformation(input.UserName, "user not finde");

       

            if (input != null )
            {
                if (input.UserName.ToLower() == "user" && input.Password == "123456")
                {

                    var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-256-bit-secret-32-bytes"));
                    var singinkey = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha512);
                    var tolenoption = new JwtSecurityToken(

                        issuer: "https://localhost:44384",
                        claims: new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,input.UserName),
                            new Claim(ClaimTypes.Role,"admin"),


                        },
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: singinkey
                        );

                    var token = new JwtSecurityTokenHandler().WriteToken(tolenoption);

                    return Ok(new { Code=200,Obj=token,Message="موفق"});

                }
                else
                {

                 
                    Unauthorized();

                    return Ok(new { Code = 0, Obj ="", Message = "کاربر یافت نشد" });
                }


            }
            return Ok(new { Code = 0, Obj = "", Message = "کاربر یافت نشد" });
        }

    }
}
