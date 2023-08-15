using System.ComponentModel.DataAnnotations.Schema;

namespace WebExercicios.Infra.Database.Models;
public class CategoriaProdutos
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set;}
    public string Nome { get; set; }
    public bool Ativo { get; set; }

    public List<Produto> produtos { get; set; }
}
