namespace API.Dtos;

public class AdminRegisterDto
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Lastname { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string City { get; set; }
    
    public string Address { get; set; }
    
    public string Country { get; set; }

    public string Telephone { get; set; }

    public string Role = "Admin";
}