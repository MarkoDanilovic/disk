namespace Core.Entities;

public class Track : BaseEntity
{

    public string TrackName { get; set; }
    
    public decimal Price { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal Duration { get; set; }
    
    public DateTime PublishDate { get; set; }
    
    public string PictureUrl { get; set; }
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Genre Genre { get; set; }
    
    public int GenreId { get; set; }
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Producer Producer { get; set; }
    
    public int ProducerId { get; set; }
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Label Label { get; set; }
    
    public int LabelId { get; set; }
    
    //[System.Text.Json.Serialization.JsonIgnore]
    //public virtual IList<TrackMedium> TrackMedium { get; set; }
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Medium  Medium { get; set; }
    public int MediumId { get; set; }
    
    
}