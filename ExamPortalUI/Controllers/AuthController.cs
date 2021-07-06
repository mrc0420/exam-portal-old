using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ExamPortalUI.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost("token")]
        public IActionResult Token()
        {
            var header = Request.Headers["Authorization"];
            if(header.ToString().StartsWith("Basic"))
            {
                var credentialvalue = header.ToString().Substring("Basic".Length).Trim();
                var usernameandPaswwordEncoded = Encoding.UTF8.GetString(Convert.FromBase64String(credentialvalue));
                var usernameandpassword = usernameandPaswwordEncoded.Split(":");
                if (usernameandpassword[0] == "admin" && usernameandpassword[1] == "pass")
                {
                    var claimsdata = new[] { new Claim(ClaimTypes.Name, usernameandpassword[0]) };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mrc"));
                    var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    var token = new JwtSecurityToken(
                        issuer: "mysite.com",
                        audience: "mysite.com",
                        claims: claimsdata,
                        expires: DateTime.Now.AddMinutes(1),
                        signingCredentials: signInCredentials
                        );
                    var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(tokenstring);
                }
            }
            return BadRequest("Request Invalids");
        }
    }
}