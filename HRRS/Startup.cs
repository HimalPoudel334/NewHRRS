using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Web;
using HRRS.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly: OwinStartup(typeof(HRRS.Startup))]

namespace HRRS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var secretKey = ConfigurationManager.AppSettings["JWT:SecretKey"];
            var issuer = ConfigurationManager.AppSettings["JWT:Issuer"];
            var audience = ConfigurationManager.AppSettings["JWT:Audience"];
            var symmetricKey = Encoding.UTF8.GetBytes(secretKey);

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions()
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                }

            });

            

        }
    }
}