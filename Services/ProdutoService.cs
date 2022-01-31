
using ProdutosAPi.Models;
using ProdutosAPI.Enum;
namespace ProdutosAPi.Service

{
    public class ProdutoService
    {
        static List<Produto>? Produtos { get; }
        static int proxId = 3;
        static ProdutoService()
        {
            Produtos = new List<Produto>
            {
                new Produto{    id = 1,
                                Categoria = Categoria.Hamburguer,
                                nome = "Steak House",
                                preco = "17.00",
                                descricao = "Pão brioche, 2x smash de carne, ",
                                urlImagen = "https://i.imgur.com/9uOQ0rR.jpg"

                            },
                new Produto{    id = 2,
                                Categoria = Categoria.Hamburguer,
                                nome = "Steak House",
                                preco = "17.00",
                                descricao = "Pão brioche, 2x smash de carne, ",
                                urlImagen = "https://i.imgur.com/9uOQ0rR.jpg"

                            },
                new Produto{    id = 3,
                                Categoria = Categoria.Bebida,
                                nome = "Coca",
                                preco = "17.00",
                                descricao = "Pão brioche, 2x smash de carne, ",
                                urlImagen = "https://i.imgur.com/9uOQ0rR.jpg"

                            },
                new Produto{    id = 4,
                                Categoria = Categoria.Salgado,
                                nome = "frango",
                                preco = "17.00",
                                descricao = "Pão brioche, 2x smash de carne, ",
                                urlImagen = "https://i.imgur.com/9uOQ0rR.jpg"

                            },
                new Produto{    id = 5,
                                Categoria = Categoria.Adicional,
                                nome = "carne",
                                preco = "17.00",
                                descricao = "Pão brioche, 2x smash de carne, ",
                                urlImagen = "https://i.imgur.com/9uOQ0rR.jpg"

                            }


            };


        }

        public static List<Produto> GetAll() => Produtos!;

        public static List<Produto> Get(Categoria categoria) => Produtos!.FindAll(p => p.Categoria == categoria);

        public static Produto? Get(int id) => Produtos!.FirstOrDefault(p => p.id == id);

        public static void Add(Produto produto)
        {
            produto.id = proxId++;
            Produtos!.Add(produto);
        }

        public static void Delete(int id)
        {
            var produto = Get(id);
            if (produto is null)
                return;
            Produtos!.Remove(produto);
        }
        public static void Update(Produto produto)
        {
            var index = Produtos!.FindIndex(p => p.id == produto.id);
            if (index == -1)
                return;
            Produtos[index] = produto;

        }
    }
}
