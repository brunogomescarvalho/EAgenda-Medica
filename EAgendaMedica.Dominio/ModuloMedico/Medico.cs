using EAgendaMedica.Dominio.ModuloCirurgia;
using EAgendaMedica.Dominio.ModuloConsulta;
using Taikandi;

namespace EAgendaMedica.Dominio.ModuloMedico
{
    public class Medico
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }
        public List<Cirurgia> Cirurgias { get; set; }
        public List<Consulta> Consultas { get; set; }
        public int HorasTrabalhadasPorPeriodo { get; private set; }
        public int HorasTotaisTrabalhadas { get => ObterHorasTrabalhadas(); }


        public Medico()
        {
            Id = SequentialGuid.NewGuid();
            Cirurgias = new List<Cirurgia>();
            Consultas = new List<Consulta>();
        }

        public Medico(string nome, string crm) : this()
        {
            Nome = nome;
            CRM = crm;
        }

        public void AdicionarCirurgia(Cirurgia cirurgia)
        {
            if (cirurgia == null || Cirurgias.Contains(cirurgia))
                return;

            Cirurgias.Add(cirurgia);
        }

        public void AdicionarConsulta(Consulta consulta)
        {
            if (consulta == null || Consultas.Contains(consulta))
                return;

            Consultas.Add(consulta);
        }

        public List<Atividade> TodasAtividades()
        {
            var list = new List<Atividade>() { };

            list.AddRange(Cirurgias);

            list.AddRange(Consultas);

            return list;
        }

        public List<Atividade> AtividadesDoDia(DateTime data)
        {
            return TodasAtividades().FindAll(x => x.DataInicio.Date == data.Date);
        }

        public int ObterHorasTrabalhadasPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            HorasTrabalhadasPorPeriodo = TodasAtividades()

           .Where(x => x.DataInicio >= dataInicial && x.DataTermino <= dataFinal)

           .Select(x => x.DuracaoEmMinutos).Sum() / 60;

            return HorasTrabalhadasPorPeriodo;

        }

        private int ObterHorasTrabalhadas()
        {
            return TodasAtividades().Select(x => x.DuracaoEmMinutos).Sum() / 60;
        }

        public override string ToString()
        {
            return $"CRM: {CRM} - Nome: {Nome}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Medico medico &&
                   Id.Equals(medico.Id) &&
                   CRM == medico.CRM &&
                   Nome == medico.Nome;
        }
    }
}

