using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Google.Apis.Auth;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using web_api.Data;
using web_api.Models.Home;
using web_api.Models.Info;

namespace web_api.Controllers
{
    [Route("login")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration;

        public AuthenticationController(ApplicationDbContext context, IConfiguration Configuration)
        {
            _context = context;
            _configuration = Configuration;
        }

        [HttpPost]
        public async Task<ActionResult<Event>> Login([FromBody] UserView evnt)
        {
            try
            {
                var payload = GoogleJsonWebSignature
                    .ValidateAsync(evnt.tokenId,
                        new GoogleJsonWebSignature.ValidationSettings()
                            {IssuedAtClockTolerance = TimeSpan.FromSeconds(60), HostedDomain = "alignracing.no"})
                    .Result;

                var user = _context.Users.FirstOrDefault(e => e.Email == payload.Email);

                if (user == null)
                {
                    user = new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = payload.Name,
                        Email = payload.Email,
                        OAuthSubject = payload.Subject,
                        OAuthIssuer = payload.Issuer
                    };
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }

                Console.WriteLine("jwt: " + payload.JwtId);
                Claim[] claims = {new Claim(JwtRegisteredClaimNames.Sub, user.Email),};

                var key = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(_configuration["Appsettings:JwtSecret"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    String.Empty,
                    String.Empty,
                    claims,
                    expires: DateTime.Now.AddSeconds(55 * 60),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch
            {
                // Validation failed user not authorized
                return Unauthorized();
            }
        }
    }
}