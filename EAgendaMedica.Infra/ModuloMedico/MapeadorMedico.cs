using EAgendaMedica.Dominio.ModuloMedico;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAgendaMedica.Infra.ModuloMedico
{
    public class MapeadorMedico : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("TB_Medico");

            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();

            builder.Property(x => x.CRM).HasColumnType("varchar(30)")
              .IsRequired();

            builder.HasIndex(x => x.CRM)
                .IsUnique();

            builder.Property(e => e.Nome).HasColumnType("varchar(100)")
                .IsRequired();

            builder.Ignore(x => x.HorasTrabalhadas);

            builder.HasData(
                 new Medico { Id = Guid.NewGuid(), CRM = "12345-SC", Nome = "Médico 1" },
                 new Medico { Id = Guid.NewGuid(), CRM = "67890-SC", Nome = "Médico 2" });

        }
    }
}



