using Loja_Csharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loja_Csharp.Context;

[Controller]
[Route("api/v1/categorias")]
public class CategoriaController : ControllerBase
{

    private readonly AppDbContext _context;

    public CategoriaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> GetAll()
    {
        var categorias = _context.Categorias.ToList();

        if (categorias == null)
        {
            return NotFound();
        }
        else
        {
            return categorias;
        }
    }

    [HttpGet("/{Id:int}")]
    public ActionResult<Categoria> GetById( int Id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == Id);

        if (categoria != null)
        {
            return categoria;
        }
        else
        {
            return NotFound();
        }
    }
}