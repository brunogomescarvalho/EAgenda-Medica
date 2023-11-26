
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ListarAtividades } from 'src/app/models/Atividades';
import { DialogExcluirComponent } from 'src/app/shared/componentes/dialog-excluir/dialog-excluir.component';
import { DialogComponentCirurgia } from 'src/app/views/cirurgia/componentes/dialogs/visualizar-detalhes/dialog.component';

@Injectable()
export class DialogService {
  constructor(private dialog: MatDialog,) { }


  visualizarDetalhesCirurgia(atividade: ListarAtividades) {
    return this.dialog.open(DialogComponentCirurgia, {
      width: '400px',
      data: atividade
    })
  }

  excluirCirurgia(data: any) {
    return this.dialog.open(DialogExcluirComponent, {
      width: '400px',
      data: {
        titulo:"Excluír",
        registro: "Cirurgia",
        msg: `Confirma excluir a cirurgia: ${data.dataInicio} - ${data.horaInicio} - ${data.horaTermino} ?`
      }
    })
  }
}

