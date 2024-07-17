using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers;

public class LoginController : BaseApiController
{
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;

    public LoginController(IConfiguration config, IUserRepository userRepository)
    {
        _config = config;
        _userRepository = userRepository;
    }
    
    [AllowAnonymous]
    [HttpPost]
    
    public ActionResult<PersistedUserDto> Login([FromBody] UserLoginDto userLogin)
    {
        
        var user = Authenticate(userLogin);
        if (user != null)
        {
            var token = Generate(user);

            PersistedUserDto persistedUserDto = new PersistedUserDto
            {
                Email = userLogin.Email,
                Name = user.Name,
                Token = token.ToString()
            };
            
            
            return Ok(persistedUserDto);
        }

        return NotFound("User not found");
    }

    private object? Generate(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("name", user.Name),
            new Claim("email", user.Email),
            new Claim("role", user.Role),
            new Claim("lastname", user.Lastname),
        };

        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: credentials);
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return new { Token = tokenString }.Token;
    }

    private User Authenticate(UserLoginDto userLogin)
    {
        var currentUser = _userRepository.LoginUser(userLogin.Email, userLogin.Password);

        if (currentUser != null)
        {
            return currentUser;
        }

        return null;
    }
    
    
    
}