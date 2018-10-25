using System.Collections.Generic;

namespace EFCodeFirstSample.Models
{
    public class Livro
    {
        public Livro()
        {
            this.Autores = new List<Autor>();
        }

        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public int CategoriaId { get; set; }

        //1 to many
        public virtual Categoria Categoria { get; set; }

        //many to many
        public virtual ICollection<Autor> Autores { get; set; }
    }
}
