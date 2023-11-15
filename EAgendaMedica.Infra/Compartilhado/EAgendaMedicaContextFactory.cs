using Microsoft.Extensions.Configuration;

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

            string connectionString;

            var optionsBuilder = new DbContextOptionsBuilder<EAgendaMedicaDBContext>();

            if (args.Any(arg => arg == "Testing"))
            {
                connectionString = "SqlServerTests";
            }
            else
            {
               connectionString = "SqlServer";
            }

            optionsBuilder.UseSqlServer(configuration.GetConnectionString(connectionString));

            return new EAgendaMedicaDBContext(optionsBuilder.Options);

        }
    }
}
