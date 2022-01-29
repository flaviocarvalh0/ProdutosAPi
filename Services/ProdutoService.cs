
using ProdutosAPi.Models;

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
                new Produto {Id = 1, Name = "Steak", Preco = 13.00, Descricao = "carne e pão", UrlImagen = "imagen.com" },
                new Produto {Id = 2, Name = "Pork", Preco = 18.00, Descricao = "carne e pão , porco", UrlImagen = "imagen2.com" }
            };


        }

        public static List<Produto> GetAll() => Produtos!;

        public static Produto? Get(int id) => Produtos!.FirstOrDefault(p => p.Id == id);

        public static void Add(Produto produto)
        {
            produto.Id = proxId++;
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
            var index = Produtos!.FindIndex(p => p.Id == produto.Id);
            if (index == -1)
                return;
            Produtos[index] = produto;

        }
    }
}
