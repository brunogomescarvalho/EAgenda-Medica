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
        public bool Ativo { get; set; }

        public List<Cirurgia> Cirurgias { get; set; }
        public List<Consulta> Consultas { get; set; }
        public int HorasTrabalhadasNoPeriodo { get; private set; }
        public int HorasTotaisTrabalhadas { get => ObterHorasTrabalhadas(); }


        public Medico()
        {
            Id = SequentialGuid.NewGuid();
            Cirurgias = new List<Cirurgia>();
            Consultas = new List<Consulta>();
            Ativo = true;
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

            CarregarInformacoesAtividades(list);

            return list;
        }

        public List<Atividade> AtividadesDoDia(DateTime data)
        {
            return TodasAtividades().FindAll(x => x.DataInicio.Date == data.Date);
        }

        public int ObterHorasTrabalhadasPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            HorasTrabalhadasNoPeriodo = TodasAtividades()

           .Where(x => x.DataInicio >= dataInicial && x.DataTermino <= dataFinal)

           .Select(x => x.DuracaoEmMinutos).Sum() / 60;

            return HorasTrabalhadasNoPeriodo;

        }

        private static void CarregarInformacoesAtividades(List<Atividade> atividades)
        {
            atividades.ForEach(x => x.AtualizarInformacoes(x));
        }


        private int ObterHorasTrabalhadas()
        {
            return TodasAtividades().Select(x => x.DuracaoEmMinutos).Sum() / 60;
        }

        public void AlterarStatus()
        {
            Ativo = !Ativo;
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

