using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JWTToken.Models;
using JWTToken.Provider;
using JWTToken.Repository;
using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;



namespace JWTToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IPensionRepo repo;

        public AuthController(IConfiguration config, IPensionRepo repo)
        {
            this.config = config;
            this.repo = repo;
        }

        [HttpPost]
        public IActionResult Login([FromBody] PensionerCredentials login)
        {
            AuthRepo auth_repo = new AuthRepo(config, repo);
            //_log4net.Info("Login initiated!");
            IActionResult response = Unauthorized();
            //login.FullName = "user1";
            var user = auth_repo.AuthenticateUser(login);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var tokenString = auth_repo.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
    }
}
