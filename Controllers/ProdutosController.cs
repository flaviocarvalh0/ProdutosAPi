using ProdutosAPi.Models;
using ProdutosAPi.Service;
using Microsoft.AspNetCore.Mvc;


namespace ProdutosAPI.Controllers;
[ApiController]
[Route("[controller]")]

public class ProdutoController : ControllerBase
{
    public ProdutoController(){}

    //Chamada Http que pega todos os itens da List de produtos
    [HttpGet]
    public ActionResult<List<Produto>> GetAll() => ProdutoService.GetAll();


    //Chamada Http, porém, passando o id como parametro para recuperarmos apenas um produto. Consulta o banco de dados para uma pizza que corresponda ao parâmetro id fornecido.
    [HttpGet("{id}")]
    public ActionResult<Produto> Get(int id) 
    {
        var produto = ProdutoService.Get(id);

        if(produto == null)
            return NotFound();

        return produto;
    }

    //chamada http que cria um novo produto. O primeiro parâmetro na chamada de método CreatedAtAction representa um nome de ação. A palavra-chave nameof é usada para evitar hard-coding do nome da ação. CreatedAtAction usa o nome da ação para gerar um cabeçalho de resposta HTTP location com uma URL para a pizza recém-criada.
    [HttpPost]
    public IActionResult Create(Produto produto)
    {
        ProdutoService.Add(produto);
        return CreatedAtAction(nameof(Create), new {id = produto.Id}, produto);
    }

    // chamada http que recupera um produto e atualiza o mesmo, Responde apenas ao verbo HTTP PUT, conforme indicado pelo atributo [HttpPut].Requer que o valor do parâmetro id seja incluído no segmento da URL após produto/.Retorna IActionResult porque o tipo de retorno ActionResult não é conhecido até o runtime. Os métodos BadRequest, NotFound e NoContent retornam os tipos BadRequestResult, NotFoundResult e NoContentResult

    [HttpPut("{id}")]
    public IActionResult Update(int id, Produto produto)
    {
        if(id != produto.Id)
            return BadRequest();

        var existeProduto = ProdutoService.Get(id);
            if(existeProduto is null)
                return NotFound();

        ProdutoService.Update(produto);

        return NoContent();
    }


    //chamada http que recupera um id especifico e delete o produto pelo mesmo, Responde apenas ao verbo HTTP DELETE, conforme indicado pelo atributo [HttpDelete].Requer que o valor do parâmetro id seja incluído no segmento da URL após produto/.Retorna IActionResult porque o tipo de retorno ActionResult não é conhecido até o runtime. Os métodos NotFound e NoContent retornam os tipos NotFoundResult e NoContentResult, respectivamente.Consulta o cache na memória para uma produto que corresponde ao parâmetro id fornecid
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = ProdutoService.Get(id);

        if(produto is null)
            return NotFound();

        ProdutoService.Delete(id);

        return NoContent();
    }
}