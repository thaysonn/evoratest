using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria.Domain.Entities;

[Table("Orders")]
public class Pedido : BaseEntity
{
    [Column("IdProduto")]
    public int? IdProduto { get; set; }
    [ForeignKey("IdProduto")]
    public virtual Produto Produto { get; set; }
    public required int Quantidade { get; set; }
    public required string Status { get; set; }
}
