using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace API.Dtos;

public class CartDto
{
    public int Id { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public decimal Subtotal { get; set; }
    
    public string Comment { get; set; }
    
    public string PaymentMethod { get; set; }
    
    public bool Payment { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    //public string FirstName { get; set; }
    
    //public string LastName { get; set; }
    
    public int  UserId { get; set; }
    
    public virtual ICollection<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();
}
