using System.Collections.Generic;

namespace EFCodeFirstSample.Models
{
    public class Categoria
    {
        public Categoria()
        {
            this.Livros = new List<Livro>();
        }

        public int CategoriaId { get; set; }
        public string Titulo { get; set; }

        //1 to many
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
