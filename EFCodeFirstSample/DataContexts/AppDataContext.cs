using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EFCodeFirstSample.Mappings;
using EFCodeFirstSample.Models;

namespace EFCodeFirstSample.DataContexts
{
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            : base("MinhaConnectionString")
        {
            
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Convenções

            //remove a propriedade de criar tabela com plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //remove o delete cascate de um para muitos
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //remove o delete cascate de muitos para muitos
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //configura o tipo "string" como "varchar" no BD
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //configura o tamanho como "varchar" de 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            #endregion

            modelBuilder.Configurations.Add(new AutorMap());
            modelBuilder.Configurations.Add(new LivroMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
