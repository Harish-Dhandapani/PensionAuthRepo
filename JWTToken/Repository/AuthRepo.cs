using JWTToken.Models;
using JWTToken.Provider;
using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace JWTToken.Repository
{
    public class AuthRepo
    {
        private readonly IConfiguration config;
        private readonly IPensionRepo repo;

        public AuthRepo(IConfiguration config, IPensionRepo repo)
        {
            this.config = config;
            this.repo = repo;
        }

        public string GenerateJSONWebToken(PensionerCredentials userInfo)
        {
            //_log4net.Info("Token Is Generated!");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
              issuer: config["Jwt:Issuer"],
              audience: config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public PensionerCredentials AuthenticateUser(PensionerCredentials login)
        {
            //_log4net.Info("Validating the User!");

            //Validate the User Credentials 
            PensionerCredentials usr = repo.GetPensionerCred(login);


            return usr;
        }

    }
}
