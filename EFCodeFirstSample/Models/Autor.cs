using System.Collections.Generic;

namespace EFCodeFirstSample.Models
{
    public class Autor
    {
        public Autor()
        {
            this.Livros = new List<Livro>();
        }

        public int AutorId { get; set; }
        public string Nome { get; set; }

        //many to many
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
