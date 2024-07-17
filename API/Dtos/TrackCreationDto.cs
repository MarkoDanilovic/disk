using Core.Entities;

namespace API.Dtos;

public class TrackCreationDto 
{
    public string TrackName { get; set; }
    
    public decimal Price { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal Duration { get; set; }
    
    public DateTime PublishDate { get; set; }
    
    public string PictureUrl { get; set; }
    
    public int GenreId { get; set; }
    

    
    public int ProducerId { get; set; }
    
 
    
    public int LabelId { get; set; }
    
    //[System.Text.Json.Serialization.JsonIgnore]
    //public virtual IList<TrackMedium> TrackMedium { get; set; }
    
 
    public int MediumId { get; set; }
}