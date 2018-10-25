using System.Data.Entity.ModelConfiguration;
using EFCodeFirstSample.Models;

namespace EFCodeFirstSample.Mappings
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");

            HasKey(x => x.CategoriaId);

            Property(x => x.Titulo)
                .HasMaxLength(30)
                .IsRequired();

            //uma categoria tem muitos livros
            HasMany(x => x.Livros);
        }
    }
}
