using EAgendaMedica.Dominio.ModuloConsulta;
using EAgendaMedica.Dominio.ModuloMedico;

namespace EAgendaMedica.Dominio.Servicos
{
    public class VerificadorDescanso
    {
        private readonly Atividade atividadeParaVerificar;

        Atividade registroAnterior = null!;

        Atividade registroPosterior = null!;

        private const int TempoAposCirurgia = 240;

        private const int TempoAposConsulta = 20;

        public VerificadorDescanso(Atividade atividade)
        {
            this.atividadeParaVerificar = atividade;
        }

        public bool Verificar(Medico medico)
        {
            var atividades = medico.AtividadesDoDia(atividadeParaVerificar.DataInicio);

            ObterRegistroAnterior(atividades);

            ObterRegistroPosterior(atividades);

            return VerificarInicio() && VerificarTermino();
        }

        private void ObterRegistroPosterior(List<Atividade> atividades)
        {
            registroPosterior = atividades.Where(x => x.HoraInicio >= atividadeParaVerificar.HoraTermino && x.Equals(atividadeParaVerificar) == false)
             .OrderBy(x => x.HoraInicio).FirstOrDefault()!;
        }

        private void ObterRegistroAnterior(List<Atividade> atividades)
        {
            registroAnterior = atividades.Where(x => x.HoraTermino <= atividadeParaVerificar.HoraInicio && x.Equals(atividadeParaVerificar) == false)
             .OrderBy(x => x.HoraTermino).FirstOrDefault()!;
        }

        private bool VerificarInicio()
        {
            if (registroAnterior != null)
            {
                var tempo = registroAnterior is Consulta ? TempoAposConsulta : TempoAposCirurgia;

                var diferenca = atividadeParaVerificar.HoraInicio.Subtract(registroAnterior.HoraTermino).TotalMinutes;

                return diferenca > tempo;
            }

            return true;
        }

        private bool VerificarTermino()
        {
            if (registroPosterior != null)
            {
                var tempo = atividadeParaVerificar is Consulta ? TempoAposConsulta : TempoAposCirurgia;

                var diferenca = registroPosterior.HoraInicio.Subtract(atividadeParaVerificar.HoraTermino).TotalMinutes;

                return diferenca > tempo;
            }
            return true;
        }
    }
}
