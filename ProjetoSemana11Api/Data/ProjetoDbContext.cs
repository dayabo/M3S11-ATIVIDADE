using Microsoft.EntityFrameworkCore;
using ProjetoSemana11Api.Models;

namespace ProjetoSemana11Api.Data
{
    public class ProjetoDbContext:DbContext
    {
        // DBset cria as tabelas no banco
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CarteiraTrabalho> CarteirasTrabalho { get; set; }
        public DbSet<Vacina> Vacinas { get; set; }
        public DbSet<ClienteVacina> ClientesVacinas { get; set; }
        public DbSet<Exame> Exames { get; set; }

        private IConfiguration _configuration;

        public ProjetoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CONEXAO_BANCO"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Mapeamento da classe cliente
            modelBuilder.Entity<Cliente>().ToTable("Clientes");

            modelBuilder.Entity<Cliente>().HasKey(c=>c.Id);

            modelBuilder.Entity<Cliente>().Property(c=> c.Nome).HasMaxLength(200).IsRequired();

            modelBuilder.Entity<Cliente>().Property(c => c.DataNascimento);

            //Mapeamento de relação 1,1 cliente e carteira de trabalho
            modelBuilder.Entity<Cliente>().HasOne<CarteiraTrabalho>(cliente => cliente.CarteiraTrabalho).WithOne(carteira=> carteira.Cliente).HasForeignKey<CarteiraTrabalho>(carteira=> carteira.ClienteId);

      



            //Mapeamento da classe carteira de trabalho
            modelBuilder.Entity<CarteiraTrabalho>().ToTable("CarteirasTrabalho");

            modelBuilder.Entity<CarteiraTrabalho>().HasKey(ct => ct.Id);

            modelBuilder.Entity<CarteiraTrabalho>().Property(ct => ct.PisPassep).HasMaxLength(20).IsRequired();



            //Mapeamento da classe Exame
            modelBuilder.Entity <Exame>().ToTable("Exame");
            modelBuilder.Entity<Exame>().HasKey(e => e.Id);

            modelBuilder.Entity<Exame>().Property(e => e.CodigoTuss).HasMaxLength(20);

            modelBuilder.Entity<Exame>().Property(e => e.DataAgendamento);


            //Mapeamento de relação 1,N cliente e exame

            modelBuilder.Entity<Exame>().HasOne<Cliente>(exame => exame.Cliente).WithMany(cliente => cliente.Exames).HasForeignKey(exame => exame.ClienteId).OnDelete(DeleteBehavior.Restrict);




            //Mapeamento da classe Vacina
            modelBuilder.Entity<Vacina>().ToTable("Vacinas");
            modelBuilder.Entity<Vacina>().HasKey(v => v.Id);

            modelBuilder.Entity<Vacina>().Property(v => v.Nome).HasMaxLength(200).IsRequired();
             
            //HasDefaultValue(1) caso o vaor for null reiniciara com 1
            modelBuilder.Entity<Vacina>().Property(v => v.NumeroDoses).IsRequired().HasDefaultValue(1);



            //Mapeamento da classe ClienteVacina
            modelBuilder.Entity<ClienteVacina>().ToTable("ClienteVacina");
            modelBuilder.Entity<ClienteVacina>().HasKey(cv => new { cv.ClienteId, cv.VacinaId});

            modelBuilder.Entity<ClienteVacina>().Property(cv => cv.DataAplicacao).IsRequired();


            //Mapeamento de relação N,N cliente e Clientevacina

            modelBuilder.Entity<ClienteVacina>().HasOne<Cliente>(clientev => clientev.Cliente).WithMany(cliente => cliente.Vacinas).HasForeignKey(cv => cv.ClienteId).OnDelete(DeleteBehavior.Restrict);


            //Mapeamento de relação N,N  ClienteVacina e Vacina 

            modelBuilder.Entity<ClienteVacina>().HasOne<Vacina>(cliente => cliente.Vacina).WithMany().HasForeignKey(cv => cv.VacinaId).OnDelete(DeleteBehavior.Restrict); 


        }

    }
}
