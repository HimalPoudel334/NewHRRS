

using System.Linq;
using System.Web.Helpers;
using System.Web.Http;
using HRRS.Dto.Login;
using HRRS.Helpers;
using HRRS.Models;

namespace HRRS.Controllers.Auth
{
    [Route("api")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("signin")]
        public IHttpActionResult SignIn(LoginDto dto)
        {
            var user = DapperHelper.QueryStoredProcedure<User>("sp_GetUserByUserName", dto.userName).FirstOrDefault();
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.password, user.password))
            {
                return Ok(new ResultDto<string>(false, null, "Invalid Username or Password"));
            }
            //return GenerateAuthResponse(user);
            return Ok(user);
        }

        /*private ResultDto<LoggedInUser> GenerateAuthResponse(User user)
        {
            var token = _tokenService.GenerateJwt(loggedInUser);

            var loggedInUser = new LoggedInUser()
            {
                user = user, token = token
            };
            var authResponse = new AuthResponseDto(loggedInUser, token);
            return ResultWithDataDto<AuthResponseDto>.Success(authResponse);
        }

        

        public class LoggedInUser
        {
            public User user { get; set; }
            public string token { get; set; }

        }
        */



    }
}