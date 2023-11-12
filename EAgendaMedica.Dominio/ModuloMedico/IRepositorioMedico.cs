using EAgendaMedica.Dominio.ModuloMedico;

namespace EAgendaMedica.Dominio
{
    internal interface IRepositorioMedico
    {
       Task <Medico> SelecionarPorCRM(string crm);
    }
}