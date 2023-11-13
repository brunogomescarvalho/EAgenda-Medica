using EAgendaMedica.Dominio.ModuloCirurgia;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAgendaMedica.Infra.ModuloCirurgia
{
    public class MapeadorCirurgia : IEntityTypeConfiguration<Cirurgia>
    {
        public void Configure(EntityTypeBuilder<Cirurgia> builder)
        {
            builder.ToTable("TB_Cirurgia");

            builder.Property(c => c.Id).ValueGeneratedNever().IsRequired();

            builder.HasMany(c => c.Medicos)
                .WithMany(c => c.Cirurgias)
                .UsingEntity(c => c.ToTable("TB_Medico_TB_Cirurgia"));

            builder.Property(c => c.HoraTermino).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.HoraInicio).HasColumnType("bigint").IsRequired();
            builder.Property(c => c.Data).IsRequired();


        }
    }
}
