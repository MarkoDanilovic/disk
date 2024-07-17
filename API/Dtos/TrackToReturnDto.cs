using Core.Entities;

namespace API.Dtos;

public class TrackToReturnDto
{
    
    public int Id { get; set; }
    
    public string TrackName { get; set; }
    
    public decimal Price { get; set; }
    
    public decimal Duration { get; set; }
    
    public DateTime PublishDate { get; set; }
    
    public string PictureUrl { get; set; }
    
    public string Genre { get; set; }

    public string Producer { get; set; }
    
    public string Label { get; set; }
    
    public int Quantity { get; set; }
    
    public string Medium { get; set; }


}