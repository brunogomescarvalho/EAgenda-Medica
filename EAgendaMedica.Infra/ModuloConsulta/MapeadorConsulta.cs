using EAgendaMedica.Dominio.ModuloConsulta;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAgendaMedica.Infra.ModuloConsulta
{
    public class MapeadorConsulta : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("TB_Consulta");

            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();

            builder.Property(x => x.HoraTermino).HasColumnType("bigint").IsRequired();
            builder.Property(x => x.HoraInicio).HasColumnType("bigint").IsRequired();
            builder.Property(x => x.Data).IsRequired();

            builder.HasOne(x => x.Medico)
                      .WithMany(x=>x.Consultas)
                      .IsRequired()
                      .HasForeignKey(x => x.MedicoId)
                      .OnDelete(DeleteBehavior.NoAction);
        }

    }
}


