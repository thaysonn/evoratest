namespace Padaria.Domain.Entities;

public class UsaurioPerdmissao
{
    public required virtual Usuario Usuario { get; set; }
    public required virtual Permissao Permissao { get; set; }
}
