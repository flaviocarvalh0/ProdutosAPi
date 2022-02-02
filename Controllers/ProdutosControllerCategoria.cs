using ProdutosAPi.Models;
using ProdutosAPI.Enum;
using ProdutosAPi.Service;
using Microsoft.AspNetCore.Mvc;


namespace ProdutosAPI.ControllersCategoria;
[ApiController]
[Route("Produto/[controller]")]


public class Category : ControllerBase
{
    public Category(){}

    [HttpGet]
    public ActionResult<List<Categoria>> GetAllCategoria() => ProdutoService.GetAllCategoria();

    [HttpGet("{categoria}")]
    public ActionResult<List<Produto>> Get(Categoria categoria) 
    {
        var produto = ProdutoService.Get(categoria);

        if(produto == null)
            return NotFound();

        return produto;
    }

    

}