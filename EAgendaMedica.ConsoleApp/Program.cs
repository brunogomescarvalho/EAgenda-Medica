using EAgendaMedica.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace EAgendaMedica.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EAgendaMedicaDBContext>();

            optionsBuilder.UseSqlServer(@"Data Source=(LOCALDB)\MSSQLLOCALDB;Initial Catalog=EAgendaMedicaDB;Integrated Security=True");

            var dbContext = new EAgendaMedicaDBContext(optionsBuilder.Options);

            AtualizarBancoDados(dbContext);
        }


        private static void AtualizarBancoDados(DbContext db)
        {
            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Any())
            {
                db.Database.Migrate();

                Console.Clear();
                Console.WriteLine("Atualizado...");

            }
        }
    }
}