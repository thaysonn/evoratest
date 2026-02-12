using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria.Domain.Entities;

[Table("Products")]
public class Produto : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; } 
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
