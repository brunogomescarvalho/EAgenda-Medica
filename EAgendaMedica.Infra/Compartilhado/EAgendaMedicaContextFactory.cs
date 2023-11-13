namespace EAgendaMedica.Infra.Compartilhado
{
    public class EAgendaMedicaContextFactory : IDesignTimeDbContextFactory<EAgendaMedicaDBContext>
    {
        public EAgendaMedicaDBContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<EAgendaMedicaDBContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new EAgendaMedicaDBContext(optionsBuilder.Options);
        }
    }
}
