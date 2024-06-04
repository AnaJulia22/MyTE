using Microsoft.EntityFrameworkCore;
using ProjetoMyTe.AppWeb.Models.Entities;

namespace ProjetoMyTe.AppWeb.Models.Contexts
{
    public class MyTeContext : DbContext
    {
        public MyTeContext(DbContextOptions<MyTeContext> options) : base(options){ }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Wbs> Wbss { get; set; }
        public DbSet<RegistroHoras> RegistroHoras { get; set;}
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //Mapeamento das entidades para as tabelas
            modelBuilder.Entity<Cargo>().ToTable("TB_CARGOS");
            modelBuilder.Entity<Colaborador>().ToTable("TB_COLABORADORES");
            modelBuilder.Entity<Wbs>().ToTable("TB_WBS");
            modelBuilder.Entity<RegistroHoras>().ToTable("TB_REGISTRO_DIAS_HORAS");
           
            //Mapeamento das propriedade para as colunas
            modelBuilder.Entity<Cargo>()
                .Property(p => p.Descricao)
                .HasColumnName("nomeCargo")
                .HasMaxLength(100);

            modelBuilder.Entity<Colaborador>()
                .Property(p => p.Id)
                .HasColumnName("cpf")
                .HasMaxLength(11);

            modelBuilder.Entity<Colaborador>()
                .Property(p => p.CargoId)
                .HasColumnName("id_cargo");

            modelBuilder.Entity<Colaborador>()
                .Property(p => p.Nome)
                .HasColumnName("nome");

            modelBuilder.Entity<Colaborador>()
                .Property(p => p.Perfil)
                .HasColumnName("perfil");

            modelBuilder.Entity<Wbs>()
                .Property(p => p.Codigo)
                .HasColumnName("codigo")
                .HasMaxLength(10);

            modelBuilder.Entity<Wbs>()
                .Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(100);

            modelBuilder.Entity<Wbs>()
                .Property(p => p.Tipo)
                .HasColumnName("tipo");


            modelBuilder.Entity<RegistroHoras>()
                .Property(p => p.Id).ValueGeneratedOnAdd()
                .HasColumnName("id");

            modelBuilder.Entity<RegistroHoras>()
                .Property(p => p.DataRegistro)
                .HasColumnName("data_registro");

            modelBuilder.Entity<RegistroHoras>()
                .Property(p => p.WbsId)
                .HasColumnName("id_wbs");

            modelBuilder.Entity<RegistroHoras>()
                .Property(p => p.CpfId)
                .HasColumnName("cpf");

            modelBuilder.Entity<RegistroHoras>()
                .Property(p => p.Dia)
                .HasColumnName("dia");

            modelBuilder.Entity<RegistroHoras>()
                .Property(p => p.Horas)
                .HasColumnName("horas");

        }
    }
    
}
