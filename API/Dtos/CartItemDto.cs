namespace API.Dtos;

public class CartItemDto
{
    
    
    public int CartId { get; set; }
    
    //public virtual CartDto Cart { get; set; }
    
    public int TrackId { get; set; }
    
    //public virtual TrackToReturnDto Track { get; set; }
    
    public int Quantity { get; set; }
}