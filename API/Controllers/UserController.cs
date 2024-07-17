using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;

using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UserController : BaseApiController
{
    private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;
    private readonly StoreContext _context;


    public UserController(IUserRepository userRepo, IMapper mapper, StoreContext context)
    {
        _userRepo = userRepo;
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    public IActionResult Endpoint()
    {
        var currentUser = GetCurrentUser();
        return Ok(currentUser);
    }

    [HttpGet]
    private bool GetUserByEmail(String email)
    {
        bool exists = _userRepo.GetUserByEmail(email);
        if (exists)
        {
            return true;
        }

        return false;
    }

    [HttpPost("admin")]
    public ActionResult AdminRegister([FromBody]AdminRegisterDto adminDto)
    {
        if (adminDto != null)
        {
            

            if (!GetUserByEmail(adminDto.Email))
            {
                var user2 = _mapper.Map<User>(adminDto);
                Console.WriteLine(user2);
                //_userRepo.Register(user);
                _context.Add(user2);
            
                _context.SaveChanges();
                return Ok(user2);
            }

            


        }

        return Conflict(new ApiResponse(409));
    }
    
    [HttpPost("user")]
    public ActionResult UserRegister([FromBody]UserRegisterDto userDto)
    {
        if (userDto != null)
        {
            
            

            if (!GetUserByEmail(userDto.Email))
            {
                var user2 = _mapper.Map<User>(userDto);
                Console.WriteLine(user2);
                //_userRepo.Register(user);
                _context.Add(user2);
            
                _context.SaveChanges();
                return Ok(user2);
            }
        }
        
            return Conflict(new ApiResponse(409));
    }

    

    [HttpDelete("{Id}")]
    public IActionResult DeleteUser(int id)
    {
        try
        {
            if (id != null)
            {
                _userRepo.DeleteUser(id);
            
                return Ok();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
            throw;
        }

        return null;

    }

    [HttpPut]
    public IActionResult UpdateUser([FromBody]User user)
    {
        var oldUser = _userRepo.GetUserById(user.Id);
        if (oldUser != null)
        {
            _mapper.Map(user, oldUser);
            _userRepo.SaveChanges();
            return Ok(user);
        }

        return NotFound();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        if (id != null)
        {
            var user = _userRepo.GetUserById(id);
            return Ok(user);
        }

        return NoContent();
    }
    
    [HttpGet("user")]
    public async Task<ActionResult<IReadOnlyList<User>>> GetUsers()
    {
        

        return Ok(await _userRepo.ListAllAsync());
    }
    
    
    private User GetCurrentUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if (identity != null)
        {
            var userClaims = identity.Claims;

            return new User
            {
                Name = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                Lastname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                
            };
        }

        return null;
    }

    [HttpGet("email/{email}")]
    public int GetUserIdByEmail(string email)
    {
        return _userRepo.GetUserIdByEmail(email);
    }

    //Ovu metodu za sada nećeš koristiti
    private string HashPassword(string password)
    {
        SHA512 hash = SHA512.Create();
        var passwordBytes = Encoding.Default.GetBytes(password);
        var hahsedpassword = hash.ComputeHash(passwordBytes);
        return Convert.ToHexString(hahsedpassword);
    }
    
}