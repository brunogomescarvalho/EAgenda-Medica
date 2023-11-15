using EAgendaMedica.Dominio.ModuloCirurgia;
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

        private bool tempoInicialValido = true;

        private bool tempoFinalValido = true;

        public VerificadorDescanso(Atividade atividade)
        {
            this.atividadeParaVerificar = atividade;
        }

        public bool Verificar(Medico medico)
        {
            var atividades = medico.AtividadesDoDia(atividadeParaVerificar.DataInicio);

            ObterRegistroAnterior(atividades);

            ObterRegistroPosterior(atividades);

            return LocalizarConflitos();
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

        private bool LocalizarConflitos()
        {
            VerificarInicio();

            VerificarTermino();

            return tempoInicialValido && tempoFinalValido;

        }

        private void VerificarInicio()
        {
            if (registroAnterior != null)
            {
                var tempo = registroAnterior is Consulta ? TempoAposConsulta : TempoAposCirurgia;

                var diferenca = atividadeParaVerificar.HoraInicio.Subtract(registroAnterior.HoraTermino).TotalMinutes;

                tempoInicialValido = diferenca > tempo;
            }
        }

        private void VerificarTermino()
        {
            if (registroPosterior != null)
            {
                var tempo = atividadeParaVerificar is Consulta ? TempoAposConsulta : TempoAposCirurgia;

                var diferenca = registroPosterior.HoraInicio.Subtract(atividadeParaVerificar.HoraTermino).TotalMinutes;

                tempoFinalValido = diferenca > tempo;
            }

        }
    }
}
