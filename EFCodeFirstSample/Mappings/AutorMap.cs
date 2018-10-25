using System.Data.Entity.ModelConfiguration;
using EFCodeFirstSample.Models;

namespace EFCodeFirstSample.Mappings
{
    public class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("Autor");

            HasKey(x => x.AutorId);

            Property(x => x.Nome).HasMaxLength(80).IsRequired();

            //many to many
            //tem muitos livros com muitos autores
            HasMany(x => x.Livros)
                .WithMany(x => x.Autores)
                //tabela associativa
                .Map(x => x.ToTable("LivroAutor"));
        }
    }
}
