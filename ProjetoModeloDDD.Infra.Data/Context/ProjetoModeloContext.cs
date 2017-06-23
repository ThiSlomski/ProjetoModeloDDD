using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjetoModeloDDD.Infra.Data.EntityConfig;
using System;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext()
            : base("connectionStringProjetoModeloDDD")
        {

        }

        public DbSet<Domain.Entities.Cliente> Clientes { get; set; }
        public DbSet<Domain.Entities.Produto> Produtos { get; set; }


        /// <summary>
        /// Customizando convenções
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Não pluralizar as tabelas no Banco
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); // Não deletar em cascata
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); // Não deletar em cascata

            // Quando uma propriedade for o Nome mais Id entender como uma chave primária
            modelBuilder.Properties()
                .Where(p => p.Name == string.Concat(p.ReflectedType.Name, "Id"))
                .Configure(p => p.IsKey());

            // Para criar as strings como varchar ao invés de nVarChar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));
            modelBuilder.Properties<DateTime>().Configure(p => p.HasColumnType("datetime"));


            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());

        }
        public override int SaveChanges()
        {
            foreach (var entity in ChangeTracker.Entries().Where(entity => entity.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entity.State == EntityState.Modified)
                {
                    entity.Property("DataCadastro").IsModified = false;
                }

            }

            return base.SaveChanges();
        }



    }
}
