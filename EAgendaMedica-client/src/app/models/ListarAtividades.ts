import { Time } from "@angular/common"

export class ListarAtividades {
  id?: string
  dataInicio?: string
  horaInicio?: string
  horaTermino?: string
}

export class FormAtividadeBase {
  dataInicio?: Date
  horaInicio?: Time
  duracaoEmMinutos?: number
}

export class FormConsulta extends FormAtividadeBase {
  medicoId?: string
}

export class FormCirurgia extends FormAtividadeBase {
  medicosIds?: string[]
}

export class VisualizarAtividadeBase {
  id?: string
  dataInicio?: Date
  horaInicio?: Time
  dataTermino?: Date
  horaTermino?: Time
}


export class ListarMedicos {
  id?: string
  nome?: string
  crm?: string
}

export class FormMedico{
  nome?: string
  crm?: string
}

export class VisualizarConsulta extends VisualizarAtividadeBase {
  medico?: ListarMedicos
}

export class VisualizarCirurgia extends VisualizarAtividadeBase {
  medicos?: ListarMedicos[]
}







