using EAgendaMedica.Dominio.Copartilhado;
using EAgendaMedica.Dominio.ModuloMedico;

namespace EAgendaMedica.Dominio.ModuloCirurgia
{
    public class Cirurgia : Atividade
    {
        public List<Medico> Medicos { get; set; }

        public Cirurgia()
        {
            Medicos = new List<Medico>();
        }

        public void AdicionarEquipeMedica(List<Medico> medicos)
        {
            Medicos.AddRange(medicos);

            Medicos.ForEach(m => { m.AdicionarCirurgia(this); });
        }

        public void AdicionarMedico(Medico medico)
        {
            Medicos.Add(medico);
            medico.AdicionarCirurgia(this);
        }
    }
}

