using apiAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace apiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //For admin only
        [HttpGet]
        [Route("Admins")]
        [Authorize(Roles ="Admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok(ValidateCurrentUser(currentUser));
        }

        private string ValidateCurrentUser(UserModel currentUser)
        {
            if(currentUser == null)
            {
                return "Usuario invalido para este perfil";
            }
            else
            {
                return $"Ola {currentUser.UserName}, seu perfil de acesso é {currentUser.Role}";
            }
        }

        //For admin only
        [HttpGet]
        [Route("CUsers")]
        [Authorize(Roles = "chatUser")]
        public IActionResult ChatEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok(ValidateCurrentUser(currentUser));
        }

        private UserModel GetCurrentUser()
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
