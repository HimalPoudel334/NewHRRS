

using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;
using HRRS.Dto.Login;
using HRRS.Helpers;
using HRRS.Models;
using Microsoft.IdentityModel.Tokens;

namespace HRRS.Controllers.Auth
{
    [Route("api")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/signin")]
        public IHttpActionResult SignIn(LoginDto dto)
        {
            var user = DapperHelper.QueryStoredProcedure<User>("sp_GetUserByUserName", new { userName = dto.username }).FirstOrDefault();
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.password, user.password))
            {
                return Ok(new ResultDto<string>(false, null, "Invalid Username or Password"));
            }

            var authresp = new AuthResponseDto()
            {
                user = new LoggedInUser()
                {
                    username = user.username,
                    userId = user.userId,
                    userType = user.userType,
                },
                token = CreateToken(user)
            };
            return Ok(new ResultDto<AuthResponseDto>(true, authresp));
        }

        public static string CreateToken(User user)
        {
            var secretKey = ConfigurationManager.AppSettings["JWT:SecretKey"];
            var issuer = ConfigurationManager.AppSettings["JWT:Issuer"];
            var audience = ConfigurationManager.AppSettings["JWT:Audience"];
            var expiresInMinutes = int.Parse(ConfigurationManager.AppSettings["JWT:ExpiresInMinute"]);

            var symmetricKey = Encoding.UTF8.GetBytes(secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.username),
                    new Claim(ClaimTypes.NameIdentifier, user.userId.ToString()),
                    new Claim(ClaimTypes.Role, user.userType.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(expiresInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer,
                Audience = audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }


    public class JwtAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader != null && authHeader.Scheme == "Bearer")
            {
                var token = authHeader.Parameter;
                return JwtValidator.ValidateToken(token);
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }


    public class JwtValidator
    {
        public static bool ValidateToken(string token)
        {
            var secretKey = ConfigurationManager.AppSettings["JWT:SecretKey"];
            var issuer = ConfigurationManager.AppSettings["JWT:Issuer"];
            var audience = ConfigurationManager.AppSettings["JWT:Audience"];

            var symmetricKey = Encoding.UTF8.GetBytes(secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false; // If validation fails, return false
            }
        }
    }

}