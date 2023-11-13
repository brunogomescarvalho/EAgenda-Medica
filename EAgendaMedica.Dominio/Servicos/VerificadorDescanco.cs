using EAgendaMedica.Dominio.Copartilhado;
using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Dominio.ModuloMedico;


namespace EAgendaMedica.Dominio.Servicos
{
    public class VerificadorDescanco<T> where T : Atividade
    {

        Atividade atividade;

        private const int TempoAposCirurgia = 240;

        private const int TempoAposConsulta = 20;

        public VerificadorDescanco(T atividade)
        {
            this.atividade = atividade;
        }


        public bool VerificarMedico(Medico medico)
        {
            return Verificar(medico);
        }

        public bool VerificarEquipeMedica(List<Medico> medicos)
        {
            return true;
        }

        public bool Verificar(Medico medico)
        {
            var atividades = medico.TodasAtividades().FindAll(x => x.Data.Date == atividade.Data.Date).ToList();

            var registroAnterior = atividades
           .Where(x => x.HoraTermino.Ticks < atividade.HoraInicio.Ticks)
           .OrderBy(x => Math.Abs((x.HoraTermino - atividade.HoraInicio).Ticks))
           .First();

            var registroPosterior = atividades
           .Where(x => x.HoraInicio.Ticks > atividade.HoraTermino.Ticks)
           .OrderBy(x => Math.Abs((x.HoraInicio - atividade.HoraTermino).Ticks))
           .First();

            TimeSpan diferencaInicio = atividade.HoraInicio - registroAnterior.HoraTermino;
            TimeSpan diferencaFim = registroPosterior.HoraInicio - atividade.HoraTermino;

            bool inicioValido;
            bool finalValido;

            if (registroAnterior is Cirurgia)
                inicioValido = diferencaInicio.TotalMinutes >= TempoAposCirurgia;

            else
                inicioValido = diferencaInicio.TotalMinutes >= TempoAposConsulta;

            if (registroPosterior is Cirurgia)
                finalValido = diferencaFim.TotalMinutes >= TempoAposCirurgia;

            else
                finalValido = diferencaFim.TotalMinutes >= TempoAposConsulta;


            return inicioValido && finalValido == true;
        }
    }
}
