import { Injectable } from '@angular/core';
import { DetalhesConsultaComponent } from '../componentes/dialogs/visualizar-detalhes-consulta/visualizar-detalhes-consulta.component';
import { MatDialog } from '@angular/material/dialog';
import { ListarAtividades } from 'src/app/models/Atividades';
import { DialogExcluirComponent } from 'src/app/shared/componentes/dialog-excluir/dialog-excluir.component';

@Injectable()
export class ConsultaDialogService {




  constructor(private dialog: MatDialog,) { }

  visualizarDetalhesConsulta(atividade: ListarAtividades) {
    return this.dialog.open(DetalhesConsultaComponent, {
      width: '400px',
      data: atividade
    })
  }

  excluirConsulta(data: any) {
    return this.dialog.open(DialogExcluirComponent, {
      width: '400px',
      data: {
        titulo:"Excluír",
        registro: "Consulta",
        msg: `Confirma excluir a consulta: ${data.dataInicio} - ${data.horaInicio} - ${data.horaTermino} ?`
      }
    })
  }
}
