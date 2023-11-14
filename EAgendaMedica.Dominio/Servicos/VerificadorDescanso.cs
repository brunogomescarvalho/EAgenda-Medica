using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Dominio.ModuloMedico;


namespace EAgendaMedica.Dominio.Servicos
{
    public class VerificadorDescanso : AbstractValidator<Atividade>
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


        public List<Atividade> VerificarMedico(Medico medico)
        {
            return EhValido(medico);
        }

        public List<Atividade> VerificarEquipeMedica(List<Medico> medicos)
        {
            List<Atividade> conflitos;

            foreach (var item in medicos)
            {
                conflitos = EhValido(item);

                if (conflitos.Any())
                    return conflitos;
            }

            return null!;
        }

        public List<Atividade> EhValido(Medico medico)
        {
            var atividades = medico.TodasAtividades().FindAll(x => x.Data.Date == atividadeParaVerificar.Data.Date).ToList();

            ObterRegistroAnterior(atividades);

            ObterRegistroPosterior(atividades);

            return LocalizarConflitos();
        }



        private void ObterRegistroPosterior(List<Atividade> atividades)
        {
            registroPosterior = atividades
          .Where(x => x.HoraInicio.Ticks > atividadeParaVerificar.HoraTermino.Ticks)
          .OrderBy(x => Math.Abs((x.HoraInicio - atividadeParaVerificar.HoraTermino).Ticks))
          .First();
        }

        private void ObterRegistroAnterior(List<Atividade> atividades)
        {
            registroAnterior = atividades
          .Where(x => x.HoraTermino.Ticks < atividadeParaVerificar.HoraInicio.Ticks)
          .OrderBy(x => Math.Abs((x.HoraTermino - atividadeParaVerificar.HoraInicio).Ticks))
          .First();
        }

        private List<Atividade> LocalizarConflitos()
        {
            var atividadesEmConflitos = new List<Atividade>();

            TimeSpan diferencaInicio = atividadeParaVerificar.HoraInicio - registroAnterior.HoraTermino;
            TimeSpan diferencaFim = registroPosterior.HoraInicio - atividadeParaVerificar.HoraTermino;

            bool inicioValido;
            bool finalValido;

            if (registroAnterior is Cirurgia)
                inicioValido = diferencaInicio.TotalMinutes >= TempoAposCirurgia;

            else
                inicioValido = diferencaInicio.TotalMinutes >= TempoAposConsulta;

            if (atividadeParaVerificar is Cirurgia)
                finalValido = diferencaFim.TotalMinutes >= registroPosterior.Data.Ticks; //xxxxxxxxxxxxxxxxxxxxxxx

            else
                finalValido = diferencaFim.TotalMinutes >= TempoAposConsulta;

            if (!finalValido)
                atividadesEmConflitos.Add(registroPosterior);

            if (!inicioValido)
                atividadesEmConflitos.Add(registroAnterior);

            if (finalValido && inicioValido)
                return null!;

            return atividadesEmConflitos;

        }
    }
}
