using System.Data.Entity.ModelConfiguration;
using EFCodeFirstSample.Models;

namespace EFCodeFirstSample.Mappings
{
    public class LivroMap : EntityTypeConfiguration<Livro>
    {
        public LivroMap()
        {
            ToTable("Livro");

            HasKey(x => x.LivroId);

            Property(x => x.Titulo)
                .HasMaxLength(80)
                .IsRequired();

            Property(x => x.CategoriaId)
               .IsOptional();

            #region "many to many"

            HasMany(x => x.Autores);

            //HasMany(x => x.Autores)
            //    .WithMany(x => x.Livros)
            //    .Map(x => x.ToTable("LivroAutor"));

            #endregion

            #region "1 to many"

            //HasRequired(x => x.Categoria);
            //HasOptional(x => x.Categoria);

            HasOptional(c => c.Categoria)
                 .WithMany(l => l.Livros)
                .HasForeignKey(c => c.CategoriaId)
                //desabilita o delete cascade
                .WillCascadeOnDelete(false);

            #endregion
        }
    }
}
