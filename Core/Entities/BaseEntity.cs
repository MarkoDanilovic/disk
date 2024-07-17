using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;
using System.Text.Json;

namespace Core.Entities;

public abstract class BaseEntity
{
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
    public int Id { get; set; }
}