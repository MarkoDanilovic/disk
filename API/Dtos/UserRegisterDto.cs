using System.CodeDom.Compiler;

namespace API.Dtos;

public class UserRegisterDto
{
    
    
    public string Name { get; set; }
    
    public string Lastname { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string City { get; set; }
    
    public string Address { get; set; }
    
    public string Country { get; set; }

    public string Telephone { get; set; }

    public string Role = "User";
}