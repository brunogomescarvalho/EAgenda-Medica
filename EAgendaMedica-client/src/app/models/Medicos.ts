export class ListarMedicos {
  id?: string
  nome?: string
  crm?: string
}

export class FormMedico {
  nome?: string
  crm?: string
}

export class VisualizarMedico {
  id?: string
  nome?: string
  crm?: string
  situacao?: string
  atividades?: AtividadeMedico[]
}

class AtividadeMedico {
  id?: string
  dataInicio?: string
  horaInicio?: string
  horaTermino?: string
  tipoAtividade?: string
}

export class Top10Medicos {
  id?: string
  nome?: string
  crm?: string
  horasTrabalhadasNoPeriodo?: number
}
