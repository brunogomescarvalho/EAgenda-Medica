namespace EAgendaMedica.Infra.Compartilhado
{
    public class EAgendaMedicaDBContext : DbContext, IContextoPersistencia
    {
        public EAgendaMedicaDBContext(DbContextOptions options) : base(options)
        {
        }

        public async Task SalvarDados()
        {
            await this.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type tipo = typeof(EAgendaMedicaDBContext);

            Assembly dllComConfiguracoesOrm = tipo.Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);

            base.OnModelCreating(modelBuilder);

        }
    }


}