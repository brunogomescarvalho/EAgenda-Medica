﻿using EAgendaMedica.Dominio.ModuloConsulta;
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

            bool intervaloValido = VerificaSeHaAtividadeNoIntervalo(atividades);

            bool inicioValido = VerificarInicio();

            bool terminoValido = VerificarTermino();

            return terminoValido && inicioValido && intervaloValido;
        }

        private void ObterRegistroPosterior(List<Atividade> atividades)
        {
            registroPosterior = atividades.Where(x => x.HoraInicio >= atividadeParaVerificar.HoraTermino &&
              x.Equals(atividadeParaVerificar) == false)
              .OrderBy(x => x.HoraInicio).FirstOrDefault()!;
        }

        private void ObterRegistroAnterior(List<Atividade> atividades)
        {
            registroAnterior = atividades.Where(x => x.HoraTermino <= atividadeParaVerificar.HoraInicio &&
             x.Equals(atividadeParaVerificar) == false)
             .OrderBy(x => x.HoraTermino).FirstOrDefault()!;
        }

        public bool VerificaSeHaAtividadeNoIntervalo(List<Atividade> atividades)
        {
            var encontrado = atividades.Where(x => x.Equals(atividadeParaVerificar) == false &&

            TemConflito(x, atividadeParaVerificar)).FirstOrDefault();

            return encontrado == null;
        }

        private bool VerificarInicio()
        {
            if (registroAnterior != null)
            {
                var tempo = registroAnterior is Consulta ? TempoAposConsulta : TempoAposCirurgia;

                var diferenca = atividadeParaVerificar.DataInicio.Subtract(registroAnterior.DataTermino).TotalMinutes;

                if (diferenca < 0)
                    return false;

                return diferenca > tempo;
            }

            return true;
        }

        private bool VerificarTermino()
        {
            if (registroPosterior != null)
            {
                var tempo = atividadeParaVerificar is Consulta ? TempoAposConsulta : TempoAposCirurgia;

                var diferenca = registroPosterior.DataInicio.Subtract(atividadeParaVerificar.DataTermino).TotalMinutes;

                if (diferenca < 0)
                    return false;

                return diferenca > tempo;
            }
            return true;
        }

        private static bool TemConflito(Atividade outro, Atividade paraVerificar)
        {
            return
              (outro.HoraInicio >= paraVerificar.HoraInicio && outro.HoraInicio <= paraVerificar.HoraTermino)

           || (outro.HoraTermino >= paraVerificar.HoraInicio && outro.HoraTermino <= paraVerificar.HoraTermino)

           || (outro.HoraInicio <= paraVerificar.HoraInicio && outro.HoraTermino >= paraVerificar.HoraTermino)

           || (outro.HoraInicio >= paraVerificar.HoraInicio && outro.HoraTermino <= paraVerificar.HoraTermino);

        }
    }

}
