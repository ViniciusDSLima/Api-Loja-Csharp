using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Loja_Csharp.Models;
[Table("Categorias")]
public class Categoria
{

    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    [Key]
    public int CategoriaId { get; set; }
    [Required]
    [StringLength(80)]
    public string Name { get; set; }
    [Required]
    [StringLength(300)]
    public string ImagemUrl { get; set; }
    
    public ICollection<Produto> Produtos { get; set; }
}