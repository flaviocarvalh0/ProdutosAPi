
using ProdutosAPI.Enum;

namespace  ProdutosAPi.Models;

public class Produto
{
    public int id { get; set; }
    public string? nome { get; set; }
    public string? preco { get; set; }
    public string? descricao { get; set; }
    public string? urlImagen { get; set; }
    public Categoria Categoria {get; set;}
    
}