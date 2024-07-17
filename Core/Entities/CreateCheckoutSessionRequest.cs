using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class CreateCheckoutSessionRequest
{
    [Required]
    public string PriceId { get; set; }
}