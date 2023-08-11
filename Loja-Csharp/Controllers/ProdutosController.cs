using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Loja_Csharp.Context;
using Loja_Csharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Loja_Csharp.Controllers;

[Controller]
[Route("api/v1/produtos")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _context.Produtos.ToList();

        if (produtos != null)
        {
            return produtos;
        }

        return NotFound();
    }

    [HttpGet]
    [Route("/{id:int}")]
    public ActionResult<Produto> GetById([FromBody] int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

        if (produto != null)
        {
            return produto;
        }
        else
        {
            return NotFound();
        }

        [HttpPost]
        [Route("cadastrar")]
        ActionResult Cadastrar(Produto produto)
        {

            if (produto == null)
            {
                return BadRequest();
            }
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

        [HttpPut]
        [Route("atualizar/{id : int}")]
        ActionResult atualizar(int Id)
        {
            if (Id != produto.ProdutoId)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(produto);

            }
        }

        [HttpDelete]
        [Route("apagar/{id:int}")]
        ActionResult apagar(int id)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Deleted;
            _context.SaveChanges();

            return NoContent();
        }
    }
}